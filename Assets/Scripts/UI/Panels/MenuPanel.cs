using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class MenuPanel : BasePanel
    {
        [SerializeField] private Button openNewPanel;
        [SerializeField] private Button openUserPanel;
        
        void Start()
        {
            openNewPanel.onClick.AddListener((() =>
            {
                UIManager.Instance.OpenPanel(UIPanelType.NewPanel);
            }));
            openUserPanel.onClick.AddListener((() =>
            {
                UIManager.Instance.OpenPanel(UIPanelType.UserPanel);
            }));
        }
    }
}
