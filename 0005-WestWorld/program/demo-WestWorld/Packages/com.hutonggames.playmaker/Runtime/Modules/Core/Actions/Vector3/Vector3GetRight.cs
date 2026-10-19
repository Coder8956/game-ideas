/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(1, 0, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-right.html")]
	public sealed class Vector3GetRight : BaseAction
	{
		
		[Tooltip("Get Vector3 Right")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRight);
		}
		
		public override void Execute()
		{
			_getRight.Value = Vector3.right;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 right -> {_getRight} ";
		}
	}
}
*/