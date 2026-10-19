
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to update the geometry of the main and sub text objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextUpdateGeometry : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Mesh.")]
		[SerializeField]
		private MeshVar _mesh;
		
		[Tooltip("Index.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _mesh, _index);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.UpdateGeometry(UnityEngine.Mesh, System.Int32);
			_tMP_Text.Value.UpdateGeometry(_mesh.Value, _index.Value);
		}
		
		public override string GetSummary()
		{
			return "Update {_tMP_Text} geometry {_mesh} {_index}";
		}
	}
}
