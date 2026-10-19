
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityVariable : Variable<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
		
		public ScrollRect_ScrollbarVisibilityVariable()
		{
		}
		
		public ScrollRect_ScrollbarVisibilityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityListVariable : ListVariable<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
		
		public ScrollRect_ScrollbarVisibilityListVariable()
		{
		}
		
		public ScrollRect_ScrollbarVisibilityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityRef : VariableRef<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityVar : VariableVar<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityListRef : ListVariableRef<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility))]
	public sealed partial class ScrollRect_ScrollbarVisibilityListVar : ListVariableVar<UnityEngine.UI.ScrollRect.ScrollbarVisibility>
	{
	}
}
