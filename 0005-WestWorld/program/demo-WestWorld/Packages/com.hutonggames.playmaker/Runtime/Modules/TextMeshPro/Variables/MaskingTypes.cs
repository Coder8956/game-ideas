
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesVariable : Variable<TMPro.MaskingTypes>
	{
		
		public MaskingTypesVariable()
		{
		}
		
		public MaskingTypesVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesListVariable : ListVariable<TMPro.MaskingTypes>
	{
		
		public MaskingTypesListVariable()
		{
		}
		
		public MaskingTypesListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesRef : VariableRef<TMPro.MaskingTypes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesVar : VariableVar<TMPro.MaskingTypes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesListRef : ListVariableRef<TMPro.MaskingTypes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaskingTypes))]
	public sealed partial class MaskingTypesListVar : ListVariableVar<TMPro.MaskingTypes>
	{
	}
}
