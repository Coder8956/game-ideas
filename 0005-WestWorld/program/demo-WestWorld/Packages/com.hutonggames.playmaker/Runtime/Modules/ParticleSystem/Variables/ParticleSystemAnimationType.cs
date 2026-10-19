
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeVariable : Variable<UnityEngine.ParticleSystemAnimationType>
	{
		
		public ParticleSystemAnimationTypeVariable()
		{
		}
		
		public ParticleSystemAnimationTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeListVariable : ListVariable<UnityEngine.ParticleSystemAnimationType>
	{
		
		public ParticleSystemAnimationTypeListVariable()
		{
		}
		
		public ParticleSystemAnimationTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeRef : VariableRef<UnityEngine.ParticleSystemAnimationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeVar : VariableVar<UnityEngine.ParticleSystemAnimationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeListRef : ListVariableRef<UnityEngine.ParticleSystemAnimationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationType))]
	public sealed partial class ParticleSystemAnimationTypeListVar : ListVariableVar<UnityEngine.ParticleSystemAnimationType>
	{
	}
}
