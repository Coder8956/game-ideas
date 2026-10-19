
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DVariable : Variable<UnityEngine.PhysicsScene2D>
	{
		
		public PhysicsScene2DVariable()
		{
		}
		
		public PhysicsScene2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DListVariable : ListVariable<UnityEngine.PhysicsScene2D>
	{
		
		public PhysicsScene2DListVariable()
		{
		}
		
		public PhysicsScene2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DRef : VariableRef<UnityEngine.PhysicsScene2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DVar : VariableVar<UnityEngine.PhysicsScene2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DListRef : ListVariableRef<UnityEngine.PhysicsScene2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene2D))]
	public sealed partial class PhysicsScene2DListVar : ListVariableVar<UnityEngine.PhysicsScene2D>
	{
	}
}
