
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeVariable : Variable<UnityEngine.ParticleSystemSortMode>
	{
		
		public ParticleSystemSortModeVariable()
		{
		}
		
		public ParticleSystemSortModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeListVariable : ListVariable<UnityEngine.ParticleSystemSortMode>
	{
		
		public ParticleSystemSortModeListVariable()
		{
		}
		
		public ParticleSystemSortModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeRef : VariableRef<UnityEngine.ParticleSystemSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeVar : VariableVar<UnityEngine.ParticleSystemSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeListRef : ListVariableRef<UnityEngine.ParticleSystemSortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSortMode))]
	public sealed partial class ParticleSystemSortModeListVar : ListVariableVar<UnityEngine.ParticleSystemSortMode>
	{
	}
}
