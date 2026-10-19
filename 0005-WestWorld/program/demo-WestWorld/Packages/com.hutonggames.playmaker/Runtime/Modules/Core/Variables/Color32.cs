
using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32Variable : Variable<UnityEngine.Color32>
	{
		
		public Color32Variable()
		{
		}
		
		public Color32Variable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32ListVariable : ListVariable<UnityEngine.Color32>
	{
		
		public Color32ListVariable()
		{
		}
		
		public Color32ListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32Ref : VariableRef<UnityEngine.Color32>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32Var : VariableVar<UnityEngine.Color32>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32ListRef : ListVariableRef<UnityEngine.Color32>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color32))]
	public sealed partial class Color32ListVar : ListVariableVar<UnityEngine.Color32>
	{
	}
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListOverride : VariableOverride<List<UnityEngine.Color>, ColorListVariable, ColorListVar>
	{
		public ColorListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListOutput : VariableOutput<List<UnityEngine.Color>, ColorListVariable, ColorListRef>
	{
		public ColorListOutput(IVariable variable) :
			base(variable)
		{
		}
	}

}
