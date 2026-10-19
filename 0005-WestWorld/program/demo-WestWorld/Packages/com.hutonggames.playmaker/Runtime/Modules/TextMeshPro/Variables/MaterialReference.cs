
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceVariable : Variable<TMPro.MaterialReference>
	{
		
		public MaterialReferenceVariable()
		{
		}
		
		public MaterialReferenceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceListVariable : ListVariable<TMPro.MaterialReference>
	{
		
		public MaterialReferenceListVariable()
		{
		}
		
		public MaterialReferenceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceRef : VariableRef<TMPro.MaterialReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceVar : VariableVar<TMPro.MaterialReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceListRef : ListVariableRef<TMPro.MaterialReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.MaterialReference))]
	public sealed partial class MaterialReferenceListVar : ListVariableVar<TMPro.MaterialReference>
	{
	}
}
