require "Common.define"

TestViewCtrl={};
local this = TestViewCtrl;

local luabehaviour;
local transform;
local gameobject;

--构建函数
function TestViewCtrl.New()
    log("TestViewCtrl.New-->");
    return this;
end

function TestViewCtrl.Awake()
    log("TestViewCtrl.Awake-->");
    panelMgr:CreatePanel('TestView',this.OnCreate);
end

function TestViewCtrl.OnCreate(obj)
    log("TestViewCtrl.OnCreate->",obj);
    gameobject = obj;
    transform = obj.transform;

    luabehaviour = transform:GetComponent('LuaBehaviour');

    resMgr:LoadPrefab('TestView',{'TestView'},this.InitPanel);
end

--关闭按钮
function TestViewCtrl.OnClick()
    log("this page is close->");
    
end


function TestViewCtrl.InitPanel(objs)
    log("TestViewCtrl.InitPanel->");
    local go = newObject(objs[0]);--UnityEngine.GameObject.Instantiate(objs[0]);
	local parent = go.transform:Find("Canvas");--UnityEngine.GameObject.Find("Canvas");
	go.transform:SetParent(parent.transform);
	go.transform.localScale = Vector3.one;
    go.transform.localPosition = Vector3.zero;

    --注册页面按钮
    luabehaviour:AddClick(TestPanel.BtnClose,this.OnClick);
end

function TestViewCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.TestView);
end