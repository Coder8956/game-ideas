
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneVariable : Variable<UnityEngine.PhysicsScene>
	{
		
		public PhysicsSceneVariable()
		{
		}
		
		public PhysicsSceneVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneListVariable : ListVariable<UnityEngine.PhysicsScene>
	{
		
		public PhysicsSceneListVariable()
		{
		}
		
		public PhysicsSceneListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneRef : VariableRef<UnityEngine.PhysicsScene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneVar : VariableVar<UnityEngine.PhysicsScene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneListRef : ListVariableRef<UnityEngine.PhysicsScene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PhysicsScene))]
	public sealed partial class PhysicsSceneListVar : ListVariableVar<UnityEngine.PhysicsScene>
	{
	}
}
