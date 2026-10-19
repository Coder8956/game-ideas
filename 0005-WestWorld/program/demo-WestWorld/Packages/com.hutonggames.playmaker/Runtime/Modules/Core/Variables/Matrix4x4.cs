
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4Variable : Variable<Matrix4x4>
	{
		
		public Matrix4x4Variable()
		{
		}
		
		public Matrix4x4Variable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4ListVariable : ListVariable<Matrix4x4>
	{
		
		public Matrix4x4ListVariable()
		{
		}
		
		public Matrix4x4ListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4Ref : VariableRef<Matrix4x4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4Var : VariableVar<Matrix4x4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4ListRef : ListVariableRef<Matrix4x4>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4ListVar : ListVariableVar<Matrix4x4>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4Override : VariableOverride<Matrix4x4, Matrix4x4Variable, Matrix4x4Var>
	{
		public Matrix4x4Override(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4Output : VariableOutput<Matrix4x4, Matrix4x4Variable, Matrix4x4Ref>
	{
		public Matrix4x4Output(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4ListOverride : VariableOverride<System.Collections.Generic.List<Matrix4x4>, Matrix4x4ListVariable, Matrix4x4ListVar>
	{
		public Matrix4x4ListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Matrix4x4))]
	public sealed partial class Matrix4x4ListOutput : VariableOutput<System.Collections.Generic.List<Matrix4x4>, Matrix4x4ListVariable, Matrix4x4ListRef>
	{
		public Matrix4x4ListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
