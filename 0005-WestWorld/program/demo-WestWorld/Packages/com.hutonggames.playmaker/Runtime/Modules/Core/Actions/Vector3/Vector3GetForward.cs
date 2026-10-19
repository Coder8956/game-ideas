/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(0, 0, 1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-forward.html")]
	public sealed class Vector3GetForward : BaseAction
	{
		
		[Tooltip("Get Vector3 Forward")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getForward;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getForward);
		}
		
		public override void Execute()
		{
			_getForward.Value = Vector3.forward;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 forward -> {_getForward} ";
		}
	}
}
*/