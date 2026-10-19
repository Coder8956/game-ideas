
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusVariable : Variable<UnityEngine.TouchScreenKeyboard.Status>
	{
		
		public TouchScreenKeyboard_StatusVariable()
		{
		}
		
		public TouchScreenKeyboard_StatusVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusRef : VariableRef<UnityEngine.TouchScreenKeyboard.Status>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusVar : VariableVar<UnityEngine.TouchScreenKeyboard.Status>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusListVariable : ListVariable<UnityEngine.TouchScreenKeyboard.Status>
	{
		
		public TouchScreenKeyboard_StatusListVariable()
		{
		}
		
		public TouchScreenKeyboard_StatusListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusListRef : ListVariableRef<UnityEngine.TouchScreenKeyboard.Status>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchScreenKeyboard.Status))]
	public sealed partial class TouchScreenKeyboard_StatusListVar : ListVariableVar<UnityEngine.TouchScreenKeyboard.Status>
	{
	}
	*/
}
