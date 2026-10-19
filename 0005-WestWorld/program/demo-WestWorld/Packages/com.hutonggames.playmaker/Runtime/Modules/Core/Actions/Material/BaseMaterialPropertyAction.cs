using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	/// <summary>
	/// Base class for material actions that access material properties.
	/// Caches a property Id for the property name.
	/// </summary>
	[Serializable]
	public abstract class BaseMaterialPropertyAction : BaseAction
	{
		[DisplayOrder(-1000)]
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		protected MaterialVar _material;
		
		[DisplayOrder(-999)]
		[Tooltip("Property name, e.g. \"_MainTex\", \"_Glossiness\", ...")]
		[SerializeField]
		protected StringVar _propertyName;
		
		private string _propertyIdForName;
		protected int PropertyId;
		
		public override bool CanExecute() => CheckParameters(_material, _propertyName);

		public override void Execute()
		{
			if (string.Equals(_propertyName.Value, _propertyIdForName)) return;
			PropertyId = Shader.PropertyToID(_propertyName.Value);
			_propertyIdForName = _propertyName.Value;
		}
	}
}
