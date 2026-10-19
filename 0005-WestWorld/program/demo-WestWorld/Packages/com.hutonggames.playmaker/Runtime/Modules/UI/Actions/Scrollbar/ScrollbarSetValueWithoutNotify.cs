/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("Sets Value Without Notify on Scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetValueWithoutNotify : BaseAction
	{
		
		[Tooltip("The Scrollbar.")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Input.")]
		[SerializeField]
		private FloatVar _input;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _input);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Scrollbar.SetValueWithoutNotify(System.Single);
			_scrollbar.Value.SetValueWithoutNotify(_input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} value without notify to {_input}";
		}
	}
}
*/
