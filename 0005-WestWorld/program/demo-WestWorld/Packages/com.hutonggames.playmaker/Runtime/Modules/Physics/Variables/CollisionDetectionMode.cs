
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeVariable : Variable<UnityEngine.CollisionDetectionMode>
	{
		
		public CollisionDetectionModeVariable()
		{
		}
		
		public CollisionDetectionModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeListVariable : ListVariable<UnityEngine.CollisionDetectionMode>
	{
		
		public CollisionDetectionModeListVariable()
		{
		}
		
		public CollisionDetectionModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeRef : VariableRef<UnityEngine.CollisionDetectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeVar : VariableVar<UnityEngine.CollisionDetectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeListRef : ListVariableRef<UnityEngine.CollisionDetectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionDetectionMode))]
	public sealed partial class CollisionDetectionModeListVar : ListVariableVar<UnityEngine.CollisionDetectionMode>
	{
	}
}
