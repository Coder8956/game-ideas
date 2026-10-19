
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeVariable : Variable<UnityEngine.ArticulationDriveType>
	{
		
		public ArticulationDriveTypeVariable()
		{
		}
		
		public ArticulationDriveTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeListVariable : ListVariable<UnityEngine.ArticulationDriveType>
	{
		
		public ArticulationDriveTypeListVariable()
		{
		}
		
		public ArticulationDriveTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeRef : VariableRef<UnityEngine.ArticulationDriveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeVar : VariableVar<UnityEngine.ArticulationDriveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeListRef : ListVariableRef<UnityEngine.ArticulationDriveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ArticulationDriveType))]
	public sealed partial class ArticulationDriveTypeListVar : ListVariableVar<UnityEngine.ArticulationDriveType>
	{
	}
}
