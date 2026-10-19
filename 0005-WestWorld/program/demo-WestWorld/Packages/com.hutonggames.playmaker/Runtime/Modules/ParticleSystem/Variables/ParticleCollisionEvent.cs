
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventVariable : Variable<UnityEngine.ParticleCollisionEvent>
	{
		
		public ParticleCollisionEventVariable()
		{
		}
		
		public ParticleCollisionEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventListVariable : ListVariable<UnityEngine.ParticleCollisionEvent>
	{
		
		public ParticleCollisionEventListVariable()
		{
		}
		
		public ParticleCollisionEventListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventRef : VariableRef<UnityEngine.ParticleCollisionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventVar : VariableVar<UnityEngine.ParticleCollisionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventListRef : ListVariableRef<UnityEngine.ParticleCollisionEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleCollisionEvent))]
	public sealed partial class ParticleCollisionEventListVar : ListVariableVar<UnityEngine.ParticleCollisionEvent>
	{
	}
}
