
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeVariable : Variable<UnityEngine.ParticleSystemCurveMode>
	{
		
		public ParticleSystemCurveModeVariable()
		{
		}
		
		public ParticleSystemCurveModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeListVariable : ListVariable<UnityEngine.ParticleSystemCurveMode>
	{
		
		public ParticleSystemCurveModeListVariable()
		{
		}
		
		public ParticleSystemCurveModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeRef : VariableRef<UnityEngine.ParticleSystemCurveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeVar : VariableVar<UnityEngine.ParticleSystemCurveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeListRef : ListVariableRef<UnityEngine.ParticleSystemCurveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCurveMode))]
	public sealed partial class ParticleSystemCurveModeListVar : ListVariableVar<UnityEngine.ParticleSystemCurveMode>
	{
	}
}
