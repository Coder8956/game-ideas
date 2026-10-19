
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DVariable : Variable<UnityEngine.Rigidbody2D>
	{
		
		public Rigidbody2DVariable()
		{
		}
		
		public Rigidbody2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DListVariable : ListVariable<UnityEngine.Rigidbody2D>
	{
		
		public Rigidbody2DListVariable()
		{
		}
		
		public Rigidbody2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DRef : BaseComponentRef<UnityEngine.Rigidbody2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DVar : BaseComponentVar<UnityEngine.Rigidbody2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DListRef : ListVariableRef<UnityEngine.Rigidbody2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody2D))]
	public sealed partial class Rigidbody2DListVar : ListVariableVar<UnityEngine.Rigidbody2D>
	{
	}
}
