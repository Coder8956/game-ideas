
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasVariable : Variable<UnityEngine.Canvas>
	{
		
		public CanvasVariable()
		{
		}
		
		public CanvasVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasListVariable : ListVariable<UnityEngine.Canvas>
	{
		
		public CanvasListVariable()
		{
		}
		
		public CanvasListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasRef : BaseComponentRef<UnityEngine.Canvas>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasVar : BaseComponentVar<UnityEngine.Canvas>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasListRef : ListVariableRef<UnityEngine.Canvas>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Canvas))]
	public sealed partial class CanvasListVar : ListVariableVar<UnityEngine.Canvas>
	{
	}
}
