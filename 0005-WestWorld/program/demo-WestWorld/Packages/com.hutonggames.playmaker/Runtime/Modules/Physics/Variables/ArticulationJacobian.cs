
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianVariable : Variable<UnityEngine.ArticulationJacobian>
	{
		
		public ArticulationJacobianVariable()
		{
		}
		
		public ArticulationJacobianVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianListVariable : ListVariable<UnityEngine.ArticulationJacobian>
	{
		
		public ArticulationJacobianListVariable()
		{
		}
		
		public ArticulationJacobianListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianRef : VariableRef<UnityEngine.ArticulationJacobian>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianVar : VariableVar<UnityEngine.ArticulationJacobian>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianListRef : ListVariableRef<UnityEngine.ArticulationJacobian>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationJacobian))]
	public sealed partial class ArticulationJacobianListVar : ListVariableVar<UnityEngine.ArticulationJacobian>
	{
	}
}
