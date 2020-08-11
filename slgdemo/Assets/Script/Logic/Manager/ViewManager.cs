using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// UI管理器
/// </summary>
public class ViewManager : Singleton<ViewManager>
{
    private Transform _CanvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (_CanvasTransform == null)
            {
                _CanvasTransform = GameObject.Find("Canvas").transform;
            }
            return _CanvasTransform;
        }
    }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        //此处开始进行构造
        ParseViewTypeJson();
    }

    protected override void OnUnInitialize()
    {
        base.OnUnInitialize();
    }

    private Dictionary<string, string> _ViewPathDict;
    private Dictionary<string, ViewBase> _ViewDict;

    //界面栈
    private Stack<ViewBase> _ViewStack;

    /// <summary>
    /// UI入栈
    /// </summary>
    /// <param name="viewType"></param>
    public void ShowView(string viewType)
    {
        if (_ViewStack == null)
        {
            _ViewStack = new Stack<ViewBase>();
        }
        if (_ViewStack.Count > 0)
        {
            //设置栈顶UI不出栈
            ViewBase topView = _ViewStack.Peek();
            topView.OnPause();
        }

        ViewBase view = GetView(viewType);
        _ViewStack.Push(view);
        view.OnInit();
    }

    /// <summary>
    /// UI出栈
    /// </summary>
    /// <param name="viewType"></param>
    public void CloseView()
    {
        Debug.Log("Stack have view count->" + _ViewStack.Count);
        if (_ViewStack == null)
        {
            _ViewStack = new Stack<ViewBase>();
        }
        if (_ViewStack.Count <= 0)
        {
            return;
        }
        ViewBase topView = _ViewStack.Pop();
        topView.OnUnInit();
        if (_ViewStack.Count > 0)
        {
            ViewBase view = _ViewStack.Peek();
            view.OnResume();
        }
    }


    /// <summary>
    /// 根据UI类型获取UI
    /// </summary>
    /// <param name="viewType"></param>
    /// <returns></returns>
    private ViewBase GetView(string viewType)
    {
        if (_ViewDict == null)
        {
            _ViewDict = new Dictionary<string, ViewBase>();
        }

        ViewBase view = _ViewDict.GetValue(viewType);

        if (view == null)
        {
            string path = _ViewPathDict.GetValue(viewType);
            if (!string.IsNullOrEmpty(path))
            {
                Debug.Log("GetView path ->" + path);
                var reouse = Resources.Load<GameObject>(path);
                if (reouse != null)
                {
                    //实例化界面对象
                    GameObject go = GameObject.Instantiate(reouse, CanvasTransform, false);
                    view = go.GetComponent<ViewBase>();
                    if (!_ViewDict.ContainsKey(viewType))
                    {
                        _ViewDict.Add(viewType, view);
                    }
                }
            }
        }
        return view;
    }

    /// <summary>
    /// 反序列化Json添加到字典中
    /// </summary>
    private void ParseViewTypeJson()
    {
        Debug.Log("Json is begin->");
        _ViewPathDict = new Dictionary<string, string>();
        string path = "UI";
        //var jsonText = Resources.Load(path) as TextAsset;
        //ViewInfoList viewInfoList = JsonUtility.FromJson<ViewInfoList>(jsonText.text);
        string jsonText = JsonTool.ReadJsonText(path);
        ViewInfoList viewInfoList = JsonTool.LoadJsonData<ViewInfoList>(jsonText);
        foreach (ViewInfo uiinfo in viewInfoList._ViewInfoList)
        {
            Debug.Log("Check ui type is ->" + uiinfo.ViewType);
            if (!_ViewPathDict.ContainsKey(uiinfo.ViewType))
            {
                _ViewPathDict.Add(uiinfo.ViewType, uiinfo.Path);
            }
        }
    }



}
