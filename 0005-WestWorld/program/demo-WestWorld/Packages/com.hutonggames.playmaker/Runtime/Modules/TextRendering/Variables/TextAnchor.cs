
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorVariable : Variable<UnityEngine.TextAnchor>
	{
		
		public TextAnchorVariable()
		{
		}
		
		public TextAnchorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorListVariable : ListVariable<UnityEngine.TextAnchor>
	{
		
		public TextAnchorListVariable()
		{
		}
		
		public TextAnchorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorRef : VariableRef<UnityEngine.TextAnchor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorVar : VariableVar<UnityEngine.TextAnchor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorListRef : ListVariableRef<UnityEngine.TextAnchor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAnchor))]
	public sealed partial class TextAnchorListVar : ListVariableVar<UnityEngine.TextAnchor>
	{
	}
}
