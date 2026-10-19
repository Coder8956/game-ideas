
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The cookie texture projected by the light.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-cookie.html")]
	public sealed class LightSetCookie : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Cookie")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _setCookie;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light);
		}
		
		public override void Execute()
		{
			_light.Value.cookie = _setCookie.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} cookie to {_setCookie}";
		}
	}
}
