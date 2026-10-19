
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Reflects a vector off the plane defined by a normal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html")]
	public sealed class Vector3Reflect : BaseAction
	{
		
		[Tooltip("The direction vector towards the plane.")]
		[SerializeField]
		private Vector3Var _inDirection;
		
		[Tooltip("The normal vector that defines the plane.")]
		[SerializeField]
		private Vector3Var _inNormal;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inDirection, _inNormal, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Reflect(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Reflect(_inDirection.Value, _inNormal.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Reflect: {_inDirection} {_inNormal} -> {_result}";
		}
	}
}
