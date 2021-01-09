using Assets.Scripts.Runes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class Projectile: BaseEntity
	{
		public virtual float projectileSpeed { get; set; } = 30f;
		public virtual int damage { get; set; } = 1;

		public void Shoot(GameObject shooter, Vector2 direction)
		{
			rb.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
		}

		protected Rigidbody2D rb { get; private set; }
		protected virtual void Awake()
		{
			rb = rb ?? GetComponent<Rigidbody2D>();
		}
	}
}
