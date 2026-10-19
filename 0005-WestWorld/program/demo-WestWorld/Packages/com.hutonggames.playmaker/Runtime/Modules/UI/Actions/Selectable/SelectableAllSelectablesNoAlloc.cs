
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Non allocating version for getting the all selectables. If selectables. Length is less then s_SelectableCount only selectables. Length elements will be copied which could result in a incomplete list of elements.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableAllSelectablesNoAlloc : BaseAction
	{
		[WriteOnly]
		[Tooltip("List of Selectables to populate.")]
		[SerializeField]
		private SelectableListRef _selectables;
		
		[OptionalField]
		[Tooltip("The number of element copied.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _count;
		
		public override bool CanExecute() => CheckParameters(_selectables);

		public override void Execute() => _count.Value = Selectable.AllSelectablesNoAlloc(_selectables.Values);

		public override string GetSummary() => "Get all selectables -> {_selectables}";
	}
}
