using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Component)]
    [ActionDescription("Check if a Component is enabled.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
    public class ComponentCheckIsEnabled : BaseTrueFalseAction
    {
        [Tooltip("The Component to check.<br/>" + Strings.ComponentsEnabledNote)] [SerializeField]
        private ComponentVar _component;

        protected override string TrueSummary => "{_component} is enabled";
        protected override string FalseSummary => "{_component} is not enabled";

        public override bool CanExecute() => CheckParameters(_component);

        protected override bool Test()
        {
            var component = _component.Value;

            // Handle known cases first for better performance
            var result = component switch
            {
                Behaviour behaviour => behaviour.enabled,
                Renderer renderer => renderer.enabled,
                Collider collider => collider.enabled,
                ParticleSystem particleSystem => particleSystem.isPlaying,
                LODGroup lodGroup => lodGroup.enabled,
                Cloth cloth => (bool?)cloth.enabled,
                _ => null
            };

            if (result.HasValue) return result.Value;

            // Fallback: Try to find and get an 'enabled' property via reflection
            var enabledProperty = component.GetType().GetProperty("enabled",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (enabledProperty != null && enabledProperty.PropertyType == typeof(bool) && enabledProperty.CanRead)
            {
                return (bool)enabledProperty.GetValue(component);
            }

            return false;
        }
    }
}