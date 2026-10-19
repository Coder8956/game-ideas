
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get a global space vector given the vector relativeVector in rigidBody local spac" +
		"e.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetRelativeVector.html")]
	public sealed class Rigidbody2DGetRelativeVector : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The local space vector to transform into a global space vector.")]
		[SerializeField]
		private Vector2Var _relativeVector;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _relativeVector, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.GetRelativeVector(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetRelativeVector(_relativeVector.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} relative vector {_relativeVector} -> {_result}";
		}
	}
}
