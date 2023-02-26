using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;

namespace Test_Project
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _visual;
        [SerializeField] private float _shootSpeed = 2;
        [SerializeField] private Collider _enemyDetectCollider;


        private float _detectRadius = 0;
        private LayerMask _layerMask;
        private LevelManager _levelManager;
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private void OnEnable()
        {
            _enemyDetectCollider.OnTriggerEnterAsObservable().Where(c => c.gameObject.layer == MyStatics.ENEMY_LAYER)
                .Subscribe(_ =>
                {
                    DetectEnemy();
                    _compositeDisposable.Clear();
                }).AddTo(_compositeDisposable);
        }

        public void Init(float i_scaleValue, Vector3 i_bulletTarget, LevelManager i_levelManager,
            LayerMask i_detectLayer, float i_detectRadiusIncrenet)
        {
            _levelManager = i_levelManager;
            _layerMask = i_detectLayer;
            _visual.localScale = Vector3.one * i_scaleValue;
            _detectRadius = i_scaleValue * i_detectRadiusIncrenet;

            transform.DOMove(i_bulletTarget, _shootSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
        }

        void DetectEnemy()
        {
            transform.DOKill();
            Collider[] colliders = Physics.OverlapSphere(transform.position, _detectRadius, _layerMask);
            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    Enemy enemy = _levelManager.currentLevel.GetEnemyRef(colliders[i].gameObject);
                    enemy?.TakeDamage();
                }
            }

            Destroy(this.gameObject);
        }
    }
}