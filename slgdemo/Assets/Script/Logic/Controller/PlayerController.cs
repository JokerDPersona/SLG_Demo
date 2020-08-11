using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{

    protected override void OnUnInitialize()
    {
        base.OnUnInitialize();
        Debug.Log("End the logic->");
    }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        Debug.Log("Begin the logic->");
    }

    public void ShowPlayerInfo()
    {
        Debug.Log("This PlayerInfo is->");

        
    }



}
