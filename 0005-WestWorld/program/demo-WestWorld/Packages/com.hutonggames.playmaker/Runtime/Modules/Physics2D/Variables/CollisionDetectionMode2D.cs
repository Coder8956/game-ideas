
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DVariable : Variable<UnityEngine.CollisionDetectionMode2D>
	{
		
		public CollisionDetectionMode2DVariable()
		{
		}
		
		public CollisionDetectionMode2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DListVariable : ListVariable<UnityEngine.CollisionDetectionMode2D>
	{
		
		public CollisionDetectionMode2DListVariable()
		{
		}
		
		public CollisionDetectionMode2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DRef : VariableRef<UnityEngine.CollisionDetectionMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DVar : VariableVar<UnityEngine.CollisionDetectionMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DListRef : ListVariableRef<UnityEngine.CollisionDetectionMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode2D))]
	public sealed partial class CollisionDetectionMode2DListVar : ListVariableVar<UnityEngine.CollisionDetectionMode2D>
	{
	}
}
