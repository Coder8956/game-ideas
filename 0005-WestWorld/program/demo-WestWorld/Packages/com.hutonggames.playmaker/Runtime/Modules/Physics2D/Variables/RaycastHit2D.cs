
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DVariable : Variable<UnityEngine.RaycastHit2D>
	{
		
		public RaycastHit2DVariable()
		{
		}
		
		public RaycastHit2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DListVariable : ListVariable<UnityEngine.RaycastHit2D>
	{
		
		public RaycastHit2DListVariable()
		{
		}
		
		public RaycastHit2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DRef : VariableRef<UnityEngine.RaycastHit2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DVar : VariableVar<UnityEngine.RaycastHit2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DListRef : ListVariableRef<UnityEngine.RaycastHit2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit2D))]
	public sealed partial class RaycastHit2DListVar : ListVariableVar<UnityEngine.RaycastHit2D>
	{
	}
}
