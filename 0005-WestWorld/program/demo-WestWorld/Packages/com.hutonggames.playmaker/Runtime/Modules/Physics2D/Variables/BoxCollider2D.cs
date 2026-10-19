
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DVariable : Variable<UnityEngine.BoxCollider2D>
	{
		
		public BoxCollider2DVariable()
		{
		}
		
		public BoxCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DListVariable : ListVariable<UnityEngine.BoxCollider2D>
	{
		
		public BoxCollider2DListVariable()
		{
		}
		
		public BoxCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DRef : BaseComponentRef<UnityEngine.BoxCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DVar : BaseComponentVar<UnityEngine.BoxCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DListRef : ListVariableRef<UnityEngine.BoxCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider2D))]
	public sealed partial class BoxCollider2DListVar : ListVariableVar<UnityEngine.BoxCollider2D>
	{
	}
}
