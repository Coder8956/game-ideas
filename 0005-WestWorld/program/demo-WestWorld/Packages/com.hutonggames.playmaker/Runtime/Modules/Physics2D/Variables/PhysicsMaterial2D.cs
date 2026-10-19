
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DVariable : Variable<UnityEngine.PhysicsMaterial2D>
	{
		
		public PhysicsMaterial2DVariable()
		{
		}
		
		public PhysicsMaterial2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DListVariable : ListVariable<UnityEngine.PhysicsMaterial2D>
	{
		
		public PhysicsMaterial2DListVariable()
		{
		}
		
		public PhysicsMaterial2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DRef : VariableRef<UnityEngine.PhysicsMaterial2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DVar : VariableVar<UnityEngine.PhysicsMaterial2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DListRef : ListVariableRef<UnityEngine.PhysicsMaterial2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsMaterial2D))]
	public sealed partial class PhysicsMaterial2DListVar : ListVariableVar<UnityEngine.PhysicsMaterial2D>
	{
	}
}
