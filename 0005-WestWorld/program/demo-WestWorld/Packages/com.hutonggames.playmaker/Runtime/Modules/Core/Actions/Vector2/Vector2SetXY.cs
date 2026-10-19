
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Set x and y components of an existing Vector2.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Set.html")]
	[MovedFrom(true, null, null, "Vector2SetXYZ")]
	public sealed class Vector2SetXY : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[FormerlySerializedAs("_newX")]
		[Tooltip("New X.")]
		[SerializeField]
		private FloatVar _x;
		
		[FormerlySerializedAs("_newY")]
		[Tooltip("New Y.")]
		[SerializeField]
		private FloatVar _y;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _x, _y);
		}
		
		public override void Execute()
		{
			_vector2.Value = new Vector2(_x.Value, _y.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_vector2} to ({_x},{_y})";
		}
	}
}
