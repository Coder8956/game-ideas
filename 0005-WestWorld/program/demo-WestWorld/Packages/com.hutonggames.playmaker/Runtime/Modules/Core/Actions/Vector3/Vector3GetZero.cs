/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(0, 0, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-zero.html")]
	public sealed class Vector3GetZero : BaseAction
	{
		
		[Tooltip("Get Vector3 Zero")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getZero;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getZero);
		}
		
		public override void Execute()
		{
			_getZero.Value = Vector3.zero;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 zero -> {_getZero} ";
		}
	}
}
*/