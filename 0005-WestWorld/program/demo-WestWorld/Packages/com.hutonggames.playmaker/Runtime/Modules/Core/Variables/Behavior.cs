using System;
using System.Collections.Generic;

namespace HutongGames.PlayMaker
{
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourVariable : HutongGames.PlayMaker.Variable<UnityEngine.Behaviour>
	{
		
		public BehaviourVariable() : 
				base()
		{
		}
		
		public BehaviourVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourListVariable : HutongGames.PlayMaker.ListVariable<UnityEngine.Behaviour>
	{
		
		public BehaviourListVariable() : 
				base()
		{
		}
		
		public BehaviourListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourRef : HutongGames.PlayMaker.BaseComponentRef<UnityEngine.Behaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourVar : HutongGames.PlayMaker.BaseComponentVar<UnityEngine.Behaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourListRef : HutongGames.PlayMaker.ListVariableRef<UnityEngine.Behaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class BehaviourListVar : HutongGames.PlayMaker.ListVariableVar<UnityEngine.Behaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed class BehaviourOverride : HutongGames.PlayMaker.VariableOverride<UnityEngine.Behaviour, HutongGames.PlayMaker.BehaviourVariable, HutongGames.PlayMaker.BehaviourVar>
	{
		
		public BehaviourOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed class BehaviourOutput : HutongGames.PlayMaker.VariableOutput<UnityEngine.Behaviour, HutongGames.PlayMaker.BehaviourVariable, HutongGames.PlayMaker.BehaviourRef>
	{
		
		public BehaviourOutput(IVariable variable) : 
				base(variable)
		{
		}
	}


	[Serializable]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class
		BehaviourListOverride : VariableOverride<List<UnityEngine.Behaviour>, BehaviourListVariable, BehaviourListVar>
	{
		public BehaviourListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Behaviour))]
	public sealed partial class
		BehaviourListOutput : VariableOutput<List<UnityEngine.Behaviour>, BehaviourListVariable, BehaviourListRef>
	{
		public BehaviourListOutput(IVariable variable) :
			base(variable)
		{
		}
	}

}