
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderVariable : Variable<UnityEngine.CapsuleCollider>
	{
		
		public CapsuleColliderVariable()
		{
		}
		
		public CapsuleColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderListVariable : ListVariable<UnityEngine.CapsuleCollider>
	{
		
		public CapsuleColliderListVariable()
		{
		}
		
		public CapsuleColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderRef : BaseComponentRef<UnityEngine.CapsuleCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderVar : BaseComponentVar<UnityEngine.CapsuleCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderListRef : ListVariableRef<UnityEngine.CapsuleCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleCollider))]
	public sealed partial class CapsuleColliderListVar : ListVariableVar<UnityEngine.CapsuleCollider>
	{
	}
}
