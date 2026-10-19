
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeVariable : Variable<UnityEngine.ArticulationJointType>
	{
		
		public ArticulationJointTypeVariable()
		{
		}
		
		public ArticulationJointTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeListVariable : ListVariable<UnityEngine.ArticulationJointType>
	{
		
		public ArticulationJointTypeListVariable()
		{
		}
		
		public ArticulationJointTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeRef : VariableRef<UnityEngine.ArticulationJointType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeVar : VariableVar<UnityEngine.ArticulationJointType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeListRef : ListVariableRef<UnityEngine.ArticulationJointType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJointType))]
	public sealed partial class ArticulationJointTypeListVar : ListVariableVar<UnityEngine.ArticulationJointType>
	{
	}
}
