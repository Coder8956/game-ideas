
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Controls whether physics will change the rotation of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-freezeRotation.html")]
	public sealed class Rigidbody2DGetFreezeRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Freeze Rotation")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFreezeRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getFreezeRotation);
		}
		
		public override void Execute()
		{
			_getFreezeRotation.Value = _rigidbody2D.Value.freezeRotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} freeze rotation -> {_getFreezeRotation}";
		}
	}
}
