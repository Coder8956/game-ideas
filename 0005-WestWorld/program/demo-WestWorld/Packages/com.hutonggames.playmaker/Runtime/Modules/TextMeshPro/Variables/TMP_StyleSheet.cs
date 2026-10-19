
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetVariable : Variable<TMPro.TMP_StyleSheet>
	{
		
		public TMP_StyleSheetVariable()
		{
		}
		
		public TMP_StyleSheetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetListVariable : ListVariable<TMPro.TMP_StyleSheet>
	{
		
		public TMP_StyleSheetListVariable()
		{
		}
		
		public TMP_StyleSheetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetRef : VariableRef<TMPro.TMP_StyleSheet>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetVar : VariableVar<TMPro.TMP_StyleSheet>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetListRef : ListVariableRef<TMPro.TMP_StyleSheet>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_StyleSheet))]
	public sealed partial class TMP_StyleSheetListVar : ListVariableVar<TMPro.TMP_StyleSheet>
	{
	}
}
