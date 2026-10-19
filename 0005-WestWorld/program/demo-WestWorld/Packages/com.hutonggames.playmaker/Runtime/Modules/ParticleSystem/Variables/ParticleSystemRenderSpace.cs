
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceVariable : Variable<UnityEngine.ParticleSystemRenderSpace>
	{
		
		public ParticleSystemRenderSpaceVariable()
		{
		}
		
		public ParticleSystemRenderSpaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceListVariable : ListVariable<UnityEngine.ParticleSystemRenderSpace>
	{
		
		public ParticleSystemRenderSpaceListVariable()
		{
		}
		
		public ParticleSystemRenderSpaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceRef : VariableRef<UnityEngine.ParticleSystemRenderSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceVar : VariableVar<UnityEngine.ParticleSystemRenderSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceListRef : ListVariableRef<UnityEngine.ParticleSystemRenderSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderSpace))]
	public sealed partial class ParticleSystemRenderSpaceListVar : ListVariableVar<UnityEngine.ParticleSystemRenderSpace>
	{
	}
}
