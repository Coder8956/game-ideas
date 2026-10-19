
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntVariable : Variable<UnityEngine.RectInt>
	{
		
		public RectIntVariable()
		{
		}

		public RectIntVariable(string name) :
			base(name)
		{
		}

		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(Rect))
			{
				return (TAsType)(object)new Rect(_value.x, _value.y, _value.width, _value.height);
			}

			return base.GetValue<TAsType>();
		}

		public override void SetValue<TAsType>(TAsType value)
		{
			if (value is Rect rect)
			{
				_value = new RectInt(
					Mathf.RoundToInt(rect.x),
					Mathf.RoundToInt(rect.y),
					Mathf.RoundToInt(rect.width),
					Mathf.RoundToInt(rect.height)
				);
				return;
			}
    
			base.SetValue(value);
		}

	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntListVariable : ListVariable<UnityEngine.RectInt>
	{
		
		public RectIntListVariable()
		{
		}
		
		public RectIntListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntRef : VariableRef<UnityEngine.RectInt>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntVar : VariableVar<UnityEngine.RectInt>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntListRef : ListVariableRef<UnityEngine.RectInt>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectInt))]
	public sealed partial class RectIntListVar : ListVariableVar<UnityEngine.RectInt>
	{
	}
}
