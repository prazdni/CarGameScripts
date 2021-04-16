using System;
using UnityEngine;

public class StorageContext<T>
{
    readonly string _playerPrefsKey;

    public StorageContext(string playerPrefsKey)
    {
        _playerPrefsKey = playerPrefsKey;
    }

    public T Read()
    {
        T value = default;

        if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            try
            {
                Type t = typeof(T);

                if (t == typeof(int) ||
                    t == typeof(short) ||
                    t == typeof(ushort) ||
                    t == typeof(byte))
                {
                    value = (T)(object)PlayerPrefs.GetInt(_playerPrefsKey);
                }
                else if (t == typeof(float))
                {
                    value = (T)(object)PlayerPrefs.GetFloat(_playerPrefsKey);
                }
                else if (t == typeof(string))
                {
                    value = (T)(object)PlayerPrefs.GetString(_playerPrefsKey);
                }
                else
                {
                    var playerPrefsValue = PlayerPrefs.GetString(_playerPrefsKey);
                    value = JsonUtility.FromJson<T>(playerPrefsValue);
                }
            }
            catch (Exception ex)
            {
                PlayerPrefs.DeleteKey(_playerPrefsKey);
                PlayerPrefs.Save();
                Debug.Log($"Local storage '{_playerPrefsKey}' load error: {ex.Message}");
            }
        }

        return value;
    }

    public void Write(T value)
    {
        Type t = typeof(T);

        if (t == typeof(int) ||
            t == typeof(short) ||
            t == typeof(ushort) ||
            t == typeof(byte))
        {
            PlayerPrefs.SetInt(_playerPrefsKey, (int)(object)value);
        }
        else if (t == typeof(float))
        {
            PlayerPrefs.SetFloat(_playerPrefsKey, (float)(object)value);
        }
        else if (t == typeof(string))
        {
            PlayerPrefs.SetString(_playerPrefsKey, (string)(object)value);
        }
        else
        {
            PlayerPrefs.SetString(_playerPrefsKey, JsonUtility.ToJson(value));
        }

        PlayerPrefs.Save();
    }

    public void Remove()
    {
        PlayerPrefs.DeleteKey(_playerPrefsKey);
        PlayerPrefs.Save();
    }

    public bool HasValue()
    {
        return PlayerPrefs.HasKey(_playerPrefsKey);
    }
}