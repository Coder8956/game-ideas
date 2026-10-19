using System;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectVariable : Variable<UnityEngine.Object>
	{
		
		public ObjectVariable() : 
				base()
		{
		}
		
		public ObjectVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectListVariable : ListVariable<UnityEngine.Object>
	{
		
		public ObjectListVariable() : 
				base()
		{
		}
		
		public ObjectListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectRef : VariableRef<UnityEngine.Object>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectVar : VariableVar<UnityEngine.Object>
	{
	}
	
	[Serializable]	
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectListRef : ListVariableRef<UnityEngine.Object>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed partial class ObjectListVar : ListVariableVar<UnityEngine.Object>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed class ObjectOverride : VariableOverride<UnityEngine.Object, ObjectVariable, ObjectVar>
	{
		
		public ObjectOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Object))]
	public sealed class ObjectOutput : VariableOutput<UnityEngine.Object, ObjectVariable, ObjectRef>
	{
		
		public ObjectOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}