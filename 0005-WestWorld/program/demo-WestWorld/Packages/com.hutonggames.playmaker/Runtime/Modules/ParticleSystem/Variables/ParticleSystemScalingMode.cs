
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeVariable : Variable<UnityEngine.ParticleSystemScalingMode>
	{
		
		public ParticleSystemScalingModeVariable()
		{
		}
		
		public ParticleSystemScalingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeListVariable : ListVariable<UnityEngine.ParticleSystemScalingMode>
	{
		
		public ParticleSystemScalingModeListVariable()
		{
		}
		
		public ParticleSystemScalingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeRef : VariableRef<UnityEngine.ParticleSystemScalingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeVar : VariableVar<UnityEngine.ParticleSystemScalingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeListRef : ListVariableRef<UnityEngine.ParticleSystemScalingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemScalingMode))]
	public sealed partial class ParticleSystemScalingModeListVar : ListVariableVar<UnityEngine.ParticleSystemScalingMode>
	{
	}
}
