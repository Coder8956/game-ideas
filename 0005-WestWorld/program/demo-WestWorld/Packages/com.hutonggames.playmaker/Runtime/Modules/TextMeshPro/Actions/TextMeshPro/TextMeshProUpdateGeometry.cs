
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function to update the geometry of the main and sub text objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProUpdateGeometry : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Mesh.")]
		[SerializeField]
		private MeshVar _mesh;
		
		[Tooltip("Index.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _mesh, _index);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.UpdateGeometry(UnityEngine.Mesh, System.Int32);
			_textMeshPro.Value.UpdateGeometry(_mesh.Value, _index.Value);
		}
		
		public override string GetSummary()
		{
			return "Update {_textMeshPro} geometry {_mesh} {_index}";
		}
	}
}
