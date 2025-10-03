using UI;
using UnityEngine;

public class UISample : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.OpenPanel(UIPanelType.MenuPanel);
    }
}
