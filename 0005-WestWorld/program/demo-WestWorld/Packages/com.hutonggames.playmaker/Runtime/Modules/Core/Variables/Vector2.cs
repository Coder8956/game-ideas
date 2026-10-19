
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2Variable : Variable<Vector2>
	{
		
		public Vector2Variable()
		{
		}
		
		public Vector2Variable(string name) : 
				base(name)
		{
		}
		
		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(Vector3))
			{
				return (TAsType)(object)(Vector3) _value;
			}
			if (typeof(TAsType) == typeof(Vector2Int))
			{
				return (TAsType)(object) new Vector2Int(
					Mathf.RoundToInt(_value.x),
					Mathf.RoundToInt(_value.y)
				);
			}
            
			return base.GetValue<TAsType>();
		}
		
		public override void SetValue<TAsType>(TAsType value)
		{
			if (typeof(TAsType) == typeof(Vector3))
			{
				var v2 = (Vector3) (object) value;
				_value.Set(v2.x, v2.y);
				return;
			}
			
			if (value is Vector2Int vector2Int)
			{
				_value = new Vector2Int(vector2Int.x, vector2Int.y
				);
				return;
			}
			
			base.SetValue(value);
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2ListVariable : ListVariable<Vector2>
	{
		
		public Vector2ListVariable()
		{
		}
		
		public Vector2ListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2Ref : VariableRef<Vector2>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2Var : VariableVar<Vector2>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2ListRef : ListVariableRef<Vector2>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2ListVar : ListVariableVar<Vector2>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2Override : VariableOverride<Vector2,Vector2Variable,Vector2Var>
	{
		
		public Vector2Override(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2))]
	public sealed partial class Vector2Output : VariableOutput<Vector2,Vector2Variable,Vector2Ref>
	{
		
		public Vector2Output(IVariable variable) : 
				base(variable)
		{
		}
	}
}
