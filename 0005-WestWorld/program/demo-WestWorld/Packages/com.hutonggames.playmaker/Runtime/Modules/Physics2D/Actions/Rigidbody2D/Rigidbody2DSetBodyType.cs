
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The physical behaviour type of the Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-bodyType.html")]
	public sealed class Rigidbody2DSetBodyType : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Body Type")]
		[SerializeField]
		private RigidbodyType2DVar _setBodyType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setBodyType);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.bodyType = _setBodyType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} body type to {_setBodyType}";
		}
	}
}
