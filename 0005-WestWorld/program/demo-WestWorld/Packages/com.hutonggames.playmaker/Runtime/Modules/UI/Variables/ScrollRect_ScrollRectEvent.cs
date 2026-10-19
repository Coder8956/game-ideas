
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventVariable : Variable<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
		
		public ScrollRect_ScrollRectEventVariable()
		{
		}
		
		public ScrollRect_ScrollRectEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventRef : VariableRef<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventVar : VariableVar<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventListVariable : ListVariable<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
		
		public ScrollRect_ScrollRectEventListVariable()
		{
		}
		
		public ScrollRect_ScrollRectEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventListRef : ListVariableRef<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent))]
	public sealed partial class ScrollRect_ScrollRectEventListVar : ListVariableVar<UnityEngine.UI.ScrollRect.ScrollRectEvent>
	{
	}
	*/
}
