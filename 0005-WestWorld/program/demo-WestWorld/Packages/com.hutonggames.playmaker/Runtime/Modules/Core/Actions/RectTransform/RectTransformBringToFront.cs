
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Set the RectTransform as the last sibling so it draws on top.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetAsLastSibling.html")]
	public sealed class RectTransformBringToFront : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		public override bool CanExecute() => CheckParameters(_rectTransform);
		
		public override void Execute() => _rectTransform.Value.SetAsLastSibling();

		public override string GetSummary() => "Bring {_rectTransform} to front";
	}
}
