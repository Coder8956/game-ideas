
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeVariable : Variable<UnityEngine.ParticleSystemCollisionType>
	{
		
		public ParticleSystemCollisionTypeVariable()
		{
		}
		
		public ParticleSystemCollisionTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeListVariable : ListVariable<UnityEngine.ParticleSystemCollisionType>
	{
		
		public ParticleSystemCollisionTypeListVariable()
		{
		}
		
		public ParticleSystemCollisionTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeRef : VariableRef<UnityEngine.ParticleSystemCollisionType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeVar : VariableVar<UnityEngine.ParticleSystemCollisionType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeListRef : ListVariableRef<UnityEngine.ParticleSystemCollisionType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionType))]
	public sealed partial class ParticleSystemCollisionTypeListVar : ListVariableVar<UnityEngine.ParticleSystemCollisionType>
	{
	}
}
