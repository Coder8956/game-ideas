
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Set")]
	[ActionDescription("X component of the vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-x.html")]
	public sealed class Vector3SetX : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Set Vector3 X")]
		[SerializeField]
		private FloatVar _setX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _setX);
		}
		
		public override void Execute()
		{
			var value = _vector3.Value;
			value.x = _setX.Value;
			_vector3.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_vector3} X to {_setX}";
		}
	}
}
