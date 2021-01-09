using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class PowershotProjectile: Projectile
	{
		public override float projectileSpeed { get; set; } = 50f;

		public override void Die()
		{
			//base.Die();
			// wait 2 seconds, before dying
			StartCoroutine(DieAfterTime());
		}

		private IEnumerator DieAfterTime()
		{
			yield return new WaitForSeconds(2);
			base.Die();
		}
	}
}
