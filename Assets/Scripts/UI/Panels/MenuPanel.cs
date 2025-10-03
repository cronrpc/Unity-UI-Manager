using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class MenuPanel : BasePanel
    {
        [SerializeField] private Button openNewPanel;
        [SerializeField] private Button openUserPanel;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

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

        public override void OpenPanel(UIPanelType panelType)
        {
            base.OpenPanel(panelType);
            _canvasGroup.alpha = 0;
        }

        private float timer = 0;
        private void Update()
        {
            if (timer < 1.1)
            {
                timer += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Clamp01(timer);
            }
        }
    }
}
