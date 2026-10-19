
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeVariable : Variable<UnityEngine.PenEventType>
	{
		
		public PenEventTypeVariable()
		{
		}
		
		public PenEventTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeListVariable : ListVariable<UnityEngine.PenEventType>
	{
		
		public PenEventTypeListVariable()
		{
		}
		
		public PenEventTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeRef : VariableRef<UnityEngine.PenEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeVar : VariableVar<UnityEngine.PenEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeListRef : ListVariableRef<UnityEngine.PenEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenEventType))]
	public sealed partial class PenEventTypeListVar : ListVariableVar<UnityEngine.PenEventType>
	{
	}
}
