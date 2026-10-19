
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveVariable : Variable<UnityEngine.ParticleSystem.MinMaxCurve>
	{
		
		public ParticleSystem_MinMaxCurveVariable()
		{
		}
		
		public ParticleSystem_MinMaxCurveVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveListVariable : ListVariable<UnityEngine.ParticleSystem.MinMaxCurve>
	{
		
		public ParticleSystem_MinMaxCurveListVariable()
		{
		}
		
		public ParticleSystem_MinMaxCurveListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveRef : VariableRef<UnityEngine.ParticleSystem.MinMaxCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveVar : VariableVar<UnityEngine.ParticleSystem.MinMaxCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveListRef : ListVariableRef<UnityEngine.ParticleSystem.MinMaxCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem.MinMaxCurve))]
	public sealed partial class ParticleSystem_MinMaxCurveListVar : ListVariableVar<UnityEngine.ParticleSystem.MinMaxCurve>
	{
	}
}
