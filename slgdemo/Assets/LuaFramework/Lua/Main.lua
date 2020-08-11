--主入口函数。从这里开始lua逻辑
function Main()					
	print("logic start")	
	-- local LuaHelper = LuaFramework.LuaHelper;
	-- local resMgr = LuaHelper.GetResManager(); 	
	-- resMgr:LoadPrefab('TestView',{'TestView'},InitPanel);
end

function InitPanel(objs)
	log("TestViewCtrl.InitPanel->",objs);
    local go = newObject(objs[0]);--UnityEngine.GameObject.Instantiate(objs[0]);
	local parent = go.transform:Find("Canvas");--UnityEngine.GameObject.Find("Canvas");
	go.transform:SetParent(parent.transform);
	go.transform.localScale = Vector3.one;
    go.transform.localPosition = Vector3.zero;

	local luabehaviour = go.transform:GetComponent('LuaBehaviour');
    --注册页面按钮
    luabehaviour:AddClick(TestPanel.BtnClose,OnClick);
end

function OnClick()
	log("this page is close->");
end

--场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()

end