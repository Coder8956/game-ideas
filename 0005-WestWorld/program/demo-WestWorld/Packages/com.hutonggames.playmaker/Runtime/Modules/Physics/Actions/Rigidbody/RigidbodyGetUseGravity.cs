
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Controls whether gravity affects this rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-useGravity.html")]
	public sealed class RigidbodyGetUseGravity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Use Gravity")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getUseGravity);
		}
		
		public override void Execute()
		{
			_getUseGravity.Value = _rigidbody.Value.useGravity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} use gravity -> {_getUseGravity}";
		}
	}
}
