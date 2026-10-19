
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
	public sealed class RectTransformSetAnchoredPosition3D : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Anchored Position 3D")]
		[SerializeField]
		private Vector3Var _setAnchoredPosition3D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setAnchoredPosition3D);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.anchoredPosition3D = _setAnchoredPosition3D.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} anchored position 3D to {_setAnchoredPosition3D}";
		}
	}
}
