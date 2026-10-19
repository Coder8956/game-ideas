
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to push a new set of vertices to the mesh.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetVertices : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Vertices.")]
		[SerializeField]
		private Vector3ListVar _vertices;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _vertices);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.SetVertices(UnityEngine.Vector3[]);
			_tMP_Text.Value.SetVertices(_vertices.Values);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} vertices {_vertices}";
		}
	}
}
