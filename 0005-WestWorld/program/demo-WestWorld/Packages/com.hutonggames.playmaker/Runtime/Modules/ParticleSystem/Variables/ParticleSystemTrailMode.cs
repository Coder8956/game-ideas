
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeVariable : Variable<UnityEngine.ParticleSystemTrailMode>
	{
		
		public ParticleSystemTrailModeVariable()
		{
		}
		
		public ParticleSystemTrailModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeListVariable : ListVariable<UnityEngine.ParticleSystemTrailMode>
	{
		
		public ParticleSystemTrailModeListVariable()
		{
		}
		
		public ParticleSystemTrailModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeRef : VariableRef<UnityEngine.ParticleSystemTrailMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeVar : VariableVar<UnityEngine.ParticleSystemTrailMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeListRef : ListVariableRef<UnityEngine.ParticleSystemTrailMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTrailMode))]
	public sealed partial class ParticleSystemTrailModeListVar : ListVariableVar<UnityEngine.ParticleSystemTrailMode>
	{
	}
}
