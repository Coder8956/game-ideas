using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    public enum OffscreenPlacementMode
    {
        CameraDepth,
        WorldZ
    }

    public static class OffscreenPositionUtility
    {
        private const float ViewportEpsilon = 0.01f;

        public static Vector3 GetRandomOffscreenWorldPoint(Camera camera, OffscreenPlacementMode placementMode, float zPlane, float padding)
        {
            if (camera == null)
            {
                return Vector3.zero;
            }

            var zDepth = GetSamplingDepth(camera, placementMode, zPlane);
            padding = Mathf.Max(0f, padding);

            var bottomLeft = camera.ViewportToWorldPoint(new Vector3(0f, 0f, zDepth));
            var bottomRight = camera.ViewportToWorldPoint(new Vector3(1f, 0f, zDepth));
            var topLeft = camera.ViewportToWorldPoint(new Vector3(0f, 1f, zDepth));

            var planeWidth = Vector3.Distance(bottomLeft, bottomRight);
            var planeHeight = Vector3.Distance(bottomLeft, topLeft);

            var xPadding = planeWidth > Mathf.Epsilon ? padding / planeWidth : 0f;
            var yPadding = planeHeight > Mathf.Epsilon ? padding / planeHeight : 0f;

            var horizontalBand = Mathf.Max(xPadding, ViewportEpsilon);
            var verticalBand = Mathf.Max(yPadding, ViewportEpsilon);

            var outerXMin = -horizontalBand;
            var outerXMax = 1f + horizontalBand;
            var outerYMin = -verticalBand;
            var outerYMax = 1f + verticalBand;

            var outerWidth = outerXMax - outerXMin;
            var innerHeight = 1f;
            var topArea = outerWidth * verticalBand;
            var bottomArea = outerWidth * verticalBand;
            var leftArea = horizontalBand * innerHeight;
            var rightArea = horizontalBand * innerHeight;
            var totalArea = topArea + bottomArea + leftArea + rightArea;

            Vector3 viewportPoint;

            var pick = Random.Range(0f, totalArea);
            if (pick < topArea)
            {
                viewportPoint = new Vector3(
                    Random.Range(outerXMin, outerXMax),
                    Random.Range(1f + ViewportEpsilon, outerYMax),
                    zDepth);
            }
            else if (pick < topArea + bottomArea)
            {
                viewportPoint = new Vector3(
                    Random.Range(outerXMin, outerXMax),
                    Random.Range(outerYMin, -ViewportEpsilon),
                    zDepth);
            }
            else if (pick < topArea + bottomArea + leftArea)
            {
                viewportPoint = new Vector3(
                    Random.Range(outerXMin, -ViewportEpsilon),
                    Random.Range(0f, 1f),
                    zDepth);
            }
            else
            {
                viewportPoint = new Vector3(
                    Random.Range(1f + ViewportEpsilon, outerXMax),
                    Random.Range(0f, 1f),
                    zDepth);
            }

            return ViewportToWorldPoint(camera, placementMode, viewportPoint, zDepth, zPlane);
        }

        private static float GetSamplingDepth(Camera camera, OffscreenPlacementMode placementMode, float zPlane)
        {
            if (placementMode != OffscreenPlacementMode.WorldZ)
            {
                return zPlane;
            }

            var forwardZ = camera.transform.forward.z;
            if (Mathf.Abs(forwardZ) <= Mathf.Epsilon)
            {
                return zPlane;
            }

            return (zPlane - camera.transform.position.z) / forwardZ;
        }

        private static Vector3 ViewportToWorldPoint(Camera camera, OffscreenPlacementMode placementMode, Vector3 viewportPoint, float zDepth, float zPlane)
        {
            if (placementMode != OffscreenPlacementMode.WorldZ)
            {
                return camera.ViewportToWorldPoint(viewportPoint);
            }

            var ray = camera.ViewportPointToRay(new Vector3(viewportPoint.x, viewportPoint.y, 0f));
            var directionZ = ray.direction.z;
            if (Mathf.Abs(directionZ) <= Mathf.Epsilon)
            {
                return camera.ViewportToWorldPoint(new Vector3(viewportPoint.x, viewportPoint.y, zDepth));
            }

            var distance = (zPlane - ray.origin.z) / directionZ;
            return ray.GetPoint(distance);
        }

    }
}
