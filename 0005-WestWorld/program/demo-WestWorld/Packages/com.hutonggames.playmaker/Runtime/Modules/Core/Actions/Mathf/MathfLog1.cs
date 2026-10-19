
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns the natural (base e) logarithm of a specified number.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Log.html")]
	public sealed class MathfLog1 : BaseAction
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
			//UnityEngine.Mathf.Log(System.Single);
			_result.Value = Mathf.Log(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Log {_f} -> {_result}";
		}
	}
}
