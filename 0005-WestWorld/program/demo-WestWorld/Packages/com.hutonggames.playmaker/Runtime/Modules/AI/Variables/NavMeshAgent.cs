
using System;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentVariable : Variable<UnityEngine.AI.NavMeshAgent>
	{
		
		public NavMeshAgentVariable()
		{
		}
		
		public NavMeshAgentVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentListVariable : ListVariable<UnityEngine.AI.NavMeshAgent>
	{
		
		public NavMeshAgentListVariable()
		{
		}
		
		public NavMeshAgentListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentRef : BaseComponentRef<UnityEngine.AI.NavMeshAgent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentVar : BaseComponentVar<UnityEngine.AI.NavMeshAgent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentListRef : ListVariableRef<UnityEngine.AI.NavMeshAgent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentListVar : ListVariableVar<UnityEngine.AI.NavMeshAgent>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentOverride : VariableOverride<UnityEngine.AI.NavMeshAgent, NavMeshAgentVariable, NavMeshAgentVar>
	{
		public NavMeshAgentOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentOutput : VariableOutput<UnityEngine.AI.NavMeshAgent, NavMeshAgentVariable, NavMeshAgentRef>
	{
		public NavMeshAgentOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.AI.NavMeshAgent>, NavMeshAgentListVariable, NavMeshAgentListVar>
	{
		public NavMeshAgentListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AI.NavMeshAgent))]
	public sealed partial class NavMeshAgentListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.AI.NavMeshAgent>, NavMeshAgentListVariable, NavMeshAgentListRef>
	{
		public NavMeshAgentListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
