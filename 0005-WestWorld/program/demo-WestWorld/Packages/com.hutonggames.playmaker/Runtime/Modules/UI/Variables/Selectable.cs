
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableVariable : Variable<UnityEngine.UI.Selectable>
	{
		
		public SelectableVariable()
		{
		}
		
		public SelectableVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableListVariable : ListVariable<UnityEngine.UI.Selectable>
	{
		
		public SelectableListVariable()
		{
		}
		
		public SelectableListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableRef : BaseComponentRef<UnityEngine.UI.Selectable>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableVar : BaseComponentVar<UnityEngine.UI.Selectable>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableListRef : ListVariableRef<UnityEngine.UI.Selectable>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable))]
	public sealed partial class SelectableListVar : ListVariableVar<UnityEngine.UI.Selectable>
	{
	}
}
