
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Layout Priority.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetLayoutPriority : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Layout Priority")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLayoutPriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getLayoutPriority);
		}
		
		public override void Execute()
		{
			_getLayoutPriority.Value = _tMP_Text.Value.layoutPriority;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} layout priority -> {_getLayoutPriority}";
		}
	}
}
