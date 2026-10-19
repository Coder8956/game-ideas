
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntVariable : Variable<UnityEngine.Vector2Int>
	{
		
		public Vector2IntVariable()
		{
		}
		
		public Vector2IntVariable(string name) : 
				base(name)
		{
		}
		
		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(Vector2))
			{
				return (TAsType)(object)new Vector2(_value.x, _value.y);
			}
            
			return base.GetValue<TAsType>();
		}
		
		public override void SetValue<TAsType>(TAsType value)
		{
			if (value is Vector2Int vector2)
			{
				_value = new Vector2Int(vector2.x, vector2.y);
				return;
			}
			
			base.SetValue(value);
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntListVariable : ListVariable<UnityEngine.Vector2Int>
	{
		
		public Vector2IntListVariable()
		{
		}
		
		public Vector2IntListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntRef : VariableRef<UnityEngine.Vector2Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntVar : VariableVar<UnityEngine.Vector2Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntListRef : ListVariableRef<UnityEngine.Vector2Int>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Vector2Int))]
	public sealed partial class Vector2IntListVar : ListVariableVar<UnityEngine.Vector2Int>
	{
	}
}
