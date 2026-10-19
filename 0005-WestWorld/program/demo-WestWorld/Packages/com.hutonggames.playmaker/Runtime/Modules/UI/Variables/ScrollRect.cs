
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectVariable : Variable<UnityEngine.UI.ScrollRect>
	{
		
		public ScrollRectVariable()
		{
		}
		
		public ScrollRectVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectListVariable : ListVariable<UnityEngine.UI.ScrollRect>
	{
		
		public ScrollRectListVariable()
		{
		}
		
		public ScrollRectListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectRef : BaseComponentRef<UnityEngine.UI.ScrollRect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectVar : BaseComponentVar<UnityEngine.UI.ScrollRect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectListRef : ListVariableRef<UnityEngine.UI.ScrollRect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect))]
	public sealed partial class ScrollRectListVar : ListVariableVar<UnityEngine.UI.ScrollRect>
	{
	}
}
