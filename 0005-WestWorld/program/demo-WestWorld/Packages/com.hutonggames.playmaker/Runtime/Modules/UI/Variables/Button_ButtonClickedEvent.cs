
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventVariable : Variable<UnityEngine.UI.Button.ButtonClickedEvent>
	{
		
		public Button_ButtonClickedEventVariable()
		{
		}
		
		public Button_ButtonClickedEventVariable(string name) : 
				base(name)
		{
		}
	}
	

	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventRef : VariableRef<UnityEngine.UI.Button.ButtonClickedEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventVar : VariableVar<UnityEngine.UI.Button.ButtonClickedEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventListVariable : ListVariable<UnityEngine.UI.Button.ButtonClickedEvent>
	{
		
		public Button_ButtonClickedEventListVariable()
		{
		}
		
		public Button_ButtonClickedEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventListRef : ListVariableRef<UnityEngine.UI.Button.ButtonClickedEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button.ButtonClickedEvent))]
	public sealed partial class Button_ButtonClickedEventListVar : ListVariableVar<UnityEngine.UI.Button.ButtonClickedEvent>
	{
	}
	*/
}
