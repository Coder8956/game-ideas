
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Does this system support Procedural Simulation?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem-proceduralSimulationSuppo" +
		"rted.html")]
	public sealed class ParticleSystemGetProceduralSimulationSupported : BaseAction
	{
		
		[Tooltip("The ParticleSystem")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("Get ParticleSystem Procedural Simulation Supported")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getProceduralSimulationSupported;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _getProceduralSimulationSupported);
		}
		
		public override void Execute()
		{
			_getProceduralSimulationSupported.Value = _particleSystem.Value.proceduralSimulationSupported;
		}
		
		public override string GetSummary()
		{
			return "Get {_particleSystem} procedural simulation supported -> {_getProceduralSimulationSupported}";
		}
	}
}
