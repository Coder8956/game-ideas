
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The Selectable object above current")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableFindSelectableOnUp : BaseAction
	{
		
		[Tooltip("The Selectable.")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Store the result in Selectable variable.")]
		[SerializeField]
		[WriteOnly]
		private SelectableRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Selectable.FindSelectableOnUp();
			_result.Value = _selectable.Value.FindSelectableOnUp();
		}
		
		public override string GetSummary()
		{
			return "Find selectable above {_selectable} -> {_result}";
		}
	}
}
