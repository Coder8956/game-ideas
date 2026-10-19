
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeVariable : Variable<UnityEngine.ParticleSystemRenderMode>
	{
		
		public ParticleSystemRenderModeVariable()
		{
		}
		
		public ParticleSystemRenderModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeListVariable : ListVariable<UnityEngine.ParticleSystemRenderMode>
	{
		
		public ParticleSystemRenderModeListVariable()
		{
		}
		
		public ParticleSystemRenderModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeRef : VariableRef<UnityEngine.ParticleSystemRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeVar : VariableVar<UnityEngine.ParticleSystemRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeListRef : ListVariableRef<UnityEngine.ParticleSystemRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderMode))]
	public sealed partial class ParticleSystemRenderModeListVar : ListVariableVar<UnityEngine.ParticleSystemRenderMode>
	{
	}
}
