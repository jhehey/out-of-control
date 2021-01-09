using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runes
{
	public class PowershotRune: Rune
	{
		private GameObject previousProjectile;
		private Coroutine coroutine;

		//TODO: May timer yung power shot
		// TODO: Tumatagos, hindi agad mamamatay
		// TODO: yung coroutine per second nalang, then mag update yung timer nya or something
		protected override void Activate()
		{
			base.Activate();
			previousProjectile = Player.Instance.currentProjectile;
			Player.Instance.currentProjectile = Prefabs.Instance.PowershotProjectile;


			if(coroutine != null)
			{
				StopCoroutine(coroutine);
			}

			coroutine = StartCoroutine(RevertProjectile());
		}

		private IEnumerator RevertProjectile()
		{
			yield return new WaitForSeconds(3);
			Player.Instance.currentProjectile = Prefabs.Instance.BasicBulletProjectile;
			coroutine = null;
		}
	}
}
