
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderVariable : Variable<Shader>
	{
		
		public ShaderVariable()
		{
		}
		
		public ShaderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderListVariable : ListVariable<Shader>
	{
		
		public ShaderListVariable()
		{
		}
		
		public ShaderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderRef : VariableRef<Shader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderVar : VariableVar<Shader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderListRef : ListVariableRef<Shader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Shader))]
	public sealed partial class ShaderListVar : ListVariableVar<Shader>
	{
	}
}
