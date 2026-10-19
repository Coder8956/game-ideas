
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The size of this RectTransform relative to the distances between the anchors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-sizeDelta.html")]
	public sealed class RectTransformGetSizeDelta : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Size Delta")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSizeDelta;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getSizeDelta);
		}
		
		public override void Execute()
		{
			_getSizeDelta.Value = _rectTransform.Value.sizeDelta;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} size delta -> {_getSizeDelta}";
		}
	}
}
