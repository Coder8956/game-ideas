
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Schedule rebuilding of the text geometry.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProSetVerticesDirty : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.SetVerticesDirty();
			_textMeshPro.Value.SetVerticesDirty();
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} vertices dirty";
		}
	}
}
