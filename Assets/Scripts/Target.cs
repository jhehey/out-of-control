using Assets.Scripts.Runes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
	public class Target : ParticleEntity
	{
		public virtual int health { get; set; } = 1;

		public void Hit(int damage)
		{
			health -= damage;
			if (health <= 0)
			{
				Hide();
				particleController.Activate();
			}
			Debug.Log("Hit: " + health + ":" + damage);
		}

		protected void OnTriggerEnter2D(Collider2D collision)
		{
			Projectile projectile = collision.gameObject.GetComponent<Projectile>();
			if (projectile != null)
			{
				Hit(projectile.damage);
				projectile.Die();
			}

			Rune rune = collision.gameObject.GetComponentInParent<Rune>();
			if(rune != null)
			{
				Hit(rune.damage);
			}
		}
	}
}