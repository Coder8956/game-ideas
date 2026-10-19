
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Copy of the array of all the selectable objects currently active in the scene.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableGetAllSelectablesArray : BaseAction
	{
		
		[Tooltip("Get Selectable All Selectables Array")]
		[SerializeField]
		[WriteOnly]
		private SelectableListRef _getAllSelectablesArray;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllSelectablesArray);
		}
		
		public override void Execute()
		{
			_getAllSelectablesArray.Values = Selectable.allSelectablesArray;
		}
		
		public override string GetSummary()
		{
			return "Get all selectables -> {_getAllSelectablesArray}";
		}
	}
}
