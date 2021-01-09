using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class Prefabs: MonoBehaviour
	{
		[Header("Targets")]
		public GameObject BasicTarget;

		[Header("Projectiles")]
		public GameObject BasicBulletProjectile;
		public GameObject PowershotProjectile;

		private static Prefabs instance;
		public static Prefabs Instance
		{
			get
			{
				if (instance == null)
				{
					instance = GameObject.FindGameObjectWithTag("Prefabs").gameObject.GetComponent<Prefabs>();
					Debug.Log(instance.gameObject.name);
				}
				return instance;
			}
		}
	}
}
