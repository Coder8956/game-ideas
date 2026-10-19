using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ActionDescription("Moves the Rigidbody2D by a relative translation using MovePosition.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.MovePosition.html")]
	public sealed class Rigidbody2DTranslate : BaseAction
	{
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;

		[Tooltip("Move the Rigidbody2D by this amount in x and y." + Strings.PerSecondNote)]
		[SerializeField]
		private Vector2Var _translation;

		[Tooltip("<b>Self</b>: the movement is applied relative to the Rigidbody2D transform's local axes." +
		         "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
		[SerializeField]
		private SpaceVar _relativeTo;

		public override bool CanUsePerSecond => true;

		public override bool CanExecute() => CheckParameters(_rigidbody2D, _translation);

		public override void Execute()
		{
			var rigidbody2D = _rigidbody2D.Value;
			var delta = _translation.Value * PerSecond;

			if (_relativeTo.Value == Space.Self)
			{
				delta = rigidbody2D.transform.TransformVector(delta);
			}

			rigidbody2D.MovePosition(rigidbody2D.position + delta);
		}

		public override string GetSummary() => "Translate {_rigidbody2D} by {_translation} in {_relativeTo} space {PerSecond}";
	}
}
