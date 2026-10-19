
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Returns the mesh assigned to the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetMesh : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Mesh")]
		[SerializeField]
		[WriteOnly]
		private MeshRef _getMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getMesh);
		}
		
		public override void Execute()
		{
			_getMesh.Value = _textMeshPro.Value.mesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} mesh -> {_getMesh}";
		}
	}
}
