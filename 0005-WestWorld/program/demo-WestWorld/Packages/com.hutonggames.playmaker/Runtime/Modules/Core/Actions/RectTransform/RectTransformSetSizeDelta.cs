
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The size of this RectTransform relative to the distances between the anchors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-sizeDelta.html")]
	public sealed class RectTransformSetSizeDelta : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Size Delta")]
		[SerializeField]
		private Vector2Var _setSizeDelta;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setSizeDelta);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.sizeDelta = _setSizeDelta.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} size delta to {_setSizeDelta}";
		}
	}
}
