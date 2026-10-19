/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Sends an event when Toggle Set Is Without Notify.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleSetIsOnWithoutNotify : BaseAction
	{
		
		[Tooltip("The Toggle.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UI.ToggleVar _toggle;
		
		[Tooltip("Value.")]
		[SerializeField]
		private HutongGames.PlayMaker.BoolVar _value;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _value);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Toggle.SetIsOnWithoutNotify(System.Boolean);
			_toggle.Value.SetIsOnWithoutNotify(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} is on without notify to {_value}";
		}
	}
}
*/
