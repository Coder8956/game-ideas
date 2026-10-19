
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DVariable : Variable<UnityEngine.ConstantForce2D>
	{
		
		public ConstantForce2DVariable()
		{
		}
		
		public ConstantForce2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DListVariable : ListVariable<UnityEngine.ConstantForce2D>
	{
		
		public ConstantForce2DListVariable()
		{
		}
		
		public ConstantForce2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DRef : BaseComponentRef<UnityEngine.ConstantForce2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DVar : BaseComponentVar<UnityEngine.ConstantForce2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DListRef : ListVariableRef<UnityEngine.ConstantForce2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce2D))]
	public sealed partial class ConstantForce2DListVar : ListVariableVar<UnityEngine.ConstantForce2D>
	{
	}
}
