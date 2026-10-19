
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionVariable : Variable<UnityEngine.ParticleSystemMeshDistribution>
	{
		
		public ParticleSystemMeshDistributionVariable()
		{
		}
		
		public ParticleSystemMeshDistributionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionListVariable : ListVariable<UnityEngine.ParticleSystemMeshDistribution>
	{
		
		public ParticleSystemMeshDistributionListVariable()
		{
		}
		
		public ParticleSystemMeshDistributionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionRef : VariableRef<UnityEngine.ParticleSystemMeshDistribution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionVar : VariableVar<UnityEngine.ParticleSystemMeshDistribution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionListRef : ListVariableRef<UnityEngine.ParticleSystemMeshDistribution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshDistribution))]
	public sealed partial class ParticleSystemMeshDistributionListVar : ListVariableVar<UnityEngine.ParticleSystemMeshDistribution>
	{
	}
}
