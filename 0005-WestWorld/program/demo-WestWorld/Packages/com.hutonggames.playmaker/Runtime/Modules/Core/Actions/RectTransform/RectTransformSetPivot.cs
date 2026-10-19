
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The normalized position in this RectTransform that it rotates around.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-pivot.html")]
	public sealed class RectTransformSetPivot : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Pivot")]
		[SerializeField]
		private Vector2Var _setPivot;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setPivot);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.pivot = _setPivot.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} pivot to {_setPivot}";
		}
	}
}
