
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Get the Mesh used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetMesh : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Get TextMeshProUGUI Mesh")]
		[SerializeField]
		[WriteOnly]
		private MeshRef _getMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _getMesh);
		}
		
		public override void Execute()
		{
			_getMesh.Value = _textMeshProUGUI.Value.mesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} mesh -> {_getMesh}";
		}
	}
}
