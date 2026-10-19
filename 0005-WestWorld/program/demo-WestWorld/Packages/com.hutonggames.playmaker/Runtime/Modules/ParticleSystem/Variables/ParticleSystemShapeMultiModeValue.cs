
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueVariable : Variable<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
		
		public ParticleSystemShapeMultiModeValueVariable()
		{
		}
		
		public ParticleSystemShapeMultiModeValueVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueListVariable : ListVariable<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
		
		public ParticleSystemShapeMultiModeValueListVariable()
		{
		}
		
		public ParticleSystemShapeMultiModeValueListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueRef : VariableRef<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueVar : VariableVar<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueListRef : ListVariableRef<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeMultiModeValue))]
	public sealed partial class ParticleSystemShapeMultiModeValueListVar : ListVariableVar<UnityEngine.ParticleSystemShapeMultiModeValue>
	{
	}
}
