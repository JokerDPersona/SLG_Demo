using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainView:ViewBase
{
    private Button _CloseBtn;
    private Button _OpenBtn;

    private void Awake()
    {
        Bind();
    }

    public override void OnInit()
    {
        base.OnInit();
        UnityEngine.Debug.Log("IsHaveInit->");
    }

    //每个脚本都在此处进行资源回收或者销毁
    public override void OnUnInit()
    {
        base.OnUnInit();
        UnityEngine.Debug.Log("UnInitBegin->");
        GameObject.Destroy(gameObject);
    }

    public override void OnPause()
    {
        base.OnPause();

    }

    public override void OnResume()
    {
        base.OnResume();

    }
    
    //此处进行控件绑定
    private void Bind()
    {
        _CloseBtn = transform.Find("Win/BtnClose").GetComponent<Button>();
        UnityEngine.Debug.Log("Get the button->" + _CloseBtn);
        //关闭监听
        _CloseBtn.onClick.AddListener(() =>
        {
            UnityEngine.Debug.Log("Close the view->");
            ViewManager.Instance.CloseView();
        });
        _OpenBtn = transform.Find("Win/BtnOpen").GetComponent<Button>();
        _OpenBtn.onClick.AddListener(() =>{
            UnityEngine.Debug.Log("Open the new page->");
            ViewManager.Instance.ShowView(ViewType.TestPanel); 
        });
    }


}
