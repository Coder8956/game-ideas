
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Selects this Selectable.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSelect : BaseAction
	{
		
		[Tooltip("The Selectable.")]
		[SerializeField]
		private SelectableVar _selectable;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Selectable.Select();
			_selectable.Value.Select();
		}
		
		public override string GetSummary()
		{
			return "Select {_selectable}";
		}
	}
}
