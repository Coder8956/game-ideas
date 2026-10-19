using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayMovementRigidbody)]
    [ActionDescription("Moves the Rigidbody by a relative translation using MovePosition.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html")]
    public sealed class RigidbodyTranslate : BaseAction
    {
        [Tooltip("The Rigidbody.")]
        [SerializeField]
        private RigidbodyVar _rigidbody;

        [Tooltip("Move the Rigidbody by this amount in x, y, and z." + Strings.PerSecondNote)]
        [SerializeField]
        private Vector3Var _translation;

        [Tooltip("<b>Self</b>: the movement is applied relative to the Rigidbody transform's local axes." +
                 "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
        [SerializeField]
        private SpaceVar _relativeTo;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() => CheckParameters(_rigidbody, _translation);

        public override void Execute()
        {
            var rigidbody = _rigidbody.Value;
            var delta = _translation.Value * PerSecond;

            if (_relativeTo.Value == Space.Self)
            {
                delta = rigidbody.transform.TransformVector(delta);
            }

            rigidbody.MovePosition(rigidbody.position + delta);
        }

        public override string GetSummary() => "Translate {_rigidbody} by {_translation} in {_relativeTo} space {PerSecond}";
    }
}
