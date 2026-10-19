
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeVariable : Variable<UnityEngine.Camera.StereoscopicEye>
	{
		
		public Camera_StereoscopicEyeVariable()
		{
		}
		
		public Camera_StereoscopicEyeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeListVariable : ListVariable<UnityEngine.Camera.StereoscopicEye>
	{
		
		public Camera_StereoscopicEyeListVariable()
		{
		}
		
		public Camera_StereoscopicEyeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeRef : VariableRef<UnityEngine.Camera.StereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeVar : VariableVar<UnityEngine.Camera.StereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeListRef : ListVariableRef<UnityEngine.Camera.StereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.StereoscopicEye))]
	public sealed partial class Camera_StereoscopicEyeListVar : ListVariableVar<UnityEngine.Camera.StereoscopicEye>
	{
	}
}
