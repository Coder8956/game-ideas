
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Gets the squared length of a vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-sqrMagnitude.html")]
	public sealed class Vector2SqrMagnitude : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.SqrMagnitude();
			_result.Value = _vector2.Value.SqrMagnitude();
		}
		
		public override string GetSummary()
		{
			return "{_vector2} Sqr Magnitude -> {_result}";
		}
	}
}
