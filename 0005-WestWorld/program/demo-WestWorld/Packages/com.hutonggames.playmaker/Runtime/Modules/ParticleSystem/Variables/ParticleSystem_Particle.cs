
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleVariable : Variable<UnityEngine.ParticleSystem.Particle>
	{
		
		public ParticleSystem_ParticleVariable()
		{
		}
		
		public ParticleSystem_ParticleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleListVariable : ListVariable<UnityEngine.ParticleSystem.Particle>
	{
		
		public ParticleSystem_ParticleListVariable()
		{
		}
		
		public ParticleSystem_ParticleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleRef : VariableRef<UnityEngine.ParticleSystem.Particle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleVar : VariableVar<UnityEngine.ParticleSystem.Particle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleListRef : ListVariableRef<UnityEngine.ParticleSystem.Particle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.Particle))]
	public sealed partial class ParticleSystem_ParticleListVar : ListVariableVar<UnityEngine.ParticleSystem.Particle>
	{
	}
}
