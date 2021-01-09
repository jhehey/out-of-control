using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Structures
{
	public class EdgeStructure: QuadStructure
	{
		public override void Spawn()
		{
			for(int c = 0; c < width; c++)
			{
				CreateCell(new Vector2(c * spacing, 0));
			}

			for (int r = 0; r < height; r++)
			{
				CreateCell(new Vector2(0, r * spacing));
				CreateCell(new Vector2((width - 1) * spacing, r * spacing));
			}

			for (int c = 0; c < width; c++)
			{
				CreateCell(new Vector2(c * spacing, (height - 1) * spacing));
			}
		}
	}
}
