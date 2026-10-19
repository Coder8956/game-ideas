
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DVariable : Variable<UnityEngine.PolygonCollider2D>
	{
		
		public PolygonCollider2DVariable()
		{
		}
		
		public PolygonCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DListVariable : ListVariable<UnityEngine.PolygonCollider2D>
	{
		
		public PolygonCollider2DListVariable()
		{
		}
		
		public PolygonCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DRef : BaseComponentRef<UnityEngine.PolygonCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DVar : BaseComponentVar<UnityEngine.PolygonCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DListRef : ListVariableRef<UnityEngine.PolygonCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PolygonCollider2D))]
	public sealed partial class PolygonCollider2DListVar : ListVariableVar<UnityEngine.PolygonCollider2D>
	{
	}
}
