using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class BaseEntity : MonoBehaviour
	{
		public virtual void Die()
		{
			Destroy(this.gameObject);
		}

		protected virtual void Hide()
		{
			mySprite.enabled = false;
			myCollider.enabled = false;
		}

		protected Collider2D myCollider { get; set; }
		protected SpriteRenderer mySprite { get; set; }
		protected virtual void Start()
		{
			myCollider = GetComponent<Collider2D>();
			mySprite = GetComponent<SpriteRenderer>();
		}
	}
}
