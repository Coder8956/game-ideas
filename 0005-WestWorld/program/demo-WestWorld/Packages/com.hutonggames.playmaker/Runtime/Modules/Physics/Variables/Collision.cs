
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionVariable : Variable<UnityEngine.Collision>
	{
		
		public CollisionVariable()
		{
		}
		
		public CollisionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionListVariable : ListVariable<UnityEngine.Collision>
	{
		
		public CollisionListVariable()
		{
		}
		
		public CollisionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionRef : VariableRef<UnityEngine.Collision>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionVar : VariableVar<UnityEngine.Collision>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionListRef : ListVariableRef<UnityEngine.Collision>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision))]
	public sealed partial class CollisionListVar : ListVariableVar<UnityEngine.Collision>
	{
	}
}
