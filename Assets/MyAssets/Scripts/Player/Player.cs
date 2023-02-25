
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;


namespace Test_Project
{
    public class Player : MonoBehaviour
    {
        
        [SerializeField] private Transform _visual;
        [SerializeField] private PlayerData _playerData;
        
        private Vector3 _initScale;
        private PlayerStateMachine _playerStateMachine;

        private void Awake()
        {
           // _initScaleValue =_visual.localScale.x;
            _playerStateMachine = new PlayerStateMachine(this);
            
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                //_visual.localScale -= Vector3.one * (_scaleTime * Time.deltaTime);
            }

            if (Input.GetMouseButtonUp(0))
            {
                // float currentScaleValue = _visual.localScale.x;
                // Bullet bullet = Instantiate(_bulletPref, transform.position, quaternion.identity);
                // float scale = _initScaleValue - currentScaleValue;
                // bullet.transform.localScale = new Vector3(scale, scale, scale);
                // _initScaleValue = _visual.localScale.x;
            }
            
          _playerStateMachine.currentState.Update();
        }

        [Button]
        public void ActiveState()
        {
            _playerStateMachine.SwichState(_playerStateMachine.playerActiveState);
        }
        
    }
}