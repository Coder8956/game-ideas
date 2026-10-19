
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontVariable : Variable<UnityEngine.Font>
	{
		
		public FontVariable()
		{
		}
		
		public FontVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontListVariable : ListVariable<UnityEngine.Font>
	{
		
		public FontListVariable()
		{
		}
		
		public FontListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontRef : VariableRef<UnityEngine.Font>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontVar : VariableVar<UnityEngine.Font>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontListRef : ListVariableRef<UnityEngine.Font>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Font))]
	public sealed partial class FontListVar : ListVariableVar<UnityEngine.Font>
	{
	}
}
