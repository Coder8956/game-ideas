
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeVariable : Variable<UnityEngine.Camera.SceneViewFilterMode>
	{
		
		public Camera_SceneViewFilterModeVariable()
		{
		}
		
		public Camera_SceneViewFilterModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeListVariable : ListVariable<UnityEngine.Camera.SceneViewFilterMode>
	{
		
		public Camera_SceneViewFilterModeListVariable()
		{
		}
		
		public Camera_SceneViewFilterModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeRef : VariableRef<UnityEngine.Camera.SceneViewFilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeVar : VariableVar<UnityEngine.Camera.SceneViewFilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeListRef : ListVariableRef<UnityEngine.Camera.SceneViewFilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.SceneViewFilterMode))]
	public sealed partial class Camera_SceneViewFilterModeListVar : ListVariableVar<UnityEngine.Camera.SceneViewFilterMode>
	{
	}
}
