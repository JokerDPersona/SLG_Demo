using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// ViewBase类  
/// 一定要重写这四个虚函数 没定义成抽象是为了拓展方便
/// </summary>
public class ViewBase : MonoBehaviour
{
    //初始化
    public virtual void OnInit()
    {
        
    }

    //销毁
    public virtual void OnUnInit()
    {

    }

    //暂停
    public virtual void OnPause()
    {

    }

    //继续
    public virtual void OnResume()
    {

    }

}
