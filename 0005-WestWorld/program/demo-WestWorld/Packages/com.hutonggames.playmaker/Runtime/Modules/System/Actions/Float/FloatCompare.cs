
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.LogicValue)]
	[ActionDescription("Compares a Float to another Float and sends events based on if the value is " +
	                   "less than, equal to, or greater than the other Float. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.compareto")]
	public sealed class FloatCompare : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("The other float value to compare to.")]
		[SerializeField]
		private FloatVar _other;

		[Tooltip("Tolerance for the Equal test (almost equal)." +
		         "\\nNOTE: Floats that look the same are often not exactly the same, so generally need to use a small tolerance.")]
		[SerializeField]
		private FloatVar _tolerance;

		[OptionalField]
		[Tooltip("Event to send if the float is equal to the other value.")]
		[SerializeField]
		private EventRef _equalEvent;
		
		[OptionalField]
		[Tooltip("Event to send if the float is less than the other value.")]
		[SerializeField]
		private EventRef _lessThanEvent;
		
		[OptionalField]
		[Tooltip("Event to send if the float is greater than the other value.")]
		[SerializeField]
		private EventRef _greaterThanEvent;
		
		[OptionalField]
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField, WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute() => CheckParameters(_float, _other, _tolerance);

		public override void Execute()
		{
			if (Mathf.Abs(_float.Value - _other.Value) <= _tolerance.Value)
			{
				SendEvent(_equalEvent);
				_result.Value = 0;
				return;
			}

			if (_float.Value < _other.Value)
			{
				SendEvent(_lessThanEvent);
				_result.Value = -1;
				return;
			}

			if (_float.Value > _other.Value)
			{
				SendEvent(_greaterThanEvent);
				_result.Value = 1;
			}
		}
		
		public override string GetSummary() => "Compare {_float} To {_other}" +
		(_equalEvent.IsSet ? " Equal {_equalEvent}" : "") +
		(_lessThanEvent.IsSet ? " Less than {_lessThanEvent}" : "") +
		(_greaterThanEvent.IsSet ? " Greater Than {_greaterThanEvent}" : "");
	}
}
