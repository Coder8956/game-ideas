
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProVariable : Variable<TMPro.TextMeshPro>
	{
		
		public TextMeshProVariable()
		{
		}
		
		public TextMeshProVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProListVariable : ListVariable<TMPro.TextMeshPro>
	{
		
		public TextMeshProListVariable()
		{
		}
		
		public TextMeshProListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProRef : BaseComponentRef<TMPro.TextMeshPro>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProVar : BaseComponentVar<TMPro.TextMeshPro>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProListRef : ListVariableRef<TMPro.TextMeshPro>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshPro))]
	public sealed partial class TextMeshProListVar : ListVariableVar<TMPro.TextMeshPro>
	{
	}
}
