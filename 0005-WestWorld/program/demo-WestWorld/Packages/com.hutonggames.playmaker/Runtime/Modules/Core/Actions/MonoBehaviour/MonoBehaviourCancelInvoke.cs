
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MonoBehaviour)]
	[ActionDescription("Cancels all Invoke calls on this MonoBehaviour.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.CancelInvoke.html")]
	public sealed class MonoBehaviourCancelInvoke : BaseAction
	{
		
		[Tooltip("The MonoBehaviour.")]
		[SerializeField]
		private MonoBehaviourVar _monoBehaviour;
		
		public override bool CanExecute()
		{
			return CheckParameters(_monoBehaviour);
		}
		
		public override void Execute()
		{
			//UnityEngine.MonoBehaviour.CancelInvoke();
			_monoBehaviour.Value.CancelInvoke();
		}
		
		public override string GetSummary()
		{
			return "Cancel invoke on {_monoBehaviour}";
		}
	}
}
