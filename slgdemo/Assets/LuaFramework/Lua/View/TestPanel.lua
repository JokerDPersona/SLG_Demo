local transform;
local gameobject;

TestPanel={};
local this = TestPanel;

--启动事件
function TestPanel.Awake(obj)
    gameobject = obj;
    transform = obj.transform;

    this.InitView();
    log("Awake lua->"..gameobject.name);
end

function TestPanel.InitView()
    this.BtnClose = transform:Find("Win/Button").gameobject;
end

function TestPanel.OnDestort()
    log("This obj is destory->"..gameobject.name);
end