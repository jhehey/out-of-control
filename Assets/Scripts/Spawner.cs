using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Spawner: MonoBehaviour
	{
		public GameObject prefab;
		public float spawnRadius = 10f;
		public float spawnIntervalMs = 2000f;

		protected virtual void Spawn()
		{
			GameObject newObj = Instantiate(prefab);
			newObj.transform.parent = this.transform;

			Vector2 playerPos = Player.Instance.transform.position;
			Vector2 randomPos = (Random.insideUnitCircle * spawnRadius) + playerPos;
			newObj.transform.position = randomPos;
		}

		private void Start()
		{
			StartCoroutine(SpawnEnumerator());
		}

		protected virtual IEnumerator SpawnEnumerator()
		{
			while (true)
			{
				Spawn();
				yield return new WaitForSeconds(spawnIntervalMs / 1000f);
			}
		}
	}
}
