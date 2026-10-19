
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeVariable : Variable<UnityEngine.ParticleSystemCullingMode>
	{
		
		public ParticleSystemCullingModeVariable()
		{
		}
		
		public ParticleSystemCullingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeListVariable : ListVariable<UnityEngine.ParticleSystemCullingMode>
	{
		
		public ParticleSystemCullingModeListVariable()
		{
		}
		
		public ParticleSystemCullingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeRef : VariableRef<UnityEngine.ParticleSystemCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeVar : VariableVar<UnityEngine.ParticleSystemCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeListRef : ListVariableRef<UnityEngine.ParticleSystemCullingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCullingMode))]
	public sealed partial class ParticleSystemCullingModeListVar : ListVariableVar<UnityEngine.ParticleSystemCullingMode>
	{
	}
}
