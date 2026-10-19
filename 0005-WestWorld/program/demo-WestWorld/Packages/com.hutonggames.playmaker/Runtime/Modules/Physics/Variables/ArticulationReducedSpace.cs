
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceVariable : Variable<UnityEngine.ArticulationReducedSpace>
	{
		
		public ArticulationReducedSpaceVariable()
		{
		}
		
		public ArticulationReducedSpaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceListVariable : ListVariable<UnityEngine.ArticulationReducedSpace>
	{
		
		public ArticulationReducedSpaceListVariable()
		{
		}
		
		public ArticulationReducedSpaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceRef : VariableRef<UnityEngine.ArticulationReducedSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceVar : VariableVar<UnityEngine.ArticulationReducedSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceListRef : ListVariableRef<UnityEngine.ArticulationReducedSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationReducedSpace))]
	public sealed partial class ArticulationReducedSpaceListVar : ListVariableVar<UnityEngine.ArticulationReducedSpace>
	{
	}
}
