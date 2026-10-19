
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataVariable : Variable<UnityEngine.ParticleSystemCustomData>
	{
		
		public ParticleSystemCustomDataVariable()
		{
		}
		
		public ParticleSystemCustomDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataListVariable : ListVariable<UnityEngine.ParticleSystemCustomData>
	{
		
		public ParticleSystemCustomDataListVariable()
		{
		}
		
		public ParticleSystemCustomDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataRef : VariableRef<UnityEngine.ParticleSystemCustomData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataVar : VariableVar<UnityEngine.ParticleSystemCustomData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataListRef : ListVariableRef<UnityEngine.ParticleSystemCustomData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemCustomData))]
	public sealed partial class ParticleSystemCustomDataListVar : ListVariableVar<UnityEngine.ParticleSystemCustomData>
	{
	}
}
