
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitVariable : Variable<UnityEngine.AI.NavMeshHit>
	{
		
		public NavMeshHitVariable()
		{
		}
		
		public NavMeshHitVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitListVariable : ListVariable<UnityEngine.AI.NavMeshHit>
	{
		
		public NavMeshHitListVariable()
		{
		}
		
		public NavMeshHitListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitRef : VariableRef<UnityEngine.AI.NavMeshHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitVar : VariableVar<UnityEngine.AI.NavMeshHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitListRef : ListVariableRef<UnityEngine.AI.NavMeshHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshHit))]
	public sealed partial class NavMeshHitListVar : ListVariableVar<UnityEngine.AI.NavMeshHit>
	{
	}
}
