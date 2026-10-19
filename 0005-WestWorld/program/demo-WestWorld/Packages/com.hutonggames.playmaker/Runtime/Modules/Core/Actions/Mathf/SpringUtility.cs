using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    internal static class SpringUtility
    {
        private const float Threshold = 0.001f;

        public static void GetSpringParameters(float duration, float bounciness, float initialOffsetMagnitude,
            out float stiffness, out float damping)
        {
            duration = Mathf.Max(0.0001f, duration);
            bounciness = Mathf.Clamp01(bounciness);

            var dampingRatio = Mathf.Lerp(1f, 0.15f, bounciness);
            var normalizedThreshold = Mathf.Clamp(Threshold / Mathf.Max(initialOffsetMagnitude, Threshold),
                0.0001f, 1f);
            var criticalDampingBoost = Mathf.Lerp(1.5f, 1f, bounciness);
            var angularFrequency = -Mathf.Log(normalizedThreshold) * criticalDampingBoost /
                                   (Mathf.Max(0.01f, dampingRatio) * duration);

            stiffness = angularFrequency * angularFrequency;
            damping = 2f * dampingRatio * angularFrequency;
        }

        public static float Evaluate(float rest, float initialOffset, float stiffness, float damping, float time)
        {
            var value = rest + initialOffset;
            var velocity = 0f;
            Step(ref value, ref velocity, rest, stiffness, damping, Mathf.Max(0f, time));
            return value;
        }

        public static Vector2 Evaluate(Vector2 rest, Vector2 initialOffset, float stiffness, float damping, float time)
        {
            var value = rest + initialOffset;
            var velocity = Vector2.zero;
            Step(ref value, ref velocity, rest, stiffness, damping, Mathf.Max(0f, time));
            return value;
        }

        public static Vector3 Evaluate(Vector3 rest, Vector3 initialOffset, float stiffness, float damping, float time)
        {
            var value = rest + initialOffset;
            var velocity = Vector3.zero;
            Step(ref value, ref velocity, rest, stiffness, damping, Mathf.Max(0f, time));
            return value;
        }

        public static void Step(ref Vector2 value, ref Vector2 velocity, Vector2 rest, float stiffness, float damping,
            float dt)
        {
            var x = value.x;
            var y = value.y;
            var vx = velocity.x;
            var vy = velocity.y;

            Step(ref x, ref vx, rest.x, stiffness, damping, dt);
            Step(ref y, ref vy, rest.y, stiffness, damping, dt);

            value = new Vector2(x, y);
            velocity = new Vector2(vx, vy);
        }

        public static void Step(ref Vector3 value, ref Vector3 velocity, Vector3 rest, float stiffness, float damping,
            float dt)
        {
            var x = value.x;
            var y = value.y;
            var z = value.z;
            var vx = velocity.x;
            var vy = velocity.y;
            var vz = velocity.z;

            Step(ref x, ref vx, rest.x, stiffness, damping, dt);
            Step(ref y, ref vy, rest.y, stiffness, damping, dt);
            Step(ref z, ref vz, rest.z, stiffness, damping, dt);

            value = new Vector3(x, y, z);
            velocity = new Vector3(vx, vy, vz);
        }

        public static void Step(ref float value, ref float velocity, float rest, float stiffness, float damping,
            float dt)
        {
            var displacement = value - rest;

            if (Mathf.Approximately(stiffness, 0f))
            {
                if (Mathf.Approximately(damping, 0f))
                {
                    value += velocity * dt;
                    return;
                }

                var decay = Mathf.Exp(-damping * dt);
                value += velocity * (1f - decay) / damping;
                velocity *= decay;
                return;
            }

            var angularFrequency = Mathf.Sqrt(stiffness);
            var halfDamping = damping * 0.5f;

            if (halfDamping < angularFrequency)
            {
                StepUnderdamped(ref value, ref velocity, rest, displacement, angularFrequency, halfDamping, dt);
            }
            else if (Mathf.Approximately(halfDamping, angularFrequency))
            {
                StepCriticallyDamped(ref value, ref velocity, rest, displacement, halfDamping, dt);
            }
            else
            {
                StepOverdamped(ref value, ref velocity, rest, displacement, angularFrequency, halfDamping, dt);
            }
        }

        private static void StepUnderdamped(ref float value, ref float velocity, float rest, float displacement,
            float angularFrequency, float halfDamping, float dt)
        {
            var dampedFrequency = Mathf.Sqrt(angularFrequency * angularFrequency - halfDamping * halfDamping);
            var decay = Mathf.Exp(-halfDamping * dt);
            var sin = Mathf.Sin(dampedFrequency * dt);
            var cos = Mathf.Cos(dampedFrequency * dt);
            var velocityTerm = (velocity + halfDamping * displacement) / dampedFrequency;

            var newDisplacement = decay * (displacement * cos + velocityTerm * sin);
            var newVelocity = decay *
                              (velocity * cos -
                               (halfDamping * velocity +
                                angularFrequency * angularFrequency * displacement) /
                               dampedFrequency * sin);

            value = rest + newDisplacement;
            velocity = newVelocity;
        }

        private static void StepCriticallyDamped(ref float value, ref float velocity, float rest, float displacement,
            float halfDamping, float dt)
        {
            var decay = Mathf.Exp(-halfDamping * dt);
            var velocityTerm = velocity + halfDamping * displacement;
            var newDisplacement = decay * (displacement + velocityTerm * dt);
            var newVelocity = decay * (velocity - halfDamping * velocityTerm * dt);

            value = rest + newDisplacement;
            velocity = newVelocity;
        }

        private static void StepOverdamped(ref float value, ref float velocity, float rest, float displacement,
            float angularFrequency, float halfDamping, float dt)
        {
            var root = Mathf.Sqrt(halfDamping * halfDamping - angularFrequency * angularFrequency);
            var slowRoot = -halfDamping + root;
            var fastRoot = -halfDamping - root;
            var rootDelta = slowRoot - fastRoot;

            var slow = (velocity - fastRoot * displacement) / rootDelta;
            var fast = displacement - slow;
            var slowDecay = Mathf.Exp(slowRoot * dt);
            var fastDecay = Mathf.Exp(fastRoot * dt);

            var newDisplacement = slow * slowDecay + fast * fastDecay;
            var newVelocity = slow * slowRoot * slowDecay + fast * fastRoot * fastDecay;

            value = rest + newDisplacement;
            velocity = newVelocity;
        }
    }
}
