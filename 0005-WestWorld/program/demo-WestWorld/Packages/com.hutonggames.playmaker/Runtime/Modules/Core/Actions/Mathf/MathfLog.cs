
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns the logarithm of a specified number in a specified base.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Log.html")]
	public sealed class MathfLog : BaseAction
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
			//UnityEngine.Mathf.Log(System.Single, System.Single);
			_result.Value = Mathf.Log(_f.Value, _p.Value);
		}
		
		public override string GetSummary()
		{
			return "Log {_f} {_p} -> {_result}";
		}
	}
}
