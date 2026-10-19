
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Component)]
	[ActionDescription("Sets a Component's enabled state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class ComponentSetEnabled : BaseAction
	{
		[Tooltip("The Component to enable/disable.<br/>" + Strings.ComponentsEnabledNote)]
		[SerializeField]
		private ComponentVar _component;
		
		[Tooltip("Enable/disable the Component")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _setEnabled;
		
		public override bool CanExecute() => CheckParameters(_component, _setEnabled);

		public override void Execute()
		{
			var component = _component.Value;
			if (component is Behaviour behaviour) behaviour.enabled = _setEnabled.Value;
			if (component is Renderer renderer) renderer.enabled = _setEnabled.Value;
			if (component is Collider collider) collider.enabled = _setEnabled.Value;
			if (component is ParticleSystem particleSystem)
			{
				if (_setEnabled.Value) particleSystem.Play();
				else particleSystem.Stop();
			}
			if (component is LODGroup lodGroup) lodGroup.enabled = _setEnabled.Value;
			if (component is Cloth cloth) cloth.enabled = _setEnabled.Value;
			else
			{
				// Fallback: Try to find and set an 'enabled' property via reflection
				var enabledProperty = component.GetType().GetProperty("enabled", 
					System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            
				if (enabledProperty != null && enabledProperty.PropertyType == typeof(bool) && enabledProperty.CanWrite)
				{
					enabledProperty.SetValue(component, _setEnabled.Value);
				}
			}
		}

		public override string GetSummary() => "Set {_component} enabled to {_setEnabled}";
	}
}
