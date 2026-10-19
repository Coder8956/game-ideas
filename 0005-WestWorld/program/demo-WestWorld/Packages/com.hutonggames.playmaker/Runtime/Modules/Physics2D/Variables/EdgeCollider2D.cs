
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DVariable : Variable<UnityEngine.EdgeCollider2D>
	{
		
		public EdgeCollider2DVariable()
		{
		}
		
		public EdgeCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DListVariable : ListVariable<UnityEngine.EdgeCollider2D>
	{
		
		public EdgeCollider2DListVariable()
		{
		}
		
		public EdgeCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DRef : BaseComponentRef<UnityEngine.EdgeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DVar : BaseComponentVar<UnityEngine.EdgeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DListRef : ListVariableRef<UnityEngine.EdgeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EdgeCollider2D))]
	public sealed partial class EdgeCollider2DListVar : ListVariableVar<UnityEngine.EdgeCollider2D>
	{
	}
}
