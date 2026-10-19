
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The Navigation setting for this selectable object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetNavigation : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Navigation")]
		[SerializeField]
		private NavigationVar _setNavigation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setNavigation);
		}
		
		public override void Execute()
		{
			_selectable.Value.navigation = _setNavigation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} navigation to {_setNavigation}";
		}
	}
}
