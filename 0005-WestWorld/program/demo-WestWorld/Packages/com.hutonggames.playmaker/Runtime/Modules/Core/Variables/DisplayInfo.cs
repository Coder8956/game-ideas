
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoVariable : Variable<UnityEngine.DisplayInfo>
	{
		
		public DisplayInfoVariable()
		{
		}
		
		public DisplayInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoListVariable : ListVariable<UnityEngine.DisplayInfo>
	{
		
		public DisplayInfoListVariable()
		{
		}
		
		public DisplayInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoRef : VariableRef<UnityEngine.DisplayInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoVar : VariableVar<UnityEngine.DisplayInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoListRef : ListVariableRef<UnityEngine.DisplayInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DisplayInfo))]
	public sealed partial class DisplayInfoListVar : ListVariableVar<UnityEngine.DisplayInfo>
	{
	}
}
