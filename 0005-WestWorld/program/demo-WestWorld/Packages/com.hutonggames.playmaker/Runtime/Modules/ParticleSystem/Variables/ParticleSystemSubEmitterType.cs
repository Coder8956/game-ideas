
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeVariable : Variable<UnityEngine.ParticleSystemSubEmitterType>
	{
		
		public ParticleSystemSubEmitterTypeVariable()
		{
		}
		
		public ParticleSystemSubEmitterTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeListVariable : ListVariable<UnityEngine.ParticleSystemSubEmitterType>
	{
		
		public ParticleSystemSubEmitterTypeListVariable()
		{
		}
		
		public ParticleSystemSubEmitterTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeRef : VariableRef<UnityEngine.ParticleSystemSubEmitterType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeVar : VariableVar<UnityEngine.ParticleSystemSubEmitterType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeListRef : ListVariableRef<UnityEngine.ParticleSystemSubEmitterType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterType))]
	public sealed partial class ParticleSystemSubEmitterTypeListVar : ListVariableVar<UnityEngine.ParticleSystemSubEmitterType>
	{
	}
}
