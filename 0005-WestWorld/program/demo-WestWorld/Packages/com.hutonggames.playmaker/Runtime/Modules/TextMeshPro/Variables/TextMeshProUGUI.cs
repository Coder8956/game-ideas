
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIVariable : Variable<TMPro.TextMeshProUGUI>
	{
		
		public TextMeshProUGUIVariable()
		{
		}
		
		public TextMeshProUGUIVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIListVariable : ListVariable<TMPro.TextMeshProUGUI>
	{
		
		public TextMeshProUGUIListVariable()
		{
		}
		
		public TextMeshProUGUIListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIRef : BaseComponentRef<TMPro.TextMeshProUGUI>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIVar : BaseComponentVar<TMPro.TextMeshProUGUI>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIListRef : ListVariableRef<TMPro.TextMeshProUGUI>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextMeshProUGUI))]
	public sealed partial class TextMeshProUGUIListVar : ListVariableVar<TMPro.TextMeshProUGUI>
	{
	}
}
