
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsVariable : Variable<UnityEngine.MeshColliderCookingOptions>
	{
		
		public MeshColliderCookingOptionsVariable()
		{
		}
		
		public MeshColliderCookingOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsListVariable : ListVariable<UnityEngine.MeshColliderCookingOptions>
	{
		
		public MeshColliderCookingOptionsListVariable()
		{
		}
		
		public MeshColliderCookingOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsRef : VariableRef<UnityEngine.MeshColliderCookingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsVar : VariableVar<UnityEngine.MeshColliderCookingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsListRef : ListVariableRef<UnityEngine.MeshColliderCookingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshColliderCookingOptions))]
	public sealed partial class MeshColliderCookingOptionsListVar : ListVariableVar<UnityEngine.MeshColliderCookingOptions>
	{
	}
}
