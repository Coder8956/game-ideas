
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityVariable : Variable<UnityEngine.ThreadPriority>
	{
		
		public ThreadPriorityVariable()
		{
		}
		
		public ThreadPriorityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityListVariable : ListVariable<UnityEngine.ThreadPriority>
	{
		
		public ThreadPriorityListVariable()
		{
		}
		
		public ThreadPriorityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityRef : VariableRef<UnityEngine.ThreadPriority>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityVar : VariableVar<UnityEngine.ThreadPriority>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityListRef : ListVariableRef<UnityEngine.ThreadPriority>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ThreadPriority))]
	public sealed partial class ThreadPriorityListVar : ListVariableVar<UnityEngine.ThreadPriority>
	{
	}
}
