
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeVariable : Variable<UnityEngine.ParticleSystemCollisionMode>
	{
		
		public ParticleSystemCollisionModeVariable()
		{
		}
		
		public ParticleSystemCollisionModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeListVariable : ListVariable<UnityEngine.ParticleSystemCollisionMode>
	{
		
		public ParticleSystemCollisionModeListVariable()
		{
		}
		
		public ParticleSystemCollisionModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeRef : VariableRef<UnityEngine.ParticleSystemCollisionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeVar : VariableVar<UnityEngine.ParticleSystemCollisionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeListRef : ListVariableRef<UnityEngine.ParticleSystemCollisionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionMode))]
	public sealed partial class ParticleSystemCollisionModeListVar : ListVariableVar<UnityEngine.ParticleSystemCollisionMode>
	{
	}
}
