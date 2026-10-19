
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementVariable : Variable<UnityEngine.UI.LayoutElement>
	{
		
		public LayoutElementVariable()
		{
		}
		
		public LayoutElementVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementListVariable : ListVariable<UnityEngine.UI.LayoutElement>
	{
		
		public LayoutElementListVariable()
		{
		}
		
		public LayoutElementListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementRef : BaseComponentRef<UnityEngine.UI.LayoutElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementVar : BaseComponentVar<UnityEngine.UI.LayoutElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementListRef : ListVariableRef<UnityEngine.UI.LayoutElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.LayoutElement))]
	public sealed partial class LayoutElementListVar : ListVariableVar<UnityEngine.UI.LayoutElement>
	{
	}
}
