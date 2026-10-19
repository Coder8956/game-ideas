
using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectVariable : Variable<Rect>
	{
		
		public RectVariable()
		{
		}
		
		public RectVariable(string name) : 
				base(name)
		{
		}
		
		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(RectInt))
			{
				return (TAsType)(object) new RectInt(
					Mathf.RoundToInt(_value.x),
					Mathf.RoundToInt(_value.y),
					Mathf.RoundToInt(_value.width),
					Mathf.RoundToInt(_value.height)
				);
			}
            
			return base.GetValue<TAsType>();
		}
		
		public override void SetValue<TAsType>(TAsType value)
		{
			if (value is RectInt rectInt)
			{
				_value = new Rect(
					rectInt.x,
					rectInt.y,
					rectInt.width,
					rectInt.height
				);
				return;
			}
            
			base.SetValue(value);
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectListVariable : ListVariable<Rect>
	{
		
		public RectListVariable()
		{
		}
		
		public RectListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectRef : VariableRef<Rect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectVar : VariableVar<Rect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectListRef : ListVariableRef<Rect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectListVar : ListVariableVar<Rect>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectOverride : VariableOverride<Rect,RectVariable,RectVar>
	{
		
		public RectOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectOutput : VariableOutput<Rect,RectVariable,RectRef>
	{
		
		public RectOutput(IVariable variable) : 
				base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectListOverride : VariableOverride<List<Rect>, RectListVariable, RectListVar>
	{
		public RectListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rect))]
	public sealed partial class RectListOutput : VariableOutput<List<Rect>, RectListVariable, RectListRef>
	{
		public RectListOutput(IVariable variable) :
			base(variable)
		{
		}
	}
}
