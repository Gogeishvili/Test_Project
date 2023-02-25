using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Windows.Input;

namespace Test_Project
{
    public  class PlayerActiveState : BaseState<Player>
    {
        private StatesComponents.ActiveComponents _activeStateComponents;

        private float _initScaleValue;
        
        public PlayerActiveState(Player i_main,
            StatesComponents.ActiveComponents i_activeStateComponents ) : base(i_main)
        {
            _activeStateComponents = i_activeStateComponents;
        }

        public override void Enter()
        {
            _initScaleValue = _activeStateComponents.visual.localScale.x;
        }

        public override void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                GenerateBullet();
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                Shoot();
            }
        }

        public override void Exit()
        {
           
        }

        private void GenerateBullet()
        {
            _activeStateComponents.visual.localScale -= Vector3.one * (_activeStateComponents.playerData.scaleTime * Time.deltaTime);
            if (_activeStateComponents.visual.localScale.x <= _activeStateComponents.playerData.minScaleValue)
            {
                _main.playerStateMachine.SwichState(_main.playerStateMachine.playerDeathState);
            }
        }

        private void Shoot()
        {
            float currentScaleValue = _activeStateComponents.visual.localScale.x;
            Bullet bullet = GameObject.Instantiate(_activeStateComponents.playerData.bulletPref, 
                _main.transform.position, quaternion.identity);
            float scale = _initScaleValue - currentScaleValue;
            bullet.Init(scale);
            _initScaleValue = _activeStateComponents.visual.localScale.x;
        }
    }
}