
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Set a stream of custom per-particle data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.SetCustomParticleData.htm" +
		"l")]
	public sealed class ParticleSystemSetCustomParticleData : BaseAction
	{
		
		[Tooltip("The ParticleSystem.")]
		[SerializeField]
		private ParticleSystemVar _particleSystem;
		
		[Tooltip("The array of per-particle data.")]
		[SerializeField]
		private Vector4ListVar _customData;
		
		[Tooltip("Which stream to assign the data to.")]
		[SerializeField]
		private ParticleSystemCustomDataVar _streamIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_particleSystem, _customData, _streamIndex);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.SetCustomParticleData(System.Collections.Generic.List`1[[UnityEngine.Vector4, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]], UnityEngine.ParticleSystemCustomData);
			_particleSystem.Value.SetCustomParticleData(_customData.Value, _streamIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_particleSystem} custom particle data {_customData} {_streamIndex}";
		}
	}
}
