
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockVariable : Variable<UnityEngine.UI.ColorBlock>
	{
		
		public ColorBlockVariable()
		{
		}
		
		public ColorBlockVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockListVariable : ListVariable<UnityEngine.UI.ColorBlock>
	{
		
		public ColorBlockListVariable()
		{
		}
		
		public ColorBlockListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockRef : VariableRef<UnityEngine.UI.ColorBlock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockVar : VariableVar<UnityEngine.UI.ColorBlock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockListRef : ListVariableRef<UnityEngine.UI.ColorBlock>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ColorBlock))]
	public sealed partial class ColorBlockListVar : ListVariableVar<UnityEngine.UI.ColorBlock>
	{
	}
}
