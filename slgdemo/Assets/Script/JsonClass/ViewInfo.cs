using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// UI序列化类
/// </summary>
[Serializable]
public class ViewInfo
{
    //UI类型
    public string ViewType;
    //UI路径
    public string Path;

    public ViewInfo() { }
}