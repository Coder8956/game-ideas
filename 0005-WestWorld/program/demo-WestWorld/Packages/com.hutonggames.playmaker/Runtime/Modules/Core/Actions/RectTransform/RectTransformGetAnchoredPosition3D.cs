
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The 3D position of the pivot of this RectTransform relative to the anchor referen" +
		"ce point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition3D.html")]
	public sealed class RectTransformGetAnchoredPosition3D : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Anchored Position 3D")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getAnchoredPosition3D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getAnchoredPosition3D);
		}
		
		public override void Execute()
		{
			_getAnchoredPosition3D.Value = _rectTransform.Value.anchoredPosition3D;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} anchored position 3D -> {_getAnchoredPosition3D}";
		}
	}
}
