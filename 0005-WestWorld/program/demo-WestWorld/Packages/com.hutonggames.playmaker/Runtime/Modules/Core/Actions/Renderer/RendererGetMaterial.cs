
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Get a Material assigned to the renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-material.html")]
	public sealed class RendererGetMaterial : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;

		[Tooltip("The index of the material to get.\nUse 0 to get the main material.")]
		[SerializeField]
		private IntegerVar _materialIndex;
		
		[Tooltip("Store the material.")]
		[SerializeField, WriteOnly]
		private MaterialRef _getMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getMaterial);
		}
		
		public override void Execute()
		{
			var renderer = _renderer.Value;
			if (renderer == null) return;
			
			var index = _materialIndex.Value;
			if (index <= 0)
			{
				_getMaterial.Value = renderer.material;
			}
			else if (index < renderer.materials.Length)
			{
				_getMaterial.Value = renderer.materials[index];
			}
			else
			{
				LogWarning("Material index out of range: " + index);
				_getMaterial.Value = null;
			}
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} material " +
				(_materialIndex.IsNotDefault() ? "[{_materialIndex}]" : "") +
				" -> {_getMaterial}";
		}
	}
}
