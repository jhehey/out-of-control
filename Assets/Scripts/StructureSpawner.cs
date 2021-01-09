using Assets.Scripts.Structures;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class StructureSpawner: Spawner
	{
		public Structure structure;

		protected override void Spawn()
		{
			GameObject newObj = Instantiate(structure.gameObject);
			newObj.transform.parent = this.transform;

			Vector2 playerPos = Player.Instance.transform.position;
			Vector2 randomPos = (Random.insideUnitCircle * spawnRadius) + playerPos;
			newObj.transform.position = randomPos;

			Structure newStructure = newObj.GetComponent<Structure>();
			newStructure.Spawn();
		}

		protected override IEnumerator SpawnEnumerator()
		{
			Spawn();
			yield return null;
		}
	}
}
