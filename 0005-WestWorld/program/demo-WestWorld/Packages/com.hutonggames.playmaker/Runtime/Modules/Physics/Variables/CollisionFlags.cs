
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsVariable : Variable<UnityEngine.CollisionFlags>
	{
		
		public CollisionFlagsVariable()
		{
		}
		
		public CollisionFlagsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsListVariable : ListVariable<UnityEngine.CollisionFlags>
	{
		
		public CollisionFlagsListVariable()
		{
		}
		
		public CollisionFlagsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsRef : VariableRef<UnityEngine.CollisionFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsVar : VariableVar<UnityEngine.CollisionFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsListRef : ListVariableRef<UnityEngine.CollisionFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CollisionFlags))]
	public sealed partial class CollisionFlagsListVar : ListVariableVar<UnityEngine.CollisionFlags>
	{
	}
}
