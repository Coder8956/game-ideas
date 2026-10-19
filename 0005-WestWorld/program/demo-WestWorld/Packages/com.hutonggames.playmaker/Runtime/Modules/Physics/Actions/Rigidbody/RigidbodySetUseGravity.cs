
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
	public sealed class RigidbodySetUseGravity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Use Gravity")]
		[SerializeField]
		private BoolVar _setUseGravity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setUseGravity);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.useGravity = _setUseGravity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} use gravity to {_setUseGravity}";
		}
	}
}
