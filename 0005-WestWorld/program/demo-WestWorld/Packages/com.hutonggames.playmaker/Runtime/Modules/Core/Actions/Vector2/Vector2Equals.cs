
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns true if the given vector is exactly equal to this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Equals.html")]
	public sealed class Vector2Equals : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Other.")]
		[SerializeField]
		private Vector2Var _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Equals(UnityEngine.Vector2);
			_result.Value = _vector2.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector2} equals {_other} -> {_result}";
		}
	}
}
