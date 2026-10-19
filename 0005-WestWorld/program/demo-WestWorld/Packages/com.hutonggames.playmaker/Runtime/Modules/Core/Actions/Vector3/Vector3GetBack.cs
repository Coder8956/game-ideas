/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(0, 0, -1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-back.html")]
	public sealed class Vector3GetBack : BaseAction
	{
		
		[Tooltip("Get Vector3 Back")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getBack;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getBack);
		}
		
		public override void Execute()
		{
			_getBack.Value = Vector3.back;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 back -> {_getBack} ";
		}
	}
}
*/