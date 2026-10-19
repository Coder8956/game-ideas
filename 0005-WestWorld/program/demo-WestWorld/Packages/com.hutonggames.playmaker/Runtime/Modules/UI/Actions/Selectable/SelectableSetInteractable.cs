
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Is this object interactable.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetInteractable : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Interactable")]
		[SerializeField]
		private BoolVar _setInteractable;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setInteractable);
		}
		
		public override void Execute()
		{
			_selectable.Value.interactable = _setInteractable.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} interactable to {_setInteractable}";
		}
	}
}
