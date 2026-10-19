
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Translate the anchored position of this RectTransform. " +
	                   "\n\nNote, the root canvas scale factor is taken into account so translation looks correct. " +
	                   "For example, you can use PointerEventData.delta to move a UI element with the mouse.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition.html")]
	public sealed class RectTransformTranslate : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("The translation to apply to the anchored position.")]
		[SerializeField]
		private Vector2Var _translate;

		[OptionalField]
		[Tooltip("The root canvas. Used to calculate the scale factor for the translation. " +
		         "If left empty, the action will find the root canvas.")]
		[SerializeField]
		private CanvasVar _rootCanvas;
		
		private Canvas _canvas;
		
		public override bool CanExecute() => CheckParameters(_rectTransform, _translate);

		public override void OnStart()
		{
			_canvas = _rootCanvas.Value;
			if (_canvas) return;
			var canvases = _rectTransform.Value.GetComponentsInParent<Canvas>();
			if (canvases.Length == 0)
			{
				LogError("No Canvas found in parent hierarchy. Disabling action.");
				Finish();
				return;
			}
			_canvas = canvases[^1];
		}

		public override void Execute() => 
			_rectTransform.Value.anchoredPosition += _translate.Value / _canvas.scaleFactor;

		public override string GetSummary() => "Translate {_rectTransform} anchored position by {_translate}";
	}
}
