
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveVariable : Variable<UnityEngine.ArticulationDrive>
	{
		
		public ArticulationDriveVariable()
		{
		}
		
		public ArticulationDriveVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveListVariable : ListVariable<UnityEngine.ArticulationDrive>
	{
		
		public ArticulationDriveListVariable()
		{
		}
		
		public ArticulationDriveListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveRef : VariableRef<UnityEngine.ArticulationDrive>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveVar : VariableVar<UnityEngine.ArticulationDrive>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveListRef : ListVariableRef<UnityEngine.ArticulationDrive>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDrive))]
	public sealed partial class ArticulationDriveListVar : ListVariableVar<UnityEngine.ArticulationDrive>
	{
	}
}
