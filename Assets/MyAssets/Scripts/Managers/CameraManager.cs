using System;
using UnityEngine;

namespace Test_Project
{
    public class CameraManager : MonoBehaviour
    {

        public MenuCamera menuCamera { get;private set; }
        public InGameCamera inGameCamera { get;private set; }
        public WinCamera winCamera { get;private set; }

        [SerializeField] private Animator _animator;
        
        
        BaseMode<Animator> _currentCamera;
        
        private void Awake()
        {
            menuCamera = new MenuCamera(_animator);
            inGameCamera = new InGameCamera(_animator);
            winCamera = new WinCamera(_animator);
        }
        
        public void SwichCamera(BaseMode<Animator> i_baseUI)
        {
            _currentCamera?.Off();
            _currentCamera = i_baseUI;
            _currentCamera?.On();
        }
    }
}