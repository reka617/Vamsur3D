using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Util
{
    #region ReadJson
    public static T LoadJson<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }

    public static T LoadJsonList<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonConvert.DeserializeObject<T>(textAsset.text);
    }

    public static Dictionary<T, T2> LoadJsonDict<T, T2>(string path)
    {

        string text = "";
        if (path.IndexOf(".json") == -1)
        {
            text = Resources.Load<TextAsset>(path).text;
        }
        else
        {
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
        }

        return JsonConvert.DeserializeObject<Dictionary<T, T2>>(text);
    }
    #endregion

    #region
    public static void SaveJson<T>(T data, string fileName, string folderName)
    {
        string json = JsonConvert.SerializeObject(data);
        using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileName + "/" + folderName))
        {
            sw.Write(json);
        }
    }
    #endregion
}
