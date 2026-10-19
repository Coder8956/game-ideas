#if UNITY_6000_3_OR_NEWER
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The size of a directional light\'s cookie.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-cookieSize2D.html")]
	public sealed class LightSetCookieSize2D : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Cookie Size")]
		[SerializeField]
		private Vector2Var _setCookieSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setCookieSize);
		}
		
		public override void Execute()
		{
			_light.Value.cookieSize2D = _setCookieSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} cookie size to {_setCookieSize}";
		}
	}
}
#endif
