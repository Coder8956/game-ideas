
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DVariable : Variable<UnityEngine.CircleCollider2D>
	{
		
		public CircleCollider2DVariable()
		{
		}
		
		public CircleCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DListVariable : ListVariable<UnityEngine.CircleCollider2D>
	{
		
		public CircleCollider2DListVariable()
		{
		}
		
		public CircleCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DRef : BaseComponentRef<UnityEngine.CircleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DVar : BaseComponentVar<UnityEngine.CircleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DListRef : ListVariableRef<UnityEngine.CircleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CircleCollider2D))]
	public sealed partial class CircleCollider2DListVar : ListVariableVar<UnityEngine.CircleCollider2D>
	{
	}
}
