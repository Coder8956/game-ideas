
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterVariable : Variable<UnityEngine.ParticleSystemGameObjectFilter>
	{
		
		public ParticleSystemGameObjectFilterVariable()
		{
		}
		
		public ParticleSystemGameObjectFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterListVariable : ListVariable<UnityEngine.ParticleSystemGameObjectFilter>
	{
		
		public ParticleSystemGameObjectFilterListVariable()
		{
		}
		
		public ParticleSystemGameObjectFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterRef : VariableRef<UnityEngine.ParticleSystemGameObjectFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterVar : VariableVar<UnityEngine.ParticleSystemGameObjectFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterListRef : ListVariableRef<UnityEngine.ParticleSystemGameObjectFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGameObjectFilter))]
	public sealed partial class ParticleSystemGameObjectFilterListVar : ListVariableVar<UnityEngine.ParticleSystemGameObjectFilter>
	{
	}
}
