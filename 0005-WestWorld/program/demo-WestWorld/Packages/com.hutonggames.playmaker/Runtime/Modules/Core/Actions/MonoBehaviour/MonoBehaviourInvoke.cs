
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Invokes the method methodName in time seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html")]
	public sealed class MonoBehaviourInvoke : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		[Tooltip("Method Name.")]
		[SerializeField]
		private StringVar _methodName;
		
		[Tooltip("Time.")]
		[SerializeField]
		private FloatVar _time;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour, _methodName, _time);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.Invoke(System.String, System.Single);
			_monoBehaviour.Value.Invoke(_methodName.Value, _time.Value);
		}
		
		public override string GetSummary()
		{
			return "Invoke {_methodName} on {_monoBehaviour} after {_time}";
		}
	}
}
