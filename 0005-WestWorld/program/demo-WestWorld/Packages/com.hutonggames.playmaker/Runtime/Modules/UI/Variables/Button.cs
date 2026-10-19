
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonVariable : Variable<UnityEngine.UI.Button>
	{
		
		public ButtonVariable()
		{
		}
		
		public ButtonVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonListVariable : ListVariable<UnityEngine.UI.Button>
	{
		
		public ButtonListVariable()
		{
		}
		
		public ButtonListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonRef : BaseComponentRef<UnityEngine.UI.Button>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonVar : BaseComponentVar<UnityEngine.UI.Button>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonListRef : ListVariableRef<UnityEngine.UI.Button>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Button))]
	public sealed partial class ButtonListVar : ListVariableVar<UnityEngine.UI.Button>
	{
	}
}
