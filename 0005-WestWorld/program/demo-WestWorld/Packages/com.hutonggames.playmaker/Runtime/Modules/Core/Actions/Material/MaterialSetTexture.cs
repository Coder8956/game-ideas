
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets a named texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetTexture.html")]
	public sealed class MaterialSetTexture : BaseMaterialPropertyAction
	{
		[Tooltip("Texture to set.")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters();

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetTexture(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} texture {_propertyName} to {_value}";
	}
}
