
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Set the RectTransform as the first sibling so it draws behind other siblings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetAsFirstSibling.html")]
	public sealed class RectTransformSendToBack : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		public override bool CanExecute() => CheckParameters(_rectTransform);
		
		public override void Execute() => _rectTransform.Value.SetAsFirstSibling();

		public override string GetSummary() => "Send {_rectTransform} to back";
	}
}
