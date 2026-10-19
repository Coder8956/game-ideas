using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    internal static class GameObjectDockUtility
    {
        public static Vector3 GetDockPosition(Transform dock, Vector3 localStartPosition, MoveAxis axis)
        {
            if (axis == MoveAxis.XYZ)
            {
                return dock.position;
            }

            var localDockPosition = MoveAxisHelper.Apply(axis, localStartPosition, Vector3.zero);
            return dock.TransformPoint(localDockPosition);
        }

        public static void ApplyImmediateDock(GameObject actor,
                                              Transform dock,
                                              Vector3 localStartPosition,
                                              MoveAxis axis,
                                              bool setPosition,
                                              bool setRotation,
                                              bool zeroVelocity)
        {
            var position = setPosition ? GetDockPosition(dock, localStartPosition, axis) : actor.transform.position;
            var rotation = setRotation ? dock.rotation : actor.transform.rotation;

            if (actor.TryGetComponent<Rigidbody>(out var rb))
            {
                DockRigidbody(rb, position, rotation, setPosition, setRotation, zeroVelocity);
                return;
            }

            if (actor.TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                DockRigidbody2D(rb2d, position, rotation, setPosition, setRotation, zeroVelocity);
                return;
            }

            if (actor.TryGetComponent<CharacterController>(out var controller))
            {
                DockCharacterController(controller, position, rotation, setPosition, setRotation);
                return;
            }

            actor.transform.SetPositionAndRotation(position, rotation);
        }

        public static void ApplySmoothDock(GameObject actor,
                                           Transform dock,
                                           Vector3 startPosition,
                                           Vector3 localStartPosition,
                                           Quaternion startRotation,
                                           MoveAxis axis,
                                           bool setPosition,
                                           bool setRotation,
                                           bool zeroVelocity,
                                           float t)
        {
            var targetPosition = GetDockPosition(dock, localStartPosition, axis);
            var position = setPosition ? Vector3.Lerp(startPosition, targetPosition, t) : actor.transform.position;
            var rotation = setRotation ? Quaternion.Slerp(startRotation, dock.rotation, t) : actor.transform.rotation;

            if (actor.TryGetComponent<Rigidbody>(out var rb))
            {
                DockRigidbody(rb, position, rotation, setPosition, setRotation, zeroVelocity, smooth: true);
                return;
            }

            if (actor.TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                DockRigidbody2D(rb2d, position, rotation, setPosition, setRotation, zeroVelocity, smooth: true);
                return;
            }

            if (actor.TryGetComponent<CharacterController>(out var controller))
            {
                DockCharacterControllerSmooth(controller, position, rotation, setPosition, setRotation);
                return;
            }

            actor.transform.SetPositionAndRotation(position, rotation);
        }

        private static void DockCharacterController(CharacterController controller,
                                                    Vector3 position,
                                                    Quaternion rotation,
                                                    bool setPosition,
                                                    bool setRotation)
        {
            var transformCache = controller.transform;
            var wasEnabled = controller.enabled;

            if (wasEnabled)
            {
                controller.enabled = false;
            }

            transformCache.SetPositionAndRotation(setPosition ? position : transformCache.position,
                                                  setRotation ? rotation : transformCache.rotation);
            Physics.SyncTransforms();

            if (wasEnabled)
            {
                controller.enabled = true;
            }
        }

        private static void DockCharacterControllerSmooth(CharacterController controller,
                                                          Vector3 position,
                                                          Quaternion rotation,
                                                          bool setPosition,
                                                          bool setRotation)
        {
            var transformCache = controller.transform;
            transformCache.SetPositionAndRotation(setPosition ? position : transformCache.position,
                                                  setRotation ? rotation : transformCache.rotation);
        }

        private static void DockRigidbody(Rigidbody rb,
                                          Vector3 position,
                                          Quaternion rotation,
                                          bool setPosition,
                                          bool setRotation,
                                          bool zeroVelocity,
                                          bool smooth = false)
        {
            if (setPosition)
            {
                if (smooth)
                {
                    rb.MovePosition(position);
                }
                else
                {
                    rb.position = position;
                }
            }

            if (setRotation)
            {
                if (smooth)
                {
                    rb.MoveRotation(rotation);
                }
                else
                {
                    rb.rotation = rotation;
                }
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector3.zero);
            rb.angularVelocity = Vector3.zero;
        }

        private static void DockRigidbody2D(Rigidbody2D rb,
                                            Vector3 position,
                                            Quaternion rotation,
                                            bool setPosition,
                                            bool setRotation,
                                            bool zeroVelocity,
                                            bool smooth = false)
        {
            if (setPosition)
            {
                if (smooth)
                {
                    rb.MovePosition(position);
                }
                else
                {
                    rb.position = position;
                }
            }

            if (setRotation)
            {
                var zRotation = rotation.eulerAngles.z;
                if (smooth)
                {
                    rb.MoveRotation(zRotation);
                }
                else
                {
                    rb.rotation = zRotation;
                }
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector2.zero);
            rb.angularVelocity = 0f;
        }
    }
}
