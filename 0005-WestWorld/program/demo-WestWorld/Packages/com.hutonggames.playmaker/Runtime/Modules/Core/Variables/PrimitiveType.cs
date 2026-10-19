
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeVariable : Variable<PrimitiveType>
	{
		
		public PrimitiveTypeVariable()
		{
		}
		
		public PrimitiveTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeListVariable : ListVariable<PrimitiveType>
	{
		
		public PrimitiveTypeListVariable()
		{
		}
		
		public PrimitiveTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeRef : VariableRef<PrimitiveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeVar : VariableVar<PrimitiveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeListRef : ListVariableRef<PrimitiveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeListVar : ListVariableVar<PrimitiveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeOverride : VariableOverride<PrimitiveType,PrimitiveTypeVariable,PrimitiveTypeVar>
	{
		
		public PrimitiveTypeOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PrimitiveType))]
	public sealed partial class PrimitiveTypeOutput : VariableOutput<PrimitiveType,PrimitiveTypeVariable,PrimitiveTypeRef>
	{
		
		public PrimitiveTypeOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
