using System;
using System.Reflection;
using UnityEngine;
public class Singleton<T> where T : class, new()
{
    private static T _Instance = null;
    //锁
    private static readonly object _Syslock = new object();

    /// <summary>
    /// 泛型单例实例化
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                lock (_Syslock)
                {
                    _Instance = new T();
                    CallFunction("OnInitialize");
                    Debug.Log("Create Singleton Instance->" + typeof(T).Name);
                }
            }
            return _Instance;
        }
        set { _Instance = value; }
    }

    //创建单例对象
    public static void CreateInstance()
    {
        if(_Instance != null)
        {
            return;
        }
        var instance = _Instance;
    }

    //释放资源
    public static void Release()
    {
        if(_Instance != null)
        {
            CallFunction("OnUnInitialize");
            _Instance = default(T);
        }
    }

    /// <summary>
    /// 根据函数名反射
    /// </summary>
    /// <param name="funcName"></param>
    private static void CallFunction(string funcName)
    {
        Type type = _Instance.GetType();
        while(type != null)
        {
            var func = type.GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if(func != null)
            {
                func.Invoke(_Instance, null);
            }
            type = type.BaseType;
        }
    }

    /// <summary>
    /// 虚构造函数
    /// </summary>
    protected virtual void OnInitialize()
    {

    }

    /// <summary>
    /// 虚析构函数
    /// </summary>
    protected virtual void OnUnInitialize()
    {

    }

}