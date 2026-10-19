
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The rotation of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-rotation.html")]
	public sealed class Rigidbody2DGetRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Rotation")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getRotation);
		}
		
		public override void Execute()
		{
			_getRotation.Value = _rigidbody2D.Value.rotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} rotation -> {_getRotation}";
		}
	}
}
