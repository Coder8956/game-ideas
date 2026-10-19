
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextVariable : Variable<UnityEngine.UI.Text>
	{
		
		public TextVariable()
		{
		}
		
		public TextVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextListVariable : ListVariable<UnityEngine.UI.Text>
	{
		
		public TextListVariable()
		{
		}
		
		public TextListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextRef : BaseComponentRef<UnityEngine.UI.Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextVar : BaseComponentVar<UnityEngine.UI.Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextListRef : ListVariableRef<UnityEngine.UI.Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Text))]
	public sealed partial class TextListVar : ListVariableVar<UnityEngine.UI.Text>
	{
	}
}
