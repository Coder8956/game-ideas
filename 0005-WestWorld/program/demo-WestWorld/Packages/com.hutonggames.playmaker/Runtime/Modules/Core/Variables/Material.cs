
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialVariable : Variable<Material>
	{
		
		public MaterialVariable()
		{
		}
		
		public MaterialVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialListVariable : ListVariable<Material>
	{
		
		public MaterialListVariable()
		{
		}
		
		public MaterialListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialRef : VariableRef<Material>
	{
		
		
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialVar : VariableVar<Material>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialListRef : ListVariableRef<Material>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialListVar : ListVariableVar<Material>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialOverride : VariableOverride<Material, MaterialVariable, MaterialVar>
	{
		public MaterialOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class MaterialOutput : VariableOutput<Material, MaterialVariable, MaterialRef>
	{
		public MaterialOutput(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class
		MaterialListOverride : VariableOverride<List<Material>, MaterialListVariable, MaterialListVar>
	{
		public MaterialListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Material))]
	public sealed partial class
		MaterialListOutput : VariableOutput<List<Material>, MaterialListVariable, MaterialListRef>
	{
		public MaterialListOutput(IVariable variable) :
			base(variable)
		{
		}
	}
	
}
