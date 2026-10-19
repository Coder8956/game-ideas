
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The physical behaviour type of the Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-bodyType.html")]
	public sealed class Rigidbody2DGetBodyType : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Body Type")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyType2DRef _getBodyType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getBodyType);
		}
		
		public override void Execute()
		{
			_getBodyType.Value = _rigidbody2D.Value.bodyType;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} body type -> {_getBodyType}";
		}
	}
}
