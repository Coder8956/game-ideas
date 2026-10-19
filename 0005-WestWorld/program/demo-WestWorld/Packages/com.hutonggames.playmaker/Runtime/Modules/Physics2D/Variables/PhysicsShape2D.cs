
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DVariable : Variable<UnityEngine.PhysicsShape2D>
	{
		
		public PhysicsShape2DVariable()
		{
		}
		
		public PhysicsShape2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DListVariable : ListVariable<UnityEngine.PhysicsShape2D>
	{
		
		public PhysicsShape2DListVariable()
		{
		}
		
		public PhysicsShape2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DRef : VariableRef<UnityEngine.PhysicsShape2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DVar : VariableVar<UnityEngine.PhysicsShape2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DListRef : ListVariableRef<UnityEngine.PhysicsShape2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShape2D))]
	public sealed partial class PhysicsShape2DListVar : ListVariableVar<UnityEngine.PhysicsShape2D>
	{
	}
}
