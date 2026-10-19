
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Component)]
	[ActionDescription("Disable a Component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class ComponentEnable : BaseAction
	{
		[Tooltip("The Component to enable.<br/>" + Strings.ComponentsEnabledNote)]
		[SerializeField]
		private ComponentVar _component;
		
		public override bool CanExecute() => CheckParameters(_component);

		public override void Execute()
		{
			var component = _component.Value;
			if (component is Behaviour behaviour) behaviour.enabled = true;
			if (component is Renderer renderer) renderer.enabled = true;
			if (component is Collider collider) collider.enabled = true;
			if (component is ParticleSystem particleSystem) particleSystem.Play();
			if (component is LODGroup lodGroup) lodGroup.enabled = true;
			if (component is Cloth cloth) cloth.enabled = true;
			else
			{
				// Fallback: Try to find and set an 'enabled' property via reflection
				var enabledProperty = component.GetType().GetProperty("enabled", 
					System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            
				if (enabledProperty != null && enabledProperty.PropertyType == typeof(bool) && enabledProperty.CanWrite)
				{
					enabledProperty.SetValue(component, true);
				}
			}
		}

		public override string GetSummary() => "Enable {_component}";
	}
}
