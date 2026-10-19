
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformVariable : Variable<Transform>
	{
		
		public GameObject GameObject => Value ? Value.gameObject : null;
		
		public TransformVariable()
		{
		}
		
		public TransformVariable(string name) : 
				base(name)
		{
		}
		
				
		public override TAsType GetValue<TAsType>()
		{
			// Convert null to bool value
			if (typeof(TAsType) == typeof(bool))
			{
				return (TAsType)(object)(_value != null);
			}

			if (!_value) return default;
			
			if (typeof(TAsType).IsSubclassOf(typeof(Component)))
			{
				return _value.GetComponent<TAsType>();
			}
            
			return base.GetValue<TAsType>();
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformListVariable : ListVariable<Transform>
	{
		
		public TransformListVariable()
		{
		}
		
		public TransformListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformRef : BaseComponentRef<Transform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformVar : BaseComponentVar<Transform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformListRef : ListVariableRef<Transform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformListVar : ListVariableVar<Transform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformListOverride : VariableOverride<List<Transform>,TransformListVariable,TransformListVar>
	{
		public TransformListOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformListOutput : VariableOutput<List<Transform>,TransformListVariable,TransformListRef>
	{
		public TransformListOutput(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformOverride : VariableOverride<Transform,TransformVariable,TransformVar>
	{
		
		public TransformOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Transform))]
	public sealed partial class TransformOutput : VariableOutput<Transform,TransformVariable,TransformRef>
	{
		
		public TransformOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
