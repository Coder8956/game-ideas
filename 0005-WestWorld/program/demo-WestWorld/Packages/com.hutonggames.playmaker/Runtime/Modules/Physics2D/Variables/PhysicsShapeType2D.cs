
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DVariable : Variable<UnityEngine.PhysicsShapeType2D>
	{
		
		public PhysicsShapeType2DVariable()
		{
		}
		
		public PhysicsShapeType2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DListVariable : ListVariable<UnityEngine.PhysicsShapeType2D>
	{
		
		public PhysicsShapeType2DListVariable()
		{
		}
		
		public PhysicsShapeType2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DRef : VariableRef<UnityEngine.PhysicsShapeType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DVar : VariableVar<UnityEngine.PhysicsShapeType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DListRef : ListVariableRef<UnityEngine.PhysicsShapeType2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsShapeType2D))]
	public sealed partial class PhysicsShapeType2DListVar : ListVariableVar<UnityEngine.PhysicsShapeType2D>
	{
	}
}
