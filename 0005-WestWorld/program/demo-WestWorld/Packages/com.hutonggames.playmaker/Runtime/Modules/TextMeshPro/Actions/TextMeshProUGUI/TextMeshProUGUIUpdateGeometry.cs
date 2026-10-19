
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function to update the geometry of the main and sub text objects. ")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIUpdateGeometry : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Mesh.")]
		[SerializeField]
		private MeshVar _mesh;
		
		[Tooltip("Index.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _mesh, _index);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.UpdateGeometry(UnityEngine.Mesh, System.Int32);
			_textMeshProUGUI.Value.UpdateGeometry(_mesh.Value, _index.Value);
		}
		
		public override string GetSummary()
		{
			return "Update {_textMeshProUGUI} geometry {_mesh} {_index}";
		}
	}
}
