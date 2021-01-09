using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runes
{
	public class Rune: ParticleEntity
	{
		public virtual int damage { get; set; } = 1;

		protected virtual void Activate() { }

		protected void OnTriggerEnter2D(Collider2D collision)
		{
			Projectile projectile = collision.gameObject.GetComponent<Projectile>();
			if(projectile != null)
			{
				Hide();
				projectile.Die();
				Activate();
				if(hasParticle) particleController.Activate();
			}
		}
	}
}
