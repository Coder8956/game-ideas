
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisVariable : Variable<UnityEngine.ArticulationDriveAxis>
	{
		
		public ArticulationDriveAxisVariable()
		{
		}
		
		public ArticulationDriveAxisVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisListVariable : ListVariable<UnityEngine.ArticulationDriveAxis>
	{
		
		public ArticulationDriveAxisListVariable()
		{
		}
		
		public ArticulationDriveAxisListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisRef : VariableRef<UnityEngine.ArticulationDriveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisVar : VariableVar<UnityEngine.ArticulationDriveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisListRef : ListVariableRef<UnityEngine.ArticulationDriveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveAxis))]
	public sealed partial class ArticulationDriveAxisListVar : ListVariableVar<UnityEngine.ArticulationDriveAxis>
	{
	}
}
