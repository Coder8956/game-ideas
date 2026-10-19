
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeVariable : Variable<UnityEngine.RotationDriveMode>
	{
		
		public RotationDriveModeVariable()
		{
		}
		
		public RotationDriveModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeListVariable : ListVariable<UnityEngine.RotationDriveMode>
	{
		
		public RotationDriveModeListVariable()
		{
		}
		
		public RotationDriveModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeRef : VariableRef<UnityEngine.RotationDriveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeVar : VariableVar<UnityEngine.RotationDriveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeListRef : ListVariableRef<UnityEngine.RotationDriveMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RotationDriveMode))]
	public sealed partial class RotationDriveModeListVar : ListVariableVar<UnityEngine.RotationDriveMode>
	{
	}
}
