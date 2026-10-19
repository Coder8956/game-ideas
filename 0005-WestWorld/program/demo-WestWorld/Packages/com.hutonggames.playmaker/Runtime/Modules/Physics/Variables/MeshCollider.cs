
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderVariable : Variable<UnityEngine.MeshCollider>
	{
		
		public MeshColliderVariable()
		{
		}
		
		public MeshColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderListVariable : ListVariable<UnityEngine.MeshCollider>
	{
		
		public MeshColliderListVariable()
		{
		}
		
		public MeshColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderRef : BaseComponentRef<UnityEngine.MeshCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderVar : BaseComponentVar<UnityEngine.MeshCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderListRef : ListVariableRef<UnityEngine.MeshCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshCollider))]
	public sealed partial class MeshColliderListVar : ListVariableVar<UnityEngine.MeshCollider>
	{
	}
}
