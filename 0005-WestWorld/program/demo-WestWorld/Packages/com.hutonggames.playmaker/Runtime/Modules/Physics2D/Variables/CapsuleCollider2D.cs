
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DVariable : Variable<UnityEngine.CapsuleCollider2D>
	{
		
		public CapsuleCollider2DVariable()
		{
		}
		
		public CapsuleCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DListVariable : ListVariable<UnityEngine.CapsuleCollider2D>
	{
		
		public CapsuleCollider2DListVariable()
		{
		}
		
		public CapsuleCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DRef : BaseComponentRef<UnityEngine.CapsuleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DVar : BaseComponentVar<UnityEngine.CapsuleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DListRef : ListVariableRef<UnityEngine.CapsuleCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider2D))]
	public sealed partial class CapsuleCollider2DListVar : ListVariableVar<UnityEngine.CapsuleCollider2D>
	{
	}
}
