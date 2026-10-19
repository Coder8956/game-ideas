
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns the largest integer smaller to or equal to f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.FloorToInt.html")]
	public sealed class MathfFloorToInt : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.FloorToInt(System.Single);
			_result.Value = Mathf.FloorToInt(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Floor {_f} to int -> {_result}";
		}
	}
}
