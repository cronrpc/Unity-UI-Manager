using System.Collections.Generic;

namespace UI
{
    public enum UIPanelType
    {
        MenuPanel, UserPanel, NewPanel 
    }

    public class UIPanel
    {
        public static string RelativePathPrefix { get; private set; } = "Prefabs/UI/";

        public static Dictionary<UIPanelType, string> PathDictionary {get; private set;}
        = new (){
            { UIPanelType.MenuPanel, "MenuPanel" },
            { UIPanelType.UserPanel, "UserPanel" },
            { UIPanelType.NewPanel, "NewPanel" }
        };
    }
}