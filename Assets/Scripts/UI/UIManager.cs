using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager
    {
        private readonly string UIROOTNAME = "UI";
        
        private static UIManager _instance;
        private Transform _uiRoot;
        
        // Prefabs Cache 
        private Dictionary<UIPanelType, GameObject> _prefabDictionary = new();
        // Opening Panel Dictionary
        private Dictionary<UIPanelType, BasePanel> _panelDictionary = new();

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        public Transform UIRoot
        {
            get
            {
                if (_uiRoot == null)
                {
                    GameObject uiGameObject = GameObject.Find(UIROOTNAME);
                    if ( uiGameObject != null)
                    {
                        _uiRoot = GameObject.Find(UIROOTNAME).transform;
                    }
                    else
                    {
                        _uiRoot =  new GameObject(UIROOTNAME).transform;
                    }
                }
                return _uiRoot;
            }
        }
        
        private UIManager()
        {
        }

        public BasePanel OpenPanel(UIPanelType panelType)
        {
            BasePanel panel = null;
            if (_panelDictionary.TryGetValue(panelType, out panel))
            {
                Debug.Log("Panel is Open: " + panelType);
                return null;
            }

            string path = UIPanel.PathDictionary[panelType];

            GameObject panelPrefab = null;
            if (!_prefabDictionary.TryGetValue(panelType, out panelPrefab))
            {
                string relativePath = UIPanel.RelativePathPrefix + path;
                panelPrefab = Resources.Load<GameObject>(relativePath);
                _prefabDictionary.Add(panelType, panelPrefab);
            }

            // Open Panel
            GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
            panel =  panelObject.GetComponent<BasePanel>();
            panel.OpenPanel(panelType);
            _panelDictionary.Add(panelType, panel);
            return panel;
        }

        public bool ClosePanel(UIPanelType panelType)
        {
            BasePanel panel = null;
            if (!_panelDictionary.TryGetValue(panelType, out panel))
            {
                return false;
            }
            
            panel.ClosePanel();
            return true;
        }

        public void RemovePanelDictionary(UIPanelType panelType)
        {
            _panelDictionary.Remove(panelType);
        }
    
    }
}