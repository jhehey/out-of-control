using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Structures
{
	public abstract class Structure: MonoBehaviour
	{
		public int itemRotation;
		public abstract void Spawn();

		public virtual void CreateCell(Vector2 position)
		{
			GameObject newObj = Instantiate(Prefabs.Instance.BasicTarget);
			newObj.transform.parent = this.transform;
			newObj.transform.position = position;
			newObj.transform.rotation = Quaternion.Euler(0, 0, itemRotation);
		}
	}
}
