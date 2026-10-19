
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DVariable : Variable<UnityEngine.ColliderDistance2D>
	{
		
		public ColliderDistance2DVariable()
		{
		}
		
		public ColliderDistance2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DListVariable : ListVariable<UnityEngine.ColliderDistance2D>
	{
		
		public ColliderDistance2DListVariable()
		{
		}
		
		public ColliderDistance2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DRef : VariableRef<UnityEngine.ColliderDistance2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DVar : VariableVar<UnityEngine.ColliderDistance2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DListRef : ListVariableRef<UnityEngine.ColliderDistance2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderDistance2D))]
	public sealed partial class ColliderDistance2DListVar : ListVariableVar<UnityEngine.ColliderDistance2D>
	{
	}
}
