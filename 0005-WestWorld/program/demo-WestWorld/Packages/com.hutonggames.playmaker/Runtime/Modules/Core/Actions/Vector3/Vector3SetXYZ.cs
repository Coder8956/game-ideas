
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Set")]
	[ActionDescription("Set x, y and z components of an existing Vector3.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Set.html")]
	public sealed class Vector3SetXYZ : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("X.")]
		[SerializeField]
		[FormerlySerializedAs("_newX")]
		private FloatVar _x;
		
		[Tooltip("Y.")]
		[SerializeField]
		[FormerlySerializedAs("_newY")]
		private FloatVar _y;
		
		[Tooltip("Z.")]
		[SerializeField]
		[FormerlySerializedAs("_newZ")]
		private FloatVar _z;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _x, _y, _z);
		}
		
		public override void Execute()
		{
			_vector3.Value = new Vector3(_x.Value, _y.Value, _z.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_vector3} to ({_x},{_y},{_z})";
		}
	}
}
