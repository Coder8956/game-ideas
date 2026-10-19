
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Creates an RGB colour from HSV input.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color.HSVToRGB.html")]
	public sealed class ColorHSVToRGB : BaseAction
	{
		
		[Tooltip("Hue [0..1].")]
		[SerializeField]
		private FloatVar _h;
		
		[Tooltip("Saturation [0..1].")]
		[SerializeField]
		private FloatVar _s;
		
		[Tooltip("Brightness value [0..1].")]
		[SerializeField]
		private FloatVar _v;
		
		[Tooltip("Store the result in Color variable.")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_h, _s, _v, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Color.HSVToRGB(System.Single, System.Single, System.Single);
			_result.Value = Color.HSVToRGB(_h.Value, _s.Value, _v.Value);
		}
		
		public override string GetSummary()
		{
			return "Color HSV To RGB: {_h} {_s} {_v} -> {_result}";
		}
	}
}
