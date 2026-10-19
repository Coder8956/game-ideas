
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get a local space vector given the vector vector in rigidBody global space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetVector.html")]
	public sealed class Rigidbody2DGetVector : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The global space vector to transform into a local space vector.")]
		[SerializeField]
		private Vector2Var _vector;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _vector, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.GetVector(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetVector(_vector.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} vector {_vector} -> {_result}";
		}
	}
}
