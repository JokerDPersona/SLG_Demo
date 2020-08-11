using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : EditorWindow
{
    Vector2 scrollPos = Vector2.zero;


    /// <summary>
    /// 窗口构造函数
    /// </summary>
    UIManager()
    {
        this.titleContent = new GUIContent("UI管理器");
    }

    [MenuItem("UIManager/View")]
    public static void CreateUIManagerWindow()
    {
        Debug.Log("Open ViewManager");
        EditorWindow.GetWindow(typeof(UIManager));
    }

    /// <summary>
    /// 初始化界面数据
    /// </summary>
    private void OnEnable()
    {
        //创建根节点
        VisualElement root = rootVisualElement;
        //读取uxml
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UIManager.uxml");
        //读取uss
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/UIManager.uss");
        //创建新的子节点
        VisualElement labelFromUXML = visualTree.CloneTree();
        //为uxml添加uss样式
        labelFromUXML.styleSheets.Add(styleSheet);
        //将子节点添加到根节点
        root.Add(labelFromUXML);
    }

    /// <summary>
    /// 开始绘制编辑器窗口
    /// </summary>
    private void OnGUI()
    {
        //scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height));

        //GUILayout.BeginVertical();
        //GUILayout.Label("添加UI");
        //if (GUILayout.Button("添加UI"))
        //{

        //}
        //GUILayout.Label("删除UI");
        //if (GUILayout.Button("删除UI"))
        //{

        //}
        //GUILayout.Label("插入UI");
        //if (GUILayout.Button("插入UI"))
        //{

        //}
        //GUILayout.EndVertical();

        //GUILayout.EndScrollView();

        
    }
}
