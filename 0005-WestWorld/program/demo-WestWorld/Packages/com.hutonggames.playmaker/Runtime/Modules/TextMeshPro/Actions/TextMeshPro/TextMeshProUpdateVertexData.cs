
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function to upload the updated vertex data and renderer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProUpdateVertexData : BaseAction
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
			//TMPro.TextMeshPro.UpdateVertexData();
			_textMeshPro.Value.UpdateVertexData();
		}
		
		public override string GetSummary()
		{
			return "Update {_textMeshPro} vertex data";
		}
	}
}
