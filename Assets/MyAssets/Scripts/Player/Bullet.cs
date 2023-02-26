using System;
using DG.Tweening;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

namespace Test_Project
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _visual;
        [SerializeField] private float _shootSpeed = 2;
        [SerializeField] private Collider _enemyDetectCollider;


        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        private void OnEnable()
        {
            _enemyDetectCollider.OnTriggerEnterAsObservable().
                Where(c => c.gameObject.layer == MyStatics.ENEMY_LAYER)
                .Subscribe( _=>
                {
                    DetectEnemy();
                    
                    _compositeDisposable.Clear();
                }).AddTo(_compositeDisposable);
        }

        public void Init(float i_scaleValue,Vector3 i_bulletTarget,LevelManager i_levelManager)
        {
            _visual.localScale = Vector3.one * i_scaleValue;
            transform.DOMove(i_bulletTarget, _shootSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
        }

        void DetectEnemy()
        {
            transform.DOKill();
            
            
            Destroy(this.gameObject);
        }
       
    }
}