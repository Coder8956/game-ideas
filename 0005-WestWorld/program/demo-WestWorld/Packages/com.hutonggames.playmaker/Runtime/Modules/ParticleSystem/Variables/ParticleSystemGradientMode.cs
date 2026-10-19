
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeVariable : Variable<UnityEngine.ParticleSystemGradientMode>
	{
		
		public ParticleSystemGradientModeVariable()
		{
		}
		
		public ParticleSystemGradientModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeListVariable : ListVariable<UnityEngine.ParticleSystemGradientMode>
	{
		
		public ParticleSystemGradientModeListVariable()
		{
		}
		
		public ParticleSystemGradientModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeRef : VariableRef<UnityEngine.ParticleSystemGradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeVar : VariableVar<UnityEngine.ParticleSystemGradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeListRef : ListVariableRef<UnityEngine.ParticleSystemGradientMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemGradientMode))]
	public sealed partial class ParticleSystemGradientModeListVar : ListVariableVar<UnityEngine.ParticleSystemGradientMode>
	{
	}
}
