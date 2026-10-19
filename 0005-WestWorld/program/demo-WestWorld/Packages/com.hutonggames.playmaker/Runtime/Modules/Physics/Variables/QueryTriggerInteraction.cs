
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionVariable : Variable<UnityEngine.QueryTriggerInteraction>
	{
		
		public QueryTriggerInteractionVariable()
		{
		}
		
		public QueryTriggerInteractionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionListVariable : ListVariable<UnityEngine.QueryTriggerInteraction>
	{
		
		public QueryTriggerInteractionListVariable()
		{
		}
		
		public QueryTriggerInteractionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionRef : VariableRef<UnityEngine.QueryTriggerInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionVar : VariableVar<UnityEngine.QueryTriggerInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionListRef : ListVariableRef<UnityEngine.QueryTriggerInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.QueryTriggerInteraction))]
	public sealed partial class QueryTriggerInteractionListVar : ListVariableVar<UnityEngine.QueryTriggerInteraction>
	{
	}
}
