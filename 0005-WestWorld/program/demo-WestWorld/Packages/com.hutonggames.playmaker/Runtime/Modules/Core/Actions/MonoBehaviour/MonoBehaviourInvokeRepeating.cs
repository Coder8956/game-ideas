
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Invokes the method methodName in Time seconds, then repeatedly every Repeat Rate seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html")]
	public sealed class MonoBehaviourInvokeRepeating : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("The name of a method to invoke.")]
		[SerializeField]
		private StringVar _methodName;
		
		[Tooltip("Start invoking after n seconds.")]
		[SerializeField]
		private FloatVar _time;
		
		[Tooltip("Repeat every n seconds.")]
		[SerializeField]
		private FloatVar _repeatRate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _methodName, _time, _repeatRate);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.InvokeRepeating(System.String, System.Single, System.Single);
			_monoBehaviour.Value.InvokeRepeating(_methodName.Value, _time.Value, _repeatRate.Value);
		}
		
		public override string GetSummary()
		{
			return "Invoke {_methodName} on {_monoBehaviour} after {_time} and repeat every {_repeatRate}";
		}
	}
}
