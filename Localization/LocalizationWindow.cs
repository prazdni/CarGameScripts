using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace CarGameScripts.Localization
{
    public class LocalizationWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _changeText;
        [SerializeField] private Button _changeTextButton;
        private int _currentLocale;

        private void Start()
        {
            ChangedLocaleEvent(null);
            LocalizationSettings.SelectedLocaleChanged += ChangedLocaleEvent;
            
            _currentLocale = DataStorage.CurrentLocale.Read();
            
            _changeTextButton.onClick.AddListener(() =>
            {
                _currentLocale += 1;
                _currentLocale %= 2;
                ChangeLanguage(_currentLocale);
            });
            
            StartCoroutine(SetLanguage());
        }

        private void OnDestroy()
        {
            _changeTextButton.onClick.RemoveAllListeners();
            LocalizationSettings.SelectedLocaleChanged -= ChangedLocaleEvent;
            DataStorage.CurrentLocale.Write(_currentLocale);
        }

        private void ChangedLocaleEvent(Locale locale)
        {
            StartCoroutine(OnChangedLocale(locale));
        }

        private IEnumerator OnChangedLocale(Locale locale)
        {
            var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("Font");
            yield return loadingOperation;

            if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
            {
                var table = loadingOperation.Result;
                _changeText.text = table.GetEntry("LANGUAGE")?.GetLocalizedString();
            }
            else
            {
                Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
            }
        }

        private void ChangeLanguage(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }

        private IEnumerator SetLanguage()
        {
            while (LocalizationSettings.AvailableLocales.Locales.Count == 0)
            {
                yield return null;
            }
            
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_currentLocale];
        }
    }
}