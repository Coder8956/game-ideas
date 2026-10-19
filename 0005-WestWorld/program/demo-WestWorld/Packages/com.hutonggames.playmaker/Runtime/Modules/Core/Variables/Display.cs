
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayVariable : Variable<UnityEngine.Display>
	{
		
		public DisplayVariable()
		{
		}
		
		public DisplayVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayListVariable : ListVariable<UnityEngine.Display>
	{
		
		public DisplayListVariable()
		{
		}
		
		public DisplayListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayRef : VariableRef<UnityEngine.Display>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayVar : VariableVar<UnityEngine.Display>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayListRef : ListVariableRef<UnityEngine.Display>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Display))]
	public sealed partial class DisplayListVar : ListVariableVar<UnityEngine.Display>
	{
	}
}
