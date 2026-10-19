
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Find the selectable object below this one.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableFindSelectableOnDown : BaseAction
	{
		
		[Tooltip("The Selectable.")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[WriteOnly]
		[Tooltip("Store the result in Selectable variable.")]
		[SerializeField]
		private SelectableRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Selectable.FindSelectableOnDown();
			_result.Value = _selectable.Value.FindSelectableOnDown();
		}
		
		public override string GetSummary()
		{
			return "Find selectable below {_selectable} -> {_result}";
		}
	}
}
