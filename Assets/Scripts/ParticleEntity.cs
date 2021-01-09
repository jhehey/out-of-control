using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
	public class ParticleEntity: BaseEntity
	{
		public bool hasParticle { get; set; } = false;
		protected ParticleController particleController { get; set; }
		protected override void Start()
		{
			base.Start();
			particleController = GetComponentInChildren<ParticleController>();
			if(particleController != null)
			{
				particleController.OnParticleStopped += HandleParticleStopped;
				hasParticle = true;
			}
		}

		private void HandleParticleStopped(object sender, EventArgs e)
		{
			Die();
		}
	}
}
