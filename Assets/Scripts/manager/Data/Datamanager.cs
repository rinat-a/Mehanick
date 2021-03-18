using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    public static Datamanager S;
    private void Awake()
    {
        if (S == null) S = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void SaveToprefs<T>(T data)
    {
        PlayerPrefs.SetString(typeof(T).Name, JsonUtility.ToJson(data));
    }
    public T LoafFromPrefs<T>() where T : DataClasses, new()
    {
        var loadedValue = PlayerPrefs.GetString(typeof(T).Name, null);
        return string.IsNullOrEmpty(loadedValue) ? new T() : JsonUtility.FromJson<T>(loadedValue);
    }
}
