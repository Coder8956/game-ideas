
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DVariable : Variable<UnityEngine.RigidbodyConstraints2D>
	{
		
		public RigidbodyConstraints2DVariable()
		{
		}
		
		public RigidbodyConstraints2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DListVariable : ListVariable<UnityEngine.RigidbodyConstraints2D>
	{
		
		public RigidbodyConstraints2DListVariable()
		{
		}
		
		public RigidbodyConstraints2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DRef : VariableRef<UnityEngine.RigidbodyConstraints2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DVar : VariableVar<UnityEngine.RigidbodyConstraints2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DListRef : ListVariableRef<UnityEngine.RigidbodyConstraints2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints2D))]
	public sealed partial class RigidbodyConstraints2DListVar : ListVariableVar<UnityEngine.RigidbodyConstraints2D>
	{
	}
}
