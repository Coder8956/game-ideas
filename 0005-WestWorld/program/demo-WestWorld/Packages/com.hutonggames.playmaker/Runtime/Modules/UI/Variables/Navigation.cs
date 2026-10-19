
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationVariable : Variable<UnityEngine.UI.Navigation>
	{
		
		public NavigationVariable()
		{
		}
		
		public NavigationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationListVariable : ListVariable<UnityEngine.UI.Navigation>
	{
		
		public NavigationListVariable()
		{
		}
		
		public NavigationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationRef : VariableRef<UnityEngine.UI.Navigation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationVar : VariableVar<UnityEngine.UI.Navigation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationListRef : ListVariableRef<UnityEngine.UI.Navigation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Navigation))]
	public sealed partial class NavigationListVar : ListVariableVar<UnityEngine.UI.Navigation>
	{
	}
}
