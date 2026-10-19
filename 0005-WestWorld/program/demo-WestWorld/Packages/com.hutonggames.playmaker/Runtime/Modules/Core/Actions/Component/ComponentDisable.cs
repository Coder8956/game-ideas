
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Component)]
	[ActionDescription("Disable a Component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	public sealed class ComponentDisable : BaseAction
	{
		[Tooltip("The Component to disable.<br/>" + Strings.ComponentsEnabledNote)]
		[SerializeField]
		private ComponentVar _component;
		
		public override bool CanExecute() => CheckParameters(_component);

		public override void Execute()
		{
			var component = _component.Value;
			if (component is Behaviour behaviour) behaviour.enabled = false;
			if (component is Renderer renderer) renderer.enabled = false;
			if (component is Collider collider) collider.enabled = false;
			if (component is ParticleSystem particleSystem) particleSystem.Stop();
			if (component is LODGroup lodGroup) lodGroup.enabled = false;
			if (component is Cloth cloth) cloth.enabled = false;
			else
			{
				// Fallback: Try to find and set an 'enabled' property via reflection
				var enabledProperty = component.GetType().GetProperty("enabled", 
					System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            
				if (enabledProperty != null && enabledProperty.PropertyType == typeof(bool) && enabledProperty.CanWrite)
				{
					enabledProperty.SetValue(component, false);
				}
			}

		}

		public override string GetSummary() => "Disable {_component}";
	}
}
