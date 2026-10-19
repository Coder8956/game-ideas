
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Indicates whether geometry emitted by this renderer can be ignored when the verte" +
		"x color alpha is close to zero for every vertex of the mesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-cullTransparentMesh.html")]
	public sealed class CanvasRendererSetCullTransparentMesh : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Cull Transparent Mesh")]
		[SerializeField]
		private BoolVar _setCullTransparentMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setCullTransparentMesh);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.cullTransparentMesh = _setCullTransparentMesh.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} cull transparent mesh to {_setCullTransparentMesh}";
		}
	}
}
