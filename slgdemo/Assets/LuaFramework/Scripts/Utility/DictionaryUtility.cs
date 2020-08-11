using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 字典函数拓展类
/// </summary>
public static class DictionaryUtility
{
    /// <summary>
    /// TryGetValue拓展函数
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dict"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        TValue tvalue = default(TValue);
        dict.TryGetValue(key, out tvalue);
        return tvalue;
    }
}
