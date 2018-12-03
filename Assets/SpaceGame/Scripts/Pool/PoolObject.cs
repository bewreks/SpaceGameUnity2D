using UnityEngine;

namespace SpaceGame.Scripts.Pool {
    public class PoolObject : MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}