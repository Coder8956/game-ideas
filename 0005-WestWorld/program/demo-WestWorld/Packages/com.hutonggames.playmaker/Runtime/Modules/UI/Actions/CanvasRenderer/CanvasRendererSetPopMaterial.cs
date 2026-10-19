
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Set the material for the canvas renderer. Used internally for masking.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetPopMaterial.html")]
	public sealed class CanvasRendererSetPopMaterial : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Material.")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _material;
		
		[Tooltip("Index.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _index);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetPopMaterial(UnityEngine.Material, System.Int32);
			_canvasRenderer.Value.SetPopMaterial(_material.Value, _index.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} pop material {_index} to {_material}";
		}
	}
}
