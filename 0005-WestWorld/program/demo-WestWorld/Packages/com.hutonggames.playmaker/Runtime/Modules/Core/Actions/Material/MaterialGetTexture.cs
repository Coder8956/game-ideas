
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Get a named texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.GetTexture.html")]
	public sealed class MaterialGetTexture : BaseMaterialPropertyAction
	{
		[Tooltip("Store the result in Texture variable.")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _result;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_result);

		public override void Execute()
		{
			base.Execute();
			
			_result.Value = _material.Value.GetTexture(PropertyId);	
		}
		
		public override string GetSummary() => "Get {_material} texture {_propertyName} -> {_result}";
	}
}
