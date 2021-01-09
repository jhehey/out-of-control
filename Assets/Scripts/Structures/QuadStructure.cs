using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Structures
{
	public class QuadStructure : Structure
	{
		public int width;
		public int height;
		public float spacing;

		public override void Spawn()
		{
			for(int c = 0; c < width; c ++)
			{
				for(int r = 0; r < height; r++)
				{
					Vector2 position = new Vector2(c*spacing, r*spacing);
					CreateCell(position);
				}
			}
		}
	}
}
