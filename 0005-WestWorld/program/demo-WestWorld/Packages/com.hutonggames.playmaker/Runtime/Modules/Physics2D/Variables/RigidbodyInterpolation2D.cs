
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DVariable : Variable<UnityEngine.RigidbodyInterpolation2D>
	{
		
		public RigidbodyInterpolation2DVariable()
		{
		}
		
		public RigidbodyInterpolation2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DListVariable : ListVariable<UnityEngine.RigidbodyInterpolation2D>
	{
		
		public RigidbodyInterpolation2DListVariable()
		{
		}
		
		public RigidbodyInterpolation2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DRef : VariableRef<UnityEngine.RigidbodyInterpolation2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DVar : VariableVar<UnityEngine.RigidbodyInterpolation2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DListRef : ListVariableRef<UnityEngine.RigidbodyInterpolation2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation2D))]
	public sealed partial class RigidbodyInterpolation2DListVar : ListVariableVar<UnityEngine.RigidbodyInterpolation2D>
	{
	}
}
