using System;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;


namespace Test_Project
{
    public class UiManager : MonoBehaviour
    {
        public MenuUI menuUI { get; private set; }
        public InGameUI inGameUI { get; private set; }
        public WinUI winUI { get; private set; }
        public LoseUI loseUI { get; private set; }


        [SerializeField] List<GameObject> _menuUIGameObjects;
        [SerializeField] List<GameObject> _inGameUIGameObjects;
        [SerializeField] List<GameObject> _winUIGameObjects;
        [SerializeField] List<GameObject> _loseUIGameObjects;


        BaseMode<List<GameObject>> _currentUI;

        private void Awake()
        {
            menuUI = new MenuUI(_menuUIGameObjects);
            inGameUI = new InGameUI(_inGameUIGameObjects);
            winUI = new WinUI(_winUIGameObjects);
            loseUI = new LoseUI(_loseUIGameObjects);
        }

       
        public void SwitchUI(BaseMode<List<GameObject>> i_baseUI)
        {
            _currentUI?.Off();
            _currentUI = i_baseUI;
            _currentUI?.On();
        }
    }
}