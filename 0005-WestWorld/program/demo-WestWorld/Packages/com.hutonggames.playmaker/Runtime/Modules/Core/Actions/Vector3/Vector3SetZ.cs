
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Set")]
	[ActionDescription("Z component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-z.html")]
	public sealed class Vector3SetZ : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Set Vector3 Z")]
		[SerializeField]
		private FloatVar _setZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _setZ);
		}
		
		public override void Execute()
		{
			var value = _vector3.Value;
			value.z = _setZ.Value;
			_vector3.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector3} Z to {_setZ}";
		}
	}
}
