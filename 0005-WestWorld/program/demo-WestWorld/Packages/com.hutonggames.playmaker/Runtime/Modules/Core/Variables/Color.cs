
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorVariable : Variable<Color>
	{
		
		public ColorVariable()
		{
			Value = Color.white;
		}
		
		public ColorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListVariable : ListVariable<Color>
	{
		
		public ColorListVariable()
		{
		}
		
		public ColorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorRef : VariableRef<Color>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorVar : VariableVar<Color>
	{
		public override void Reset()
		{
			base.Reset();
			Value = Color.white;
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListRef : ListVariableRef<Color>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListVar : ListVariableVar<Color>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorOverride : VariableOverride<Color,ColorVariable,ColorVar>
	{
		
		public ColorOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorOutput : VariableOutput<Color,ColorVariable,ColorRef>
	{
		
		public ColorOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListOverride : VariableOverride<List<Color>, ColorListVariable, ColorListVar>
	{
		public ColorListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Color))]
	public sealed partial class ColorListOutput : VariableOutput<List<Color>, ColorListVariable, ColorListRef>
	{
		public ColorListOutput(IVariable variable) :
			base(variable)
		{
		}
	}

	
}
