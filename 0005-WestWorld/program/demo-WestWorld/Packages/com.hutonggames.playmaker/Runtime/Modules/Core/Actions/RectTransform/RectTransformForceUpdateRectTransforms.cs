
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Force the recalculation of RectTransforms internal data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform.ForceUpdateRectTransforms.html")]
	public sealed class RectTransformForceUpdateRectTransforms : BaseAction
	{
		
		[Tooltip("The RectTransform.")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectTransform.ForceUpdateRectTransforms();
			_rectTransform.Value.ForceUpdateRectTransforms();
		}
		
		public override string GetSummary()
		{
			return "Force update rect transforms for {_rectTransform}";
		}
	}
}
