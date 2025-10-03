using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class NewPanel : BasePanel
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        
        void Start()
        {
            yesButton.onClick.AddListener((() =>
            {
                ClosePanel();
            }));
            noButton.onClick.AddListener((() =>
            {
                ClosePanel();
            }));
        }
    }
}
