
using UnityEngine;
using DG.Tweening;

namespace Test_Project
{
    public class EnemyFracture : MonoBehaviour
    {
        private Vector3 _initLocalPosition; 
        
        private void Awake()
        {
            _initLocalPosition = transform.localPosition;
        }

        public void ExplosionEffect()
        {
            gameObject.SetActive(true);
            Vector3 dropPoint = new Vector3(transform.localPosition.x + Random.Range(-0.5f, 0.5f), 
                0, transform.localPosition.z+Random.Range(-0.5f, 0.5f));
            transform.DOLocalJump(dropPoint, 3, 1, 0.35f).SetEase(Ease.Linear);
        }

        public void ResetEnemyFracture()
        {
            gameObject.SetActive(false);
            transform.localPosition = _initLocalPosition;
        }
    }
}