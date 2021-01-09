using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class ParticleController: MonoBehaviour
	{
		public EventHandler OnParticleStopped { get; set; }

		public void Activate()
		{
			gameObject.SetActive(true);
			myParticle.Play();
		}

		protected Collider2D myCollider { get; set; }
		protected ParticleSystem myParticle { get; set; }
		private void Start()
		{
			myCollider = GetComponentInChildren<Collider2D>();
			myParticle = GetComponentInChildren<ParticleSystem>();

			var mainParticle = myParticle.main;
			mainParticle.stopAction = ParticleSystemStopAction.Callback;

			gameObject.SetActive(false);
		}

		private void OnParticleSystemStopped()
		{
			gameObject.SetActive(false);
			OnParticleStopped(this, new EventArgs());
		}
	}
}
