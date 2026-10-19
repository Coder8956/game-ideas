
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsVariable : Variable<UnityEngine.ParticleSystemBakeMeshOptions>
	{
		
		public ParticleSystemBakeMeshOptionsVariable()
		{
		}
		
		public ParticleSystemBakeMeshOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsListVariable : ListVariable<UnityEngine.ParticleSystemBakeMeshOptions>
	{
		
		public ParticleSystemBakeMeshOptionsListVariable()
		{
		}
		
		public ParticleSystemBakeMeshOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsRef : VariableRef<UnityEngine.ParticleSystemBakeMeshOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsVar : VariableVar<UnityEngine.ParticleSystemBakeMeshOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsListRef : ListVariableRef<UnityEngine.ParticleSystemBakeMeshOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeMeshOptions))]
	public sealed partial class ParticleSystemBakeMeshOptionsListVar : ListVariableVar<UnityEngine.ParticleSystemBakeMeshOptions>
	{
	}
}
