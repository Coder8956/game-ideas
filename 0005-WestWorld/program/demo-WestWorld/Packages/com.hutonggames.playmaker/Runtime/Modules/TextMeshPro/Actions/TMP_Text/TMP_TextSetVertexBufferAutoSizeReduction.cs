
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Vertex Buffer Auto Size Reduction")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetVertexBufferAutoSizeReduction : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Vertex Buffer Auto Size Reduction")]
		[SerializeField]
		private BoolVar _setVertexBufferAutoSizeReduction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setVertexBufferAutoSizeReduction);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.vertexBufferAutoSizeReduction = _setVertexBufferAutoSizeReduction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} vertex buffer auto size reduction to {_setVertexBufferAutoSizeReduction}";
		}
	}
}
