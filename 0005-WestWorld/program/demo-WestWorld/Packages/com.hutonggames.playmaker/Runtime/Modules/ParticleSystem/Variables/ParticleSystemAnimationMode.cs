
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeVariable : Variable<UnityEngine.ParticleSystemAnimationMode>
	{
		
		public ParticleSystemAnimationModeVariable()
		{
		}
		
		public ParticleSystemAnimationModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeListVariable : ListVariable<UnityEngine.ParticleSystemAnimationMode>
	{
		
		public ParticleSystemAnimationModeListVariable()
		{
		}
		
		public ParticleSystemAnimationModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeRef : VariableRef<UnityEngine.ParticleSystemAnimationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeVar : VariableVar<UnityEngine.ParticleSystemAnimationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeListRef : ListVariableRef<UnityEngine.ParticleSystemAnimationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationMode))]
	public sealed partial class ParticleSystemAnimationModeListVar : ListVariableVar<UnityEngine.ParticleSystemAnimationMode>
	{
	}
}
