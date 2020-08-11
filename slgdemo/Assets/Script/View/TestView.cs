using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestView:ViewBase
{
    private Button _CloseBtn;
    
    public override void OnInit()
    {
        base.OnInit();
        Debug.Log("InitTestView Begin->");
        Bind();
    }

    public override void OnUnInit()
    {
        base.OnUnInit();
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

    private void Bind()
    {
        _CloseBtn = transform.Find("Win/BtnClose").GetComponent<Button>();
        _CloseBtn.onClick.AddListener(() =>
        {
            ViewManager.Instance.CloseView();
        });
    }
}
