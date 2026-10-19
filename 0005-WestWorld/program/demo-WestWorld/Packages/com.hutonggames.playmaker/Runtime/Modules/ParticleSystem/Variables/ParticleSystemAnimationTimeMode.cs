
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeVariable : Variable<UnityEngine.ParticleSystemAnimationTimeMode>
	{
		
		public ParticleSystemAnimationTimeModeVariable()
		{
		}
		
		public ParticleSystemAnimationTimeModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeListVariable : ListVariable<UnityEngine.ParticleSystemAnimationTimeMode>
	{
		
		public ParticleSystemAnimationTimeModeListVariable()
		{
		}
		
		public ParticleSystemAnimationTimeModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeRef : VariableRef<UnityEngine.ParticleSystemAnimationTimeMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeVar : VariableVar<UnityEngine.ParticleSystemAnimationTimeMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeListRef : ListVariableRef<UnityEngine.ParticleSystemAnimationTimeMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationTimeMode))]
	public sealed partial class ParticleSystemAnimationTimeModeListVar : ListVariableVar<UnityEngine.ParticleSystemAnimationTimeMode>
	{
	}
}
