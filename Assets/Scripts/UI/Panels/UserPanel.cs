using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class UserPanel : BasePanel
    {
        [SerializeField] private Button exitButton;
        
        void Start()
        {
            exitButton.onClick.AddListener((() =>
            {
                ClosePanel();
            }));
        }
    }
}
