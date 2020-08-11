using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Json序列化或反序列化工具
/// </summary>
public static class JsonTool
{
    public static void CreateJsonFile(string name,object jsonData)
    {
        string path = Application.dataPath + "/" + "UIJson" + "/" + name + ".json";
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
        {
            string json = JsonUtility.ToJson(jsonData);
            using(StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine(json);
                sw.Flush();
            }
        }
    }

    /// <summary>
    /// 反序列化Json
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="jsonText">Json的正文</param>
    /// <returns>反序列化的对象</returns>
    public static T LoadJsonData<T>(string jsonText)
    {
        Debug.Log("JsonText is ->" + jsonText);
        if (string.IsNullOrEmpty(jsonText))
        {
            return default(T);
        }
        T t = JsonUtility.FromJson<T>(jsonText);
        return t;
    }

    /// <summary>
    /// 读取Json文件流
    /// </summary>
    /// <param name="name">json文件名</param>
    /// <returns></returns>
    public static string ReadJsonText(string name)
    {
        string path = Application.dataPath + "/" + "UIJson" + "/" + name + ".json";
        Debug.Log("JsonText path is->" + path);
        using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using(StreamReader sr = new StreamReader(fs))
            {
                string str = sr.ReadToEnd();
                return str;
            }
        }
    }


}
