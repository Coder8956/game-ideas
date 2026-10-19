
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Gets the placement scale of texture propertyName.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.GetTextureScale.html")]
	public sealed class MaterialGetTextureScale : BaseMaterialPropertyAction
	{
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_result);

		public override void Execute()
		{
			base.Execute();
			
			_result.Value = _material.Value.GetTextureScale(PropertyId);	
		}
		
		public override string GetSummary() => "Get {_material} texture scale {_propertyName} -> {_result}";
	}
}
