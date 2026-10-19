
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Particles)]
	[ActionDescription("Limits the amount of graphics memory Unity reserves for efficient rendering of Pa" +
		"rticle Systems.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ParticleSystem.SetMaximumPreMappedBuffer" +
		"Counts.html")]
	public sealed class ParticleSystemSetMaximumPreMappedBufferCounts : BaseAction
	{
		
		[Tooltip("The maximum number of cached vertex buffers.")]
		[SerializeField]
		private IntegerVar _vertexBuffersCount;
		
		[Tooltip("The maximum number of cached index buffers.")]
		[SerializeField]
		private IntegerVar _indexBuffersCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vertexBuffersCount, _indexBuffersCount);
		}
		
		public override void Execute()
		{
			//UnityEngine.ParticleSystem.SetMaximumPreMappedBufferCounts(System.Int32, System.Int32);
			UnityEngine.ParticleSystem.SetMaximumPreMappedBufferCounts(_vertexBuffersCount.Value, _indexBuffersCount.Value);
		}
		
		public override string GetSummary()
		{
			return "Set ParticleSystem maximum pre-mapped buffer counts {_vertexBuffersCount} {_indexBuffersCount}";
		}
	}
}
