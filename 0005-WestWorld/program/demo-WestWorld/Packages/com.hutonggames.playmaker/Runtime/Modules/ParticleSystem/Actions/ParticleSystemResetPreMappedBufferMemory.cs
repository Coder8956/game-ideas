
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Reset the cache of reserved graphics memory used for efficient rendering of Parti" +
		"cle Systems.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.ResetPreMappedBufferMemory.html")]
	public sealed class ParticleSystemResetPreMappedBufferMemory : BaseAction
	{
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.ResetPreMappedBufferMemory();
			UnityEngine.ParticleSystem.ResetPreMappedBufferMemory();
		}
		
		public override string GetSummary()
		{
			return "Reset ParticleSystem pre-mapped buffer memory";
		}
	}
}
