/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(-1, 0, 0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-left.html")]
	public sealed class Vector3GetLeft : BaseAction
	{
		
		[Tooltip("Get Vector3 Left")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getLeft);
		}
		
		public override void Execute()
		{
			_getLeft.Value = Vector3.left;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 left -> {_getLeft} ";
		}
	}
}
*/