
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarVariable : Variable<UnityEngine.UI.Scrollbar>
	{
		
		public ScrollbarVariable()
		{
		}
		
		public ScrollbarVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarListVariable : ListVariable<UnityEngine.UI.Scrollbar>
	{
		
		public ScrollbarListVariable()
		{
		}
		
		public ScrollbarListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarRef : BaseComponentRef<UnityEngine.UI.Scrollbar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarVar : BaseComponentVar<UnityEngine.UI.Scrollbar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarListRef : ListVariableRef<UnityEngine.UI.Scrollbar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar))]
	public sealed partial class ScrollbarListVar : ListVariableVar<UnityEngine.UI.Scrollbar>
	{
	}
}
