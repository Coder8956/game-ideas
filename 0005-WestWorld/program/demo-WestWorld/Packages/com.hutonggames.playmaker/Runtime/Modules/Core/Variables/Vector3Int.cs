
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntVariable : Variable<UnityEngine.Vector3Int>
	{
		
		public Vector3IntVariable()
		{
		}
		
		public Vector3IntVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntListVariable : ListVariable<UnityEngine.Vector3Int>
	{
		
		public Vector3IntListVariable()
		{
		}
		
		public Vector3IntListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntRef : VariableRef<UnityEngine.Vector3Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntVar : VariableVar<UnityEngine.Vector3Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntListRef : ListVariableRef<UnityEngine.Vector3Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3Int))]
	public sealed partial class Vector3IntListVar : ListVariableVar<UnityEngine.Vector3Int>
	{
	}
}
