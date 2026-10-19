
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeVariable : Variable<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
		
		public Camera_MonoOrStereoscopicEyeVariable()
		{
		}
		
		public Camera_MonoOrStereoscopicEyeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeListVariable : ListVariable<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
		
		public Camera_MonoOrStereoscopicEyeListVariable()
		{
		}
		
		public Camera_MonoOrStereoscopicEyeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeRef : VariableRef<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeVar : VariableVar<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeListRef : ListVariableRef<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Camera.MonoOrStereoscopicEye))]
	public sealed partial class Camera_MonoOrStereoscopicEyeListVar : ListVariableVar<UnityEngine.Camera.MonoOrStereoscopicEye>
	{
	}
}
