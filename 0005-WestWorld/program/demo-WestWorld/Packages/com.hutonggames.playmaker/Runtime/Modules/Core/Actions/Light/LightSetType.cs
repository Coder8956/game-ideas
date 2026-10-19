
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The type of the light.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-type.html")]
	public sealed class LightSetType : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Type")]
		[SerializeField]
		[BaseType(typeof(LightType))]
		private EnumVar _setType;
		
		public override bool CanExecute() => CheckParameters(_light, _setType);

		public override void Execute() => _light.Value.type = (LightType) _setType.Value;

		public override string GetSummary() => "Set {_light} Type to {_setType}";
	}
}
