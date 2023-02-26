using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Windows.Input;

namespace Test_Project
{
    public  class PlayerActiveState : BaseState<Player>
    {
        private readonly PlayerStatesComponents.ActiveComponents _activeStateComponents;
        private readonly LevelManager _levelManager;

        
        private float _initScaleValue;
        
        public PlayerActiveState(Player i_main,
            PlayerStatesComponents.ActiveComponents i_activeStateComponents,
            LevelManager i_levelManager) : base(i_main)
        {
            _activeStateComponents = i_activeStateComponents;
            _levelManager = i_levelManager;
        }

        public override void Enter()
        {
            _initScaleValue = _activeStateComponents.playerVisual.localScale.x;
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
            _activeStateComponents.playerVisual.localScale -= Vector3.one * (_activeStateComponents.playerData.scaleTime * Time.deltaTime);
            _levelManager.currentLevel.LevelPath.SetScale(_activeStateComponents.playerVisual.localScale.x);
            
            if (_activeStateComponents.playerVisual.localScale.x <= _activeStateComponents.playerData.minScaleValue)
            {
                _main.playerStateMachine.SwichState(_main.playerStateMachine.playerDeathState);
            }
        }

        private void Shoot()
        {
            float currentScaleValue = _activeStateComponents.playerVisual.localScale.x;
            
            Bullet bullet = GameObject.Instantiate(_activeStateComponents.playerData.bulletPref, 
                _main.transform.position, quaternion.identity);
            
            float scale = _initScaleValue - currentScaleValue;
            
            bullet.Init(scale,_levelManager.currentLevel.bulletTarget,_levelManager,
                _activeStateComponents.playerData.enemylayer,_activeStateComponents.playerData.enemyDetectRadiusIncrement);
            
            _initScaleValue = _activeStateComponents.playerVisual.localScale.x;
        }
    }
}