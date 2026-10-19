
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicVariable : Variable<UnityEngine.UI.Graphic>
	{
		
		public GraphicVariable()
		{
		}
		
		public GraphicVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicListVariable : ListVariable<UnityEngine.UI.Graphic>
	{
		
		public GraphicListVariable()
		{
		}
		
		public GraphicListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicRef : BaseComponentRef<UnityEngine.UI.Graphic>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicVar : BaseComponentVar<UnityEngine.UI.Graphic>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicListRef : ListVariableRef<UnityEngine.UI.Graphic>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Graphic))]
	public sealed partial class GraphicListVar : ListVariableVar<UnityEngine.UI.Graphic>
	{
	}
}
