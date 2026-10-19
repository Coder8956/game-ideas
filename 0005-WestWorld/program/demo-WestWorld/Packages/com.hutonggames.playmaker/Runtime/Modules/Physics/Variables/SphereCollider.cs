
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderVariable : Variable<UnityEngine.SphereCollider>
	{
		
		public SphereColliderVariable()
		{
		}
		
		public SphereColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderListVariable : ListVariable<UnityEngine.SphereCollider>
	{
		
		public SphereColliderListVariable()
		{
		}
		
		public SphereColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderRef : BaseComponentRef<UnityEngine.SphereCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderVar : BaseComponentVar<UnityEngine.SphereCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderListRef : ListVariableRef<UnityEngine.SphereCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SphereCollider))]
	public sealed partial class SphereColliderListVar : ListVariableVar<UnityEngine.SphereCollider>
	{
	}
}
