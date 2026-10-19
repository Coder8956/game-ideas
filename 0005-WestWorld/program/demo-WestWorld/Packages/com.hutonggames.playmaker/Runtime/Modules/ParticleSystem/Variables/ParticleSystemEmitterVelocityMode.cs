
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeVariable : Variable<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
		
		public ParticleSystemEmitterVelocityModeVariable()
		{
		}
		
		public ParticleSystemEmitterVelocityModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeListVariable : ListVariable<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
		
		public ParticleSystemEmitterVelocityModeListVariable()
		{
		}
		
		public ParticleSystemEmitterVelocityModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeRef : VariableRef<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeVar : VariableVar<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeListRef : ListVariableRef<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemEmitterVelocityMode))]
	public sealed partial class ParticleSystemEmitterVelocityModeListVar : ListVariableVar<UnityEngine.ParticleSystemEmitterVelocityMode>
	{
	}
}
