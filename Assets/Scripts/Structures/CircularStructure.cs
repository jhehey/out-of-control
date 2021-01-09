using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Structures
{
	public class CircularStructure: Structure
	{
		[Range(10, 20, order = 1)]
		public int radius;

		public override void Spawn()
		{
			float arc = 0.8f;
			float inc = 360 * arc / circumference(radius);

			for(float angle = 0; angle < 360; angle += inc)
			{
				float radians = angle * Mathf.Deg2Rad;
				Vector2 position = new Vector2(radius * Mathf.Cos(radians), radius * Mathf.Sin(radians));
				CreateCell(position);
			}
		}

		private float circumference(float radius)
		{
			return 2 * Mathf.PI * radius;
		}
	}
}
