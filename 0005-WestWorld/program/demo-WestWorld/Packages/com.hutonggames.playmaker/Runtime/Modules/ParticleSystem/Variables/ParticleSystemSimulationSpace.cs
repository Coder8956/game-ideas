
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceVariable : Variable<UnityEngine.ParticleSystemSimulationSpace>
	{
		
		public ParticleSystemSimulationSpaceVariable()
		{
		}
		
		public ParticleSystemSimulationSpaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceListVariable : ListVariable<UnityEngine.ParticleSystemSimulationSpace>
	{
		
		public ParticleSystemSimulationSpaceListVariable()
		{
		}
		
		public ParticleSystemSimulationSpaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceRef : VariableRef<UnityEngine.ParticleSystemSimulationSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceVar : VariableVar<UnityEngine.ParticleSystemSimulationSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceListRef : ListVariableRef<UnityEngine.ParticleSystemSimulationSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemSimulationSpace))]
	public sealed partial class ParticleSystemSimulationSpaceListVar : ListVariableVar<UnityEngine.ParticleSystemSimulationSpace>
	{
	}
}
