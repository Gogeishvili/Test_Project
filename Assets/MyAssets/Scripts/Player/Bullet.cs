using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Test_Project
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _visual;

        
        public void Init(float i_scaleValue)
        {
            _visual.localScale = Vector3.one * i_scaleValue;
            transform.DOMove(transform.position + Vector3.forward * 10, 2f);
           
        }
    }
}