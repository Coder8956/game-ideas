/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(0, -1, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-down.html")]
	public sealed class Vector3GetDown : BaseAction
	{
		
		[Tooltip("Get Vector3 Down")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getDown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getDown);
		}
		
		public override void Execute()
		{
			_getDown.Value = Vector3.down;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 down -> {_getDown} ";
		}
	}
}
*/