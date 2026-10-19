
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraVariable : Variable<Camera>
	{
		
		public CameraVariable()
		{
		}
		
		public CameraVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraListVariable : ListVariable<Camera>
	{
		
		public CameraListVariable()
		{
		}
		
		public CameraListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraRef : BaseComponentRef<Camera>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraVar : BaseComponentVar<Camera>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraListRef : ListVariableRef<Camera>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraListVar : ListVariableVar<Camera>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraOverride : VariableOverride<Camera,CameraVariable,CameraVar>
	{
		
		public CameraOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraOutput : VariableOutput<Camera,CameraVariable,CameraRef>
	{
		
		public CameraOutput(IVariable variable) : 
				base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraListOverride : VariableOverride<List<Camera>, CameraListVariable, CameraListVar>
	{
		public CameraListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Camera))]
	public sealed partial class CameraListOutput : VariableOutput<List<Camera>, CameraListVariable, CameraListRef>
	{
		public CameraListOutput(IVariable variable) :
			base(variable)
		{
		}
	}
}
