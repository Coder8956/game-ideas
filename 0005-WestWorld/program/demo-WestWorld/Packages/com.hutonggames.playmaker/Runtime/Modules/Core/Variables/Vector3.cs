
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3Variable : Variable<Vector3>
	{
		
		public Vector3Variable()
		{
		}
		
		public Vector3Variable(string name) : 
				base(name)
		{
		}
		
		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(Vector2))
			{
				return (TAsType)(object)(Vector2) _value;
			}
            
			return base.GetValue<TAsType>();
		}
		
		public override void SetValue<TAsType>(TAsType value)
		{
			if (typeof(TAsType) == typeof(Vector2))
			{
				var v2 = (Vector2) (object) value;
				_value.Set(v2.x, v2.y, 0);
				return;
			}
			
			base.SetValue(value);
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3ListVariable : ListVariable<Vector3>
	{
		
		public Vector3ListVariable()
		{
		}
		
		public Vector3ListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3Ref : VariableRef<Vector3>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3Var : VariableVar<Vector3>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3ListRef : ListVariableRef<Vector3>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3ListVar : ListVariableVar<Vector3>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3Override : VariableOverride<Vector3,Vector3Variable,Vector3Var>
	{
		
		public Vector3Override(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector3))]
	public sealed partial class Vector3Output : VariableOutput<Vector3,Vector3Variable,Vector3Ref>
	{
		
		public Vector3Output(IVariable variable) : 
				base(variable)
		{
		}
	}
}
