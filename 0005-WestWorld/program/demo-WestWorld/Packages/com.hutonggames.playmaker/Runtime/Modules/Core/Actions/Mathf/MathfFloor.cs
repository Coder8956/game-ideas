
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns the largest integer smaller than or equal to f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Floor.html")]
	public sealed class MathfFloor : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Floor(System.Single);
			_result.Value = Mathf.Floor(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Floor {_f} -> {_result}";
		}
	}
}
