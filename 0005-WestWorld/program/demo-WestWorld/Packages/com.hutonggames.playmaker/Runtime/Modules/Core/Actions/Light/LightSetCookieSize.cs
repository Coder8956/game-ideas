
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The size of a directional light\'s cookie.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-cookieSize2D.html")]
	public sealed class LightSetCookieSize : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Cookie Size")]
		[SerializeField]
		private FloatVar _setCookieSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setCookieSize);
		}
		
		public override void Execute()
		{
#if UNITY_6000_3_OR_NEWER
			_light.Value.cookieSize2D = new Vector2(_setCookieSize.Value, _setCookieSize.Value);
#else
			_light.Value.cookieSize = _setCookieSize.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_light} cookie size to {_setCookieSize}";
		}
	}
}


