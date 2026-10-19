
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Get a hash code for the bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.html")]
	public sealed class BoundsGetHashCode : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.GetHashCode();
			_result.Value = _bounds.Value.GetHashCode();
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} hash code -> {_result}";
		}
	}
}
