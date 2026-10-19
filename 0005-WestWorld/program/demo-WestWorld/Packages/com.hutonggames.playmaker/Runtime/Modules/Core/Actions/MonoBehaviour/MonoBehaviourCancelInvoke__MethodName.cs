
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Cancels all Invoke calls with name Method Name on this behaviour.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.CancelInvoke.html")]
	public sealed class MonoBehaviourCancelInvoke__MethodName : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Method Name.")]
		[SerializeField]
		private StringVar _methodName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _methodName);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.CancelInvoke(System.String);
			_monoBehaviour.Value.CancelInvoke(_methodName.Value);
		}
		
		public override string GetSummary()
		{
			return "Cancel invoke {_methodName} on {_monoBehaviour}";
		}
	}
}
