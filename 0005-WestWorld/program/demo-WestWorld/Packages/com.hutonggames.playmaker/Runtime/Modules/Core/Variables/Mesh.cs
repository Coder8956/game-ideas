
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshVariable : Variable<Mesh>
	{
		
		public MeshVariable()
		{
		}
		
		public MeshVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshListVariable : ListVariable<Mesh>
	{
		
		public MeshListVariable()
		{
		}
		
		public MeshListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshRef : VariableRef<Mesh>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshVar : VariableVar<Mesh>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshListRef : ListVariableRef<Mesh>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Mesh))]
	public sealed partial class MeshListVar : ListVariableVar<Mesh>
	{
	}
}
