using UnityEngine;

namespace HutongGames.PlayMaker
{
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionVariable : HutongGames.PlayMaker.Variable<UnityEngine.Quaternion>
	{
		
		public QuaternionVariable() : 
				base()
		{
		}
		
		public QuaternionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionListVariable : HutongGames.PlayMaker.ListVariable<UnityEngine.Quaternion>
	{
		
		public QuaternionListVariable() : 
				base()
		{
		}
		
		public QuaternionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionRef : HutongGames.PlayMaker.VariableRef<UnityEngine.Quaternion>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionVar : HutongGames.PlayMaker.VariableVar<UnityEngine.Quaternion>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionListRef : HutongGames.PlayMaker.ListVariableRef<UnityEngine.Quaternion>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionListVar : HutongGames.PlayMaker.ListVariableVar<UnityEngine.Quaternion>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed class QuaternionOverride : HutongGames.PlayMaker.VariableOverride<UnityEngine.Quaternion, HutongGames.PlayMaker.QuaternionVariable, HutongGames.PlayMaker.QuaternionVar>
	{
		
		public QuaternionOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed class QuaternionOutput : HutongGames.PlayMaker.VariableOutput<UnityEngine.Quaternion, HutongGames.PlayMaker.QuaternionVariable, HutongGames.PlayMaker.QuaternionRef>
	{
		
		public QuaternionOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionListOverride : HutongGames.PlayMaker.VariableOverride<System.Collections.Generic.List<UnityEngine.Quaternion>, HutongGames.PlayMaker.QuaternionListVariable, HutongGames.PlayMaker.QuaternionListVar>
	{
		public QuaternionListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[global::System.SerializableAttribute()]
	[DataType(typeof(Quaternion))]
	public sealed partial class QuaternionListOutput : HutongGames.PlayMaker.VariableOutput<System.Collections.Generic.List<UnityEngine.Quaternion>, HutongGames.PlayMaker.QuaternionListVariable, HutongGames.PlayMaker.QuaternionListRef>
	{
		public QuaternionListOutput(IVariable variable) :
			base(variable)
		{
		}
	}

}