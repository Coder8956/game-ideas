
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The linked text component used for flowing the text from one text component to another.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetLinkedTextComponent : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Linked Text Component")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_TextVar _setLinkedTextComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.linkedTextComponent = _setLinkedTextComponent.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} linked text component to {_setLinkedTextComponent}";
		}
	}
}
