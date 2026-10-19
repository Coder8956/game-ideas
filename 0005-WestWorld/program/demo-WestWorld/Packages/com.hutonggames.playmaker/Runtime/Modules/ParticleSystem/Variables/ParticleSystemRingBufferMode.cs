
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeVariable : Variable<UnityEngine.ParticleSystemRingBufferMode>
	{
		
		public ParticleSystemRingBufferModeVariable()
		{
		}
		
		public ParticleSystemRingBufferModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeListVariable : ListVariable<UnityEngine.ParticleSystemRingBufferMode>
	{
		
		public ParticleSystemRingBufferModeListVariable()
		{
		}
		
		public ParticleSystemRingBufferModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeRef : VariableRef<UnityEngine.ParticleSystemRingBufferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeVar : VariableVar<UnityEngine.ParticleSystemRingBufferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeListRef : ListVariableRef<UnityEngine.ParticleSystemRingBufferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRingBufferMode))]
	public sealed partial class ParticleSystemRingBufferModeListVar : ListVariableVar<UnityEngine.ParticleSystemRingBufferMode>
	{
	}
}
