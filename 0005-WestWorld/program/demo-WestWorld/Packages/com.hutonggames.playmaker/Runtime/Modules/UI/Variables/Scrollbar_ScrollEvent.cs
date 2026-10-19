
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventVariable : Variable<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
		
		public Scrollbar_ScrollEventVariable()
		{
		}
		
		public Scrollbar_ScrollEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventRef : VariableRef<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventVar : VariableVar<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventListVariable : ListVariable<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
		
		public Scrollbar_ScrollEventListVariable()
		{
		}
		
		public Scrollbar_ScrollEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventListRef : ListVariableRef<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.ScrollEvent))]
	public sealed partial class Scrollbar_ScrollEventListVar : ListVariableVar<UnityEngine.UI.Scrollbar.ScrollEvent>
	{
	}
	*/
}
