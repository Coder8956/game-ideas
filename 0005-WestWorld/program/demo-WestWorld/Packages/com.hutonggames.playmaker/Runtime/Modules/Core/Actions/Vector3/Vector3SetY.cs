
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Set")]
	[ActionDescription("Y component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-y.html")]
	public sealed class Vector3SetY : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Set Vector3 Y")]
		[SerializeField]
		private FloatVar _setY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _setY);
		}
		
		public override void Execute()
		{
			var value = _vector3.Value;
			value.y = _setY.Value;
			_vector3.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector3} Y to {_setY}";
		}
	}
}
