
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Is any invoke on methodName pending?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.IsInvoking.html")]
	public sealed class MonoBehaviourIsInvoking__MethodName : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Method Name.")]
		[SerializeField]
		private StringVar _methodName;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _methodName, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.IsInvoking(System.String);
			_result.Value = _monoBehaviour.Value.IsInvoking(_methodName.Value);
		}
		
		public override string GetSummary()
		{
			return "Check if {_monoBehaviour} is invoking {_methodName} -> {_result}";
		}
	}
}
