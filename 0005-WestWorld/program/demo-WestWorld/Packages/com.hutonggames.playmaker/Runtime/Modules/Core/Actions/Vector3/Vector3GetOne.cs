/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(1, 1, 1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-one.html")]
	public sealed class Vector3GetOne : BaseAction
	{
		
		[Tooltip("Get Vector3 One")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getOne;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getOne);
		}
		
		public override void Execute()
		{
			_getOne.Value = Vector3.one;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 one -> {_getOne} ";
		}
	}
}
*/