
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeVariable : Variable<UnityEngine.TouchScreenKeyboardType>
	{
		
		public TouchScreenKeyboardTypeVariable()
		{
		}
		
		public TouchScreenKeyboardTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeListVariable : ListVariable<UnityEngine.TouchScreenKeyboardType>
	{
		
		public TouchScreenKeyboardTypeListVariable()
		{
		}
		
		public TouchScreenKeyboardTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeRef : VariableRef<UnityEngine.TouchScreenKeyboardType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeVar : VariableVar<UnityEngine.TouchScreenKeyboardType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeListRef : ListVariableRef<UnityEngine.TouchScreenKeyboardType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboardType))]
	public sealed partial class TouchScreenKeyboardTypeListVar : ListVariableVar<UnityEngine.TouchScreenKeyboardType>
	{
	}
}
