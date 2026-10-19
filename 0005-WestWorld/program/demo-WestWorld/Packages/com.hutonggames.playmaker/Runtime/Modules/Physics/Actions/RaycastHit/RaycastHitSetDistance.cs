/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The distance from the ray\'s origin to the impact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-distance.html")]
	public sealed class RaycastHitSetDistance : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Set RaycastHit Distance")]
		[SerializeField]
		private FloatVar _setDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _setDistance);
		}
		
		public override void Execute()
		{
			var value = _raycastHit.Value;
			value.distance = _setDistance.Value;
			_raycastHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_raycastHit} Distance to {_setDistance}";
		}
	}
}
*/