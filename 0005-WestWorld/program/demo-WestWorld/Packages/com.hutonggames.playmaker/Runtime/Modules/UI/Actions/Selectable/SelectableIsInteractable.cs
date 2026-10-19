
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Is the object interactable.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableIsInteractable : BaseAction
	{
		
		[Tooltip("The Selectable.")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Selectable.IsInteractable();
			_result.Value = _selectable.Value.IsInteractable();
		}
		
		public override string GetSummary()
		{
			return "Check {_selectable} is interactable -> {_result}";
		}
	}
}
