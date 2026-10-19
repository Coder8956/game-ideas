
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Mask)]
	[ActionDescription("See:IMask.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Mask.html")]
	public sealed class MaskMaskEnabled : BaseAction
	{
		
		[Tooltip("The Mask.")]
		[SerializeField]
		private MaskVar _mask;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_mask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Mask.MaskEnabled();
			_result.Value = _mask.Value.MaskEnabled();
		}
		
		public override string GetSummary()
		{
			return "Check {_mask} mask enabled -> {_result}";
		}
	}
}
