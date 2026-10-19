
using JetBrains.Annotations;
using UnityEngine;
using System;


namespace HutongGames.PlayMaker.Actions
{
	#if UNITY_6000_0_OR_NEWER
	[Obsolete("Light.shape is deprecated. Use Light.type instead.")]
	#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("This property describes the shape of the spot light. " +
	                   "Only Scriptable Render Pipelines use this property; the built-in renderer does not support it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-shape.html")]
	public sealed class LightSetShape : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
#if !UNITY_6000_0_OR_NEWER
		[Tooltip("Set Light Shape")]
		[SerializeField]
		private LightShapeVar _setShape;
#endif		
		public override bool CanExecute()
		{
#if UNITY_6000_0_OR_NEWER
			return false;
#else
			return CheckParameters(_light, _setShape);
#endif
		}
		
		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			_light.Value.shape = _setShape.Value;
#endif
		}
		
		public override string GetSummary()
		{
#if UNITY_6000_0_OR_NEWER
			return null;
#else
			return "Set {_light} shape to {_setShape}";
#endif
		}
	}
}
