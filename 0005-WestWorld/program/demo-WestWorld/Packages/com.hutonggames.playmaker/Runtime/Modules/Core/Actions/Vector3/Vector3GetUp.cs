/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(0, 1, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-up.html")]
	public sealed class Vector3GetUp : BaseAction
	{
		
		[Tooltip("Get Vector3 Up")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getUp;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getUp);
		}
		
		public override void Execute()
		{
			_getUp.Value = Vector3.up;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 up -> {_getUp} ";
		}
	}
}
*/