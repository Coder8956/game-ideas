
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeVariable : Variable<UnityEngine.ParticleSystemAnimationRowMode>
	{
		
		public ParticleSystemAnimationRowModeVariable()
		{
		}
		
		public ParticleSystemAnimationRowModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeListVariable : ListVariable<UnityEngine.ParticleSystemAnimationRowMode>
	{
		
		public ParticleSystemAnimationRowModeListVariable()
		{
		}
		
		public ParticleSystemAnimationRowModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeRef : VariableRef<UnityEngine.ParticleSystemAnimationRowMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeVar : VariableVar<UnityEngine.ParticleSystemAnimationRowMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeListRef : ListVariableRef<UnityEngine.ParticleSystemAnimationRowMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemAnimationRowMode))]
	public sealed partial class ParticleSystemAnimationRowModeListVar : ListVariableVar<UnityEngine.ParticleSystemAnimationRowMode>
	{
	}
}
