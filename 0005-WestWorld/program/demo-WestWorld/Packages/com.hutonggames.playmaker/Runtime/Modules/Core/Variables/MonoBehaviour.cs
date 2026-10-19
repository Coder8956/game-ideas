using UnityEngine;

namespace HutongGames.PlayMaker
{
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourVariable : HutongGames.PlayMaker.Variable<UnityEngine.MonoBehaviour>
	{
		
		public MonoBehaviourVariable() : 
				base()
		{
		}
		
		public MonoBehaviourVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourListVariable : HutongGames.PlayMaker.ListVariable<UnityEngine.MonoBehaviour>
	{
		
		public MonoBehaviourListVariable() : 
				base()
		{
		}
		
		public MonoBehaviourListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourRef : HutongGames.PlayMaker.VariableRef<UnityEngine.MonoBehaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourVar : HutongGames.PlayMaker.VariableVar<UnityEngine.MonoBehaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourListRef : HutongGames.PlayMaker.ListVariableRef<UnityEngine.MonoBehaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed partial class MonoBehaviourListVar : HutongGames.PlayMaker.ListVariableVar<UnityEngine.MonoBehaviour>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed class MonoBehaviourOverride : HutongGames.PlayMaker.VariableOverride<UnityEngine.MonoBehaviour, HutongGames.PlayMaker.MonoBehaviourVariable, HutongGames.PlayMaker.MonoBehaviourVar>
	{
		
		public MonoBehaviourOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(MonoBehaviour))]
	public sealed class MonoBehaviourOutput : HutongGames.PlayMaker.VariableOutput<UnityEngine.MonoBehaviour, HutongGames.PlayMaker.MonoBehaviourVariable, HutongGames.PlayMaker.MonoBehaviourRef>
	{
		
		public MonoBehaviourOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}