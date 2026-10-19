
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterVariable : Variable<UnityEngine.MeshFilter>
	{
		
		public MeshFilterVariable()
		{
		}
		
		public MeshFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterListVariable : ListVariable<UnityEngine.MeshFilter>
	{
		
		public MeshFilterListVariable()
		{
		}
		
		public MeshFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterRef : BaseComponentRef<UnityEngine.MeshFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterVar : BaseComponentVar<UnityEngine.MeshFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterListRef : ListVariableRef<UnityEngine.MeshFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MeshFilter))]
	public sealed partial class MeshFilterListVar : ListVariableVar<UnityEngine.MeshFilter>
	{
	}
}
