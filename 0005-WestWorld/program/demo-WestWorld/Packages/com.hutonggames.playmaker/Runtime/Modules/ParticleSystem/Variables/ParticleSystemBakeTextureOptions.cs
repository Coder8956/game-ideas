
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsVariable : Variable<UnityEngine.ParticleSystemBakeTextureOptions>
	{
		
		public ParticleSystemBakeTextureOptionsVariable()
		{
		}
		
		public ParticleSystemBakeTextureOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsListVariable : ListVariable<UnityEngine.ParticleSystemBakeTextureOptions>
	{
		
		public ParticleSystemBakeTextureOptionsListVariable()
		{
		}
		
		public ParticleSystemBakeTextureOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsRef : VariableRef<UnityEngine.ParticleSystemBakeTextureOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsVar : VariableVar<UnityEngine.ParticleSystemBakeTextureOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsListRef : ListVariableRef<UnityEngine.ParticleSystemBakeTextureOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemBakeTextureOptions))]
	public sealed partial class ParticleSystemBakeTextureOptionsListVar : ListVariableVar<UnityEngine.ParticleSystemBakeTextureOptions>
	{
	}
}
