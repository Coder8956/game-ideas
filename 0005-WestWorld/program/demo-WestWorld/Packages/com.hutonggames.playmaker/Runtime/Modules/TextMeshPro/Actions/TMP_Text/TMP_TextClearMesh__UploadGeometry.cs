
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to clear the geometry of the Primary and Sub Text objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextClearMesh__UploadGeometry : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Upload Geometry.")]
		[SerializeField]
		private BoolVar _uploadGeometry;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _uploadGeometry);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.ClearMesh(System.Boolean);
			_tMP_Text.Value.ClearMesh(_uploadGeometry.Value);
		}
		
		public override string GetSummary()
		{
			return "Clear {_tMP_Text} mesh {_uploadGeometry}";
		}
	}
}
