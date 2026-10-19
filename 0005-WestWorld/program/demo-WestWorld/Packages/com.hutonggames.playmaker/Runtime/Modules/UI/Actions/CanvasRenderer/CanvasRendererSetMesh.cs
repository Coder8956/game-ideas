
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Sets the Mesh used by this renderer. Note the Mesh must be read/write enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetMesh.html")]
	public sealed class CanvasRendererSetMesh : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Mesh.")]
		[SerializeField, CanBeNullOrEmpty]
		private MeshVar _mesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetMesh(UnityEngine.Mesh);
			_canvasRenderer.Value.SetMesh(_mesh.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} mesh to {_mesh}";
		}
	}
}
