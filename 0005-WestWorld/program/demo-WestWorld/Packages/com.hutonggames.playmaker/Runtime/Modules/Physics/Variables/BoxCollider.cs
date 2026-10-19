
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderVariable : Variable<UnityEngine.BoxCollider>
	{
		
		public BoxColliderVariable()
		{
		}
		
		public BoxColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderListVariable : ListVariable<UnityEngine.BoxCollider>
	{
		
		public BoxColliderListVariable()
		{
		}
		
		public BoxColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderRef : BaseComponentRef<UnityEngine.BoxCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderVar : BaseComponentVar<UnityEngine.BoxCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderListRef : ListVariableRef<UnityEngine.BoxCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BoxCollider))]
	public sealed partial class BoxColliderListVar : ListVariableVar<UnityEngine.BoxCollider>
	{
	}
}
