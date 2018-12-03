using UnityEngine;

namespace SpaceGame.Scripts.Pool {
	public class PoolSetup : MonoBehaviour { //обертка для управления статическим классом PoolManager
	
		[SerializeField] private PoolManager.PoolPart[] pools;

		void OnValidate() {
			for (int i = 0; i < pools.Length; i++) {
				pools[i].key  = pools[i].key;
				pools[i].name = pools[i].key.ToString();
			}
		}

		void Awake() {
			Initialize ();
		}

		void Initialize () {
			PoolManager.Initialize(pools);
		}
	}
}