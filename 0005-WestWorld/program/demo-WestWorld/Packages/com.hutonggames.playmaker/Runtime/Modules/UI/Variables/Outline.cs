
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineVariable : Variable<UnityEngine.UI.Outline>
	{
		
		public OutlineVariable()
		{
		}
		
		public OutlineVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineListVariable : ListVariable<UnityEngine.UI.Outline>
	{
		
		public OutlineListVariable()
		{
		}
		
		public OutlineListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineRef : BaseComponentRef<UnityEngine.UI.Outline>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineVar : BaseComponentVar<UnityEngine.UI.Outline>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineListRef : ListVariableRef<UnityEngine.UI.Outline>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Outline))]
	public sealed partial class OutlineListVar : ListVariableVar<UnityEngine.UI.Outline>
	{
	}
}
