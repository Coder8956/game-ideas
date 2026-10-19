
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeVariable : Variable<UnityEngine.CameraType>
	{
		
		public CameraTypeVariable()
		{
		}
		
		public CameraTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeListVariable : ListVariable<UnityEngine.CameraType>
	{
		
		public CameraTypeListVariable()
		{
		}
		
		public CameraTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeRef : VariableRef<UnityEngine.CameraType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeVar : VariableVar<UnityEngine.CameraType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeListRef : ListVariableRef<UnityEngine.CameraType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraType))]
	public sealed partial class CameraTypeListVar : ListVariableVar<UnityEngine.CameraType>
	{
	}
}
