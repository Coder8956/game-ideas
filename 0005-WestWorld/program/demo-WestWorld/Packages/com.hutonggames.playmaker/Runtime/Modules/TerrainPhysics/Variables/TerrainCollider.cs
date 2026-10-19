
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderVariable : Variable<UnityEngine.TerrainCollider>
	{
		
		public TerrainColliderVariable()
		{
		}
		
		public TerrainColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderListVariable : ListVariable<UnityEngine.TerrainCollider>
	{
		
		public TerrainColliderListVariable()
		{
		}
		
		public TerrainColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderRef : BaseComponentRef<UnityEngine.TerrainCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderVar : BaseComponentVar<UnityEngine.TerrainCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderListRef : ListVariableRef<UnityEngine.TerrainCollider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TerrainCollider))]
	public sealed partial class TerrainColliderListVar : ListVariableVar<UnityEngine.TerrainCollider>
	{
	}
}
