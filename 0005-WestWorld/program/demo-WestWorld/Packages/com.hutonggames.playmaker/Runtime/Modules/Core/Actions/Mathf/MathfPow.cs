
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns f raised to power p.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Pow.html")]
	public sealed class MathfPow : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("P.")]
		[SerializeField]
		private FloatVar _p;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _p, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Pow(System.Single, System.Single);
			_result.Value = Mathf.Pow(_f.Value, _p.Value);
		}
		
		public override string GetSummary()
		{
			return "Pow {_f} {_p} -> {_result}";
		}
	}
}
