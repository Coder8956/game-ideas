
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitVariable : Variable<UnityEngine.ColliderHit>
	{
		
		public ColliderHitVariable()
		{
		}
		
		public ColliderHitVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitListVariable : ListVariable<UnityEngine.ColliderHit>
	{
		
		public ColliderHitListVariable()
		{
		}
		
		public ColliderHitListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitRef : VariableRef<UnityEngine.ColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitVar : VariableVar<UnityEngine.ColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitListRef : ListVariableRef<UnityEngine.ColliderHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColliderHit))]
	public sealed partial class ColliderHitListVar : ListVariableVar<UnityEngine.ColliderHit>
	{
	}
}
