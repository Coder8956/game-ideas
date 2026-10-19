
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeVariable : Variable<UnityEngine.ParticleSystemCustomDataMode>
	{
		
		public ParticleSystemCustomDataModeVariable()
		{
		}
		
		public ParticleSystemCustomDataModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeListVariable : ListVariable<UnityEngine.ParticleSystemCustomDataMode>
	{
		
		public ParticleSystemCustomDataModeListVariable()
		{
		}
		
		public ParticleSystemCustomDataModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeRef : VariableRef<UnityEngine.ParticleSystemCustomDataMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeVar : VariableVar<UnityEngine.ParticleSystemCustomDataMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeListRef : ListVariableRef<UnityEngine.ParticleSystemCustomDataMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomDataMode))]
	public sealed partial class ParticleSystemCustomDataModeListVar : ListVariableVar<UnityEngine.ParticleSystemCustomDataMode>
	{
	}
}
