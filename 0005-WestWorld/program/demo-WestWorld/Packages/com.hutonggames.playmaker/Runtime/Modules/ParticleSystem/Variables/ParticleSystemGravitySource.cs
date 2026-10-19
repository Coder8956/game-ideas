
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceVariable : Variable<UnityEngine.ParticleSystemGravitySource>
	{
		
		public ParticleSystemGravitySourceVariable()
		{
		}
		
		public ParticleSystemGravitySourceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceListVariable : ListVariable<UnityEngine.ParticleSystemGravitySource>
	{
		
		public ParticleSystemGravitySourceListVariable()
		{
		}
		
		public ParticleSystemGravitySourceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceRef : VariableRef<UnityEngine.ParticleSystemGravitySource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceVar : VariableVar<UnityEngine.ParticleSystemGravitySource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceListRef : ListVariableRef<UnityEngine.ParticleSystemGravitySource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGravitySource))]
	public sealed partial class ParticleSystemGravitySourceListVar : ListVariableVar<UnityEngine.ParticleSystemGravitySource>
	{
	}
}
