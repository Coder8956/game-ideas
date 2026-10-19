
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeVariable : Variable<UnityEngine.Camera.GateFitMode>
	{
		
		public Camera_GateFitModeVariable()
		{
		}
		
		public Camera_GateFitModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeListVariable : ListVariable<UnityEngine.Camera.GateFitMode>
	{
		
		public Camera_GateFitModeListVariable()
		{
		}
		
		public Camera_GateFitModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeRef : VariableRef<UnityEngine.Camera.GateFitMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeVar : VariableVar<UnityEngine.Camera.GateFitMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeListRef : ListVariableRef<UnityEngine.Camera.GateFitMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.GateFitMode))]
	public sealed partial class Camera_GateFitModeListVar : ListVariableVar<UnityEngine.Camera.GateFitMode>
	{
	}
}
