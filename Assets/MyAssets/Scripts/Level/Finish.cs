using UnityEngine;

namespace Test_Project
{
    public class Finish : MonoBehaviour
    {
        public Transform playerMovePoint => _playerMovePoint;
        public Transform playerOnFinishPoint => _playerOnFinishPoint;
        
        [SerializeField] private Transform _playerMovePoint;
        [SerializeField] private Transform _playerOnFinishPoint;
    }
}