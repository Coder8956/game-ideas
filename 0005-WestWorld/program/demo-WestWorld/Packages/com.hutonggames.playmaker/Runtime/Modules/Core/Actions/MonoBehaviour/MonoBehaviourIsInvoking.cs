
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Is any invoke pending on this MonoBehaviour?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.IsInvoking.html")]
	public sealed class MonoBehaviourIsInvoking : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.IsInvoking();
			_result.Value = _monoBehaviour.Value.IsInvoking();
		}
		
		public override string GetSummary()
		{
			return "Check if {_monoBehaviour} is invoking -> {_result}";
		}
	}
}
