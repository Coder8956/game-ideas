
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportVariable : Variable<UnityEngine.NPOTSupport>
	{
		
		public NPOTSupportVariable()
		{
		}
		
		public NPOTSupportVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportListVariable : ListVariable<UnityEngine.NPOTSupport>
	{
		
		public NPOTSupportListVariable()
		{
		}
		
		public NPOTSupportListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportRef : VariableRef<UnityEngine.NPOTSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportVar : VariableVar<UnityEngine.NPOTSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportListRef : ListVariableRef<UnityEngine.NPOTSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NPOTSupport))]
	public sealed partial class NPOTSupportListVar : ListVariableVar<UnityEngine.NPOTSupport>
	{
	}
}
