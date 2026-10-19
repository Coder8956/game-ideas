
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DVariable : Variable<UnityEngine.RigidbodyType2D>
	{
		
		public RigidbodyType2DVariable()
		{
		}
		
		public RigidbodyType2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DListVariable : ListVariable<UnityEngine.RigidbodyType2D>
	{
		
		public RigidbodyType2DListVariable()
		{
		}
		
		public RigidbodyType2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DRef : VariableRef<UnityEngine.RigidbodyType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DVar : VariableVar<UnityEngine.RigidbodyType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DListRef : ListVariableRef<UnityEngine.RigidbodyType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyType2D))]
	public sealed partial class RigidbodyType2DListVar : ListVariableVar<UnityEngine.RigidbodyType2D>
	{
	}
}
