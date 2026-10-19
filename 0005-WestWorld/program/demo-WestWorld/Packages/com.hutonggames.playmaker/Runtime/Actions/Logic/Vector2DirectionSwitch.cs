using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on the cardinal direction of a Vector2 variable.")]
    public class Vector2DirectionSwitch : BaseAction
    {
        public enum Direction
        {
            None,
            Left,
            Right,
            Up,
            Down
        }
        
        [Tooltip("The Vector2 to check.")]
        [SerializeField]
        private Vector2Ref _vector2;

        [Tooltip("Event to send if the direction of the vector is left")]
        [SerializeField, OptionalField]
        private EventRef _left;
        
        [Tooltip("Event to send if the direction of the vector is right")]
        [SerializeField, OptionalField]
        private EventRef _right;
        
        [Tooltip("Event to send if the direction of the vector is up")]
        [SerializeField, OptionalField]
        private EventRef _up;
        
        [Tooltip("Event to send if the direction of the vector is down")]
        [SerializeField, OptionalField]
        private EventRef _down;
        
        [Tooltip("Event to send if the vector has no direction.")]
        [SerializeField, OptionalField]
        private EventRef _none;
        
        public override void Execute()
        {
            if (!RuntimeCheck(_vector2)) return;

            var axisDirection = GetDirection(_vector2.Value);
            switch (axisDirection)
            {
                case Direction.Left:
                    SendEvent(_left);
                    break;
                case Direction.Right:
                    SendEvent(_right);
                    break;
                case Direction.Up:
                    SendEvent(_up);
                    break;
                case Direction.Down:
                    SendEvent(_down);
                    break;
                case Direction.None:
                default:
                    SendEvent(_none);
                    break;
            }
        }
        
        private Direction GetDirection(Vector2 vector2)
        {
            // Check if the vector is essentially zero (no direction)
            if (vector2.sqrMagnitude < 0.001f) // Using sqrMagnitude for better performance
            {
                return Direction.None;
            }

            // Get absolute values to compare magnitudes
            var absX = Mathf.Abs(vector2.x);
            var absY = Mathf.Abs(vector2.y);

            // Determine if horizontal or vertical component is dominant
            if (absX > absY)
            {
                // Horizontal direction is dominant
                return vector2.x > 0 ? Direction.Right : Direction.Left;
            }

            // Vertical direction is dominant
            return vector2.y > 0 ? Direction.Up : Direction.Down;
        }
        
        public override string GetSummary() => "{_vector2} direction switch";
    }
}