
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitVariable : Variable<UnityEngine.ControllerColliderHit>
	{
		
		public ControllerColliderHitVariable()
		{
		}
		
		public ControllerColliderHitVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitListVariable : ListVariable<UnityEngine.ControllerColliderHit>
	{
		
		public ControllerColliderHitListVariable()
		{
		}
		
		public ControllerColliderHitListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitRef : VariableRef<UnityEngine.ControllerColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitVar : VariableVar<UnityEngine.ControllerColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitListRef : ListVariableRef<UnityEngine.ControllerColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ControllerColliderHit))]
	public sealed partial class ControllerColliderHitListVar : ListVariableVar<UnityEngine.ControllerColliderHit>
	{
	}
}
