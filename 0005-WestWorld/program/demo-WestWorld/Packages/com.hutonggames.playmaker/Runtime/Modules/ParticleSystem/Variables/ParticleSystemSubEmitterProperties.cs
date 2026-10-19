
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesVariable : Variable<UnityEngine.ParticleSystemSubEmitterProperties>
	{
		
		public ParticleSystemSubEmitterPropertiesVariable()
		{
		}
		
		public ParticleSystemSubEmitterPropertiesVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesListVariable : ListVariable<UnityEngine.ParticleSystemSubEmitterProperties>
	{
		
		public ParticleSystemSubEmitterPropertiesListVariable()
		{
		}
		
		public ParticleSystemSubEmitterPropertiesListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesRef : VariableRef<UnityEngine.ParticleSystemSubEmitterProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesVar : VariableVar<UnityEngine.ParticleSystemSubEmitterProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesListRef : ListVariableRef<UnityEngine.ParticleSystemSubEmitterProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSubEmitterProperties))]
	public sealed partial class ParticleSystemSubEmitterPropertiesListVar : ListVariableVar<UnityEngine.ParticleSystemSubEmitterProperties>
	{
	}
}
