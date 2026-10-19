
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityVariable : Variable<UnityEngine.ParticleSystemNoiseQuality>
	{
		
		public ParticleSystemNoiseQualityVariable()
		{
		}
		
		public ParticleSystemNoiseQualityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityListVariable : ListVariable<UnityEngine.ParticleSystemNoiseQuality>
	{
		
		public ParticleSystemNoiseQualityListVariable()
		{
		}
		
		public ParticleSystemNoiseQualityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityRef : VariableRef<UnityEngine.ParticleSystemNoiseQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityVar : VariableVar<UnityEngine.ParticleSystemNoiseQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityListRef : ListVariableRef<UnityEngine.ParticleSystemNoiseQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemNoiseQuality))]
	public sealed partial class ParticleSystemNoiseQualityListVar : ListVariableVar<UnityEngine.ParticleSystemNoiseQuality>
	{
	}
}
