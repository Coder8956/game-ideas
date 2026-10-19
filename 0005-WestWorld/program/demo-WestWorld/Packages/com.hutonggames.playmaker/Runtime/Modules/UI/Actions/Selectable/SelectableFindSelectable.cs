
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Finds the selectable object next to this one.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableFindSelectable : BaseAction
	{
		
		[Tooltip("The Selectable.")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Dir.")]
		[SerializeField]
		private Vector3Var _dir;
		
		[Tooltip("Store the result in Selectable variable.")]
		[SerializeField]
		[WriteOnly]
		private SelectableVar _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _dir, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Selectable.FindSelectable(UnityEngine.Vector3);
			_result.Value = _selectable.Value.FindSelectable(_dir.Value);
		}
		
		public override string GetSummary()
		{
			return "Find selectable from {_selectable} {_dir} -> {_result}";
		}
	}
}
