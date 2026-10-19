
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateVariable : Variable<UnityEngine.UI.CanvasUpdate>
	{
		
		public CanvasUpdateVariable()
		{
		}
		
		public CanvasUpdateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateListVariable : ListVariable<UnityEngine.UI.CanvasUpdate>
	{
		
		public CanvasUpdateListVariable()
		{
		}
		
		public CanvasUpdateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateRef : VariableRef<UnityEngine.UI.CanvasUpdate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateVar : VariableVar<UnityEngine.UI.CanvasUpdate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateListRef : ListVariableRef<UnityEngine.UI.CanvasUpdate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.CanvasUpdate))]
	public sealed partial class CanvasUpdateListVar : ListVariableVar<UnityEngine.UI.CanvasUpdate>
	{
	}
}
