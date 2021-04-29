using System;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.PushNotifications
{
    public class NotificationWindow : MonoBehaviour
    {
        private const string AndroidNotifierId = "android_notifier_id";

        [SerializeField] private Button _buttonNotification;

        private void Start()
        {
            _buttonNotification.onClick.AddListener(CreateNotification);
        }

        private void CreateNotification()
        {
#if UNITY_ANDROID
            var androidSettingsChannel = new AndroidNotificationChannel
            {
                Id = AndroidNotifierId,
                Name = "Game Notifier",
                Importance = Importance.High,
                CanBypassDnd = true,
                CanShowBadge = true,
                Description = "Enter the game and get free crystals",
                EnableLights = true,
                EnableVibration = true,
                LockScreenVisibility = LockScreenVisibility.Public
            };
            
            AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChannel);
            
            var androidSettingsNotification = new AndroidNotification
            {
                Color = Color.white,
                RepeatInterval = TimeSpan.FromSeconds(30)
            };

            AndroidNotificationCenter.SendNotification(androidSettingsNotification, AndroidNotifierId);
#endif
        }
    }
}