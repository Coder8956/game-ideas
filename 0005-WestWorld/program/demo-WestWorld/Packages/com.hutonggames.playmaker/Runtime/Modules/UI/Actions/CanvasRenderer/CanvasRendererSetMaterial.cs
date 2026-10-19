
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Set the material for the canvas renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetMaterial.html")]
	public sealed class CanvasRendererSetMaterial : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Material for rendering.")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _material;
		
		[Tooltip("Material index.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _index);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetMaterial(UnityEngine.Material, System.Int32);
			_canvasRenderer.Value.SetMaterial(_material.Value, _index.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} material {_index} to {_material}";
		}
	}
}
