
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeVariable : Variable<UnityEngine.ParticleSystemColliderQueryMode>
	{
		
		public ParticleSystemColliderQueryModeVariable()
		{
		}
		
		public ParticleSystemColliderQueryModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeListVariable : ListVariable<UnityEngine.ParticleSystemColliderQueryMode>
	{
		
		public ParticleSystemColliderQueryModeListVariable()
		{
		}
		
		public ParticleSystemColliderQueryModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeRef : VariableRef<UnityEngine.ParticleSystemColliderQueryMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeVar : VariableVar<UnityEngine.ParticleSystemColliderQueryMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeListRef : ListVariableRef<UnityEngine.ParticleSystemColliderQueryMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemColliderQueryMode))]
	public sealed partial class ParticleSystemColliderQueryModeListVar : ListVariableVar<UnityEngine.ParticleSystemColliderQueryMode>
	{
	}
}
