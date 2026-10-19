
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Determines whether the Particle System rotates its particles around only the Z ax" +
		"is, or whether the system specifies separate values for the X, Y and Z axes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-has3DParticleRotations.ht" +
		"ml")]
	public sealed class ParticleSystemGetHas3DParticleRotations : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Has 3D Particle Rotations")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHas3DParticleRotations;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getHas3DParticleRotations);
		}
		
		public override void Execute()
		{
			_getHas3DParticleRotations.Value = _particleSystem.Value.has3DParticleRotations;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} has 3D particle rotations -> {_getHas3DParticleRotations}";
		}
	}
}
