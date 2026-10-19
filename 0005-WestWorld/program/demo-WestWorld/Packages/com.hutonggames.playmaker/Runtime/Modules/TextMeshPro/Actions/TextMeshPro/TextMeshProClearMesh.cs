
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function to clear the geometry of the Primary and Sub Text objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProClearMesh : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Update Mesh.")]
		[SerializeField]
		private BoolVar _updateMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _updateMesh);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.ClearMesh(System.Boolean);
			_textMeshPro.Value.ClearMesh(_updateMesh.Value);
		}
		
		public override string GetSummary()
		{
			return "Clear {_textMeshPro} mesh {_updateMesh}";
		}
	}
}
