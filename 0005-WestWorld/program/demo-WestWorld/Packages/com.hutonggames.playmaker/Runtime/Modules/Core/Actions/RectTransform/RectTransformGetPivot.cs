
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The normalized position in this RectTransform that it rotates around.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-pivot.html")]
	public sealed class RectTransformGetPivot : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Pivot")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPivot;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getPivot);
		}
		
		public override void Execute()
		{
			_getPivot.Value = _rectTransform.Value.pivot;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} pivot -> {_getPivot}";
		}
	}
}
