
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The mesh used by the font asset and material assigned to the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMesh : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Mesh")]
		[SerializeField]
		[WriteOnly]
		private MeshRef _getMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMesh);
		}
		
		public override void Execute()
		{
			_getMesh.Value = _tMP_Text.Value.mesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} mesh -> {_getMesh}";
		}
	}
}
