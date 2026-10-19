
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientVariable : Variable<TMPro.TMP_ColorGradient>
	{
		
		public TMP_ColorGradientVariable()
		{
		}
		
		public TMP_ColorGradientVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientListVariable : ListVariable<TMPro.TMP_ColorGradient>
	{
		
		public TMP_ColorGradientListVariable()
		{
		}
		
		public TMP_ColorGradientListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientRef : VariableRef<TMPro.TMP_ColorGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientVar : VariableVar<TMPro.TMP_ColorGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientListRef : ListVariableRef<TMPro.TMP_ColorGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_ColorGradient))]
	public sealed partial class TMP_ColorGradientListVar : ListVariableVar<TMPro.TMP_ColorGradient>
	{
	}
}
