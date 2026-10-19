
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4Variable : Variable<Vector4>
	{
		
		public Vector4Variable()
		{
		}
		
		public Vector4Variable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4ListVariable : ListVariable<Vector4>
	{
		
		public Vector4ListVariable()
		{
		}
		
		public Vector4ListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4Ref : VariableRef<Vector4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4Var : VariableVar<Vector4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4ListRef : ListVariableRef<Vector4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector4))]
	public sealed partial class Vector4ListVar : ListVariableVar<Vector4>
	{
	}
}
