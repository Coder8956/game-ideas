
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets a named texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetTexture.html")]
	public sealed class MaterialSetTexture__RenderTexture : BaseMaterialPropertyAction
	{
		[Tooltip("Texture to set.")]
		[SerializeField, CanBeNullOrEmpty]
		private RenderTextureVar _value;
		
		[OptionalField]
		[Tooltip("Optional parameter that specifies the type of data to set from the RenderTexture.")]
		[SerializeField]
		private RenderTextureSubElement _element;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters();

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetTexture(PropertyId, _value.Value, _element);
		}
		
		public override string GetSummary() => "Set {_material} texture {_propertyName} to {_value}";
	}
}
