
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The Rigidbody\'s resistance to changes in angular velocity (rotation).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-inertia.html")]
	public sealed class Rigidbody2DGetInertia : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Inertia")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getInertia;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getInertia);
		}
		
		public override void Execute()
		{
			_getInertia.Value = _rigidbody2D.Value.inertia;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} inertia -> {_getInertia}";
		}
	}
}
