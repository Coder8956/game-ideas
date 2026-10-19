
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DVariable : Variable<UnityEngine.CompositeCollider2D>
	{
		
		public CompositeCollider2DVariable()
		{
		}
		
		public CompositeCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DListVariable : ListVariable<UnityEngine.CompositeCollider2D>
	{
		
		public CompositeCollider2DListVariable()
		{
		}
		
		public CompositeCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DRef : BaseComponentRef<UnityEngine.CompositeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DVar : BaseComponentVar<UnityEngine.CompositeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DListRef : ListVariableRef<UnityEngine.CompositeCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D))]
	public sealed partial class CompositeCollider2DListVar : ListVariableVar<UnityEngine.CompositeCollider2D>
	{
	}
}
