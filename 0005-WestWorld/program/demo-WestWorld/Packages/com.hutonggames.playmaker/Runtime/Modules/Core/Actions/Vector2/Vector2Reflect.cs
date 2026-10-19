
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Reflects a vector off the surface defined by a normal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Reflect.html")]
	public sealed class Vector2Reflect : BaseAction
	{
		
		[Tooltip("The direction vector towards the surface.")]
		[SerializeField]
		private Vector2Var _inDirection;
		
		[Tooltip("The normal vector that defines the surface.")]
		[SerializeField]
		private Vector2Var _inNormal;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inDirection, _inNormal, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Reflect(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.Reflect(_inDirection.Value, _inNormal.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Reflect: {_inDirection} {_inNormal} -> {_result}";
		}
	}
}
