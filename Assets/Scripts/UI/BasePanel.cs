using UnityEngine;

namespace UI
{
    public class BasePanel : MonoBehaviour
    {
        protected UIPanelType PanelType;
        
        public virtual void OpenPanel(UIPanelType panelType)
        {
            PanelType = panelType;
            gameObject.SetActive(true);
        }

        public virtual void ClosePanel()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            
            UIManager.Instance.RemovePanelDictionary(PanelType);
        }
    }
}