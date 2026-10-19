
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DVariable : Variable<UnityEngine.CustomCollider2D>
	{
		
		public CustomCollider2DVariable()
		{
		}
		
		public CustomCollider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DListVariable : ListVariable<UnityEngine.CustomCollider2D>
	{
		
		public CustomCollider2DListVariable()
		{
		}
		
		public CustomCollider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DRef : BaseComponentRef<UnityEngine.CustomCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DVar : BaseComponentVar<UnityEngine.CustomCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DListRef : ListVariableRef<UnityEngine.CustomCollider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CustomCollider2D))]
	public sealed partial class CustomCollider2DListVar : ListVariableVar<UnityEngine.CustomCollider2D>
	{
	}
}
