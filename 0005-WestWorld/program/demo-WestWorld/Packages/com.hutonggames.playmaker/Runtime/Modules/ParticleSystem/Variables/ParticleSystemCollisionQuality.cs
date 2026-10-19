
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityVariable : Variable<UnityEngine.ParticleSystemCollisionQuality>
	{
		
		public ParticleSystemCollisionQualityVariable()
		{
		}
		
		public ParticleSystemCollisionQualityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityListVariable : ListVariable<UnityEngine.ParticleSystemCollisionQuality>
	{
		
		public ParticleSystemCollisionQualityListVariable()
		{
		}
		
		public ParticleSystemCollisionQualityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityRef : VariableRef<UnityEngine.ParticleSystemCollisionQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityVar : VariableVar<UnityEngine.ParticleSystemCollisionQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityListRef : ListVariableRef<UnityEngine.ParticleSystemCollisionQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCollisionQuality))]
	public sealed partial class ParticleSystemCollisionQualityListVar : ListVariableVar<UnityEngine.ParticleSystemCollisionQuality>
	{
	}
}
