
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("VertexBufferAutoSizeReduction setting.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetVertexBufferAutoSizeReduction : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Vertex Buffer Auto Size Reduction")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getVertexBufferAutoSizeReduction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getVertexBufferAutoSizeReduction);
		}
		
		public override void Execute()
		{
			_getVertexBufferAutoSizeReduction.Value = _tMP_Text.Value.vertexBufferAutoSizeReduction;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} vertex buffer auto size reduction -> {_getVertexBufferAutoSizeReduction}";
		}
	}
}
