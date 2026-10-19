using UnityEngine;
using UnityEngine.Tilemaps;

namespace HutongGames.PlayMaker.Actions
{
    internal static class TilemapSpawnPosition2DUtility
    {
        private struct TilemapGridFrame
        {
            public Vector3 U;
            public Vector3 V;
            public Vector3 Origin;
            public Vector2 CellSize;

            private Matrix4x4 _gridToWorld;
            private Matrix4x4 _worldToGrid;
            private bool _cached;

            public static TilemapGridFrame BuildFrom(Tilemap tilemap)
            {
                var grid = tilemap.layoutGrid;
                var gridToWorld = grid.transform.localToWorldMatrix;
                var tileToGrid = tilemap.orientationMatrix;
                var tileToWorld = gridToWorld * tileToGrid;

                var u = tileToWorld.MultiplyVector(Vector3.right);
                var v = tileToWorld.MultiplyVector(Vector3.up);
                var origin = tilemap.GetCellCenterWorld(Vector3Int.zero) - 0.5f * u - 0.5f * v;

                var frame = new TilemapGridFrame
                {
                    Origin = origin,
                    U = u,
                    V = v,
                    CellSize = new Vector2(u.magnitude, v.magnitude)
                };
                frame.BuildCaches();
                return frame;
            }

            public Matrix4x4 GridToWorldMatrix()
            {
                if (!_cached)
                {
                    BuildCaches();
                }

                return _gridToWorld;
            }

            public Vector2 WorldToGridCoords(Vector3 world)
            {
                if (!_cached)
                {
                    BuildCaches();
                }

                var point = _worldToGrid.MultiplyPoint3x4(world);
                return new Vector2(point.x, point.y);
            }

            private void BuildCaches()
            {
                var normal = Vector3.Cross(U, V).normalized;
                _gridToWorld = Matrix4x4.identity;
                _gridToWorld.SetColumn(0, new Vector4(U.x, U.y, U.z, 0f));
                _gridToWorld.SetColumn(1, new Vector4(V.x, V.y, V.z, 0f));
                _gridToWorld.SetColumn(2, new Vector4(normal.x, normal.y, normal.z, 0f));
                _gridToWorld.SetColumn(3, new Vector4(Origin.x, Origin.y, Origin.z, 1f));

                _worldToGrid = _gridToWorld.inverse;
                _cached = true;
            }
        }

        public static BoundsInt ResolveBounds(Tilemap tilemap, BoundsIntVar bounds)
        {
            if (tilemap == null)
            {
                return new BoundsInt(0, 0, 0, 0, 0, 1);
            }

            if (bounds == null || bounds.IsNone || bounds.Value.size == Vector3Int.zero)
            {
                return GetUsedBounds(tilemap);
            }

            return bounds.Value;
        }

        private static BoundsInt GetUsedBounds(Tilemap tilemap)
        {
            var cellBounds = tilemap.cellBounds;
            if (cellBounds.size.x <= 0 || cellBounds.size.y <= 0)
            {
                return new BoundsInt(0, 0, 0, 0, 0, 1);
            }

            var tiles = tilemap.GetTilesBlock(cellBounds);
            var width = cellBounds.size.x;
            var height = cellBounds.size.y;

            var hasAnyTile = false;
            var minX = 0;
            var minY = 0;
            var maxX = 0;
            var maxY = 0;

            var index = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++, index++)
                {
                    if (tiles[index] == null) continue;

                    if (!hasAnyTile)
                    {
                        hasAnyTile = true;
                        minX = maxX = x;
                        minY = maxY = y;
                        continue;
                    }

                    if (x < minX) minX = x;
                    if (y < minY) minY = y;
                    if (x > maxX) maxX = x;
                    if (y > maxY) maxY = y;
                }
            }

            if (!hasAnyTile)
            {
                return new BoundsInt(0, 0, 0, 0, 0, 1);
            }

            return new BoundsInt(
                cellBounds.xMin + minX,
                cellBounds.yMin + minY,
                cellBounds.zMin,
                maxX - minX + 1,
                maxY - minY + 1,
                1);
        }

        public static Vector3Int WorldToCell(Tilemap tilemap, Vector2 worldPosition)
        {
            return tilemap.WorldToCell(new Vector3(worldPosition.x, worldPosition.y, 0f));
        }

        public static bool TryPickRandomCell(Tilemap tilemap, BoundsInt bounds, TilemapCellSampleMode sampleMode, out Vector3Int cell)
        {
            cell = Vector3Int.zero;

            if (tilemap == null || bounds.size.x <= 0 || bounds.size.y <= 0)
            {
                return false;
            }

            if (sampleMode == TilemapCellSampleMode.AnyCell)
            {
                cell = new Vector3Int(
                    Random.Range(bounds.xMin, bounds.xMax),
                    Random.Range(bounds.yMin, bounds.yMax),
                    bounds.zMin);
                return true;
            }

            var found = 0;
            for (var y = bounds.yMin; y < bounds.yMax; y++)
            {
                for (var x = bounds.xMin; x < bounds.xMax; x++)
                {
                    var candidate = new Vector3Int(x, y, bounds.zMin);
                    var hasTile = tilemap.HasTile(candidate);
                    if (!MatchesSampleMode(sampleMode, hasTile)) continue;

                    found++;
                    if (Random.Range(0, found) == 0)
                    {
                        cell = candidate;
                    }
                }
            }

            return found > 0;
        }

        public static bool TryPickRandomNearWallCell(Tilemap tilemap, BoundsInt bounds, out Vector3Int cell)
        {
            return TryPickRandomNearWallCell(tilemap, bounds, 0.5f, out cell);
        }

        public static bool TryPickRandomNearWallCell(Tilemap tilemap, BoundsInt bounds, float maxDistance, out Vector3Int cell)
        {
            return TryPickRandomMatchingCell(tilemap, bounds, (map, candidate, scanBounds) =>
                !map.HasTile(candidate)
                && IsNearWallCell(map, candidate, scanBounds, maxDistance), out cell);
        }

        public static bool TryPickRandomCornerCell(Tilemap tilemap, BoundsInt bounds, out Vector3Int cell)
        {
            return TryPickRandomCornerCell(tilemap, bounds, 0.5f, out cell);
        }

        public static bool TryPickRandomCornerCell(Tilemap tilemap, BoundsInt bounds, float maxDistance, out Vector3Int cell)
        {
            return TryPickRandomMatchingCell(tilemap, bounds, (map, candidate, scanBounds) =>
                !map.HasTile(candidate)
                && IsCornerCell(map, candidate, scanBounds, maxDistance), out cell);
        }

        private static bool TryPickRandomMatchingCell(
            Tilemap tilemap,
            BoundsInt bounds,
            System.Func<Tilemap, Vector3Int, BoundsInt, bool> match,
            out Vector3Int cell)
        {
            cell = Vector3Int.zero;

            if (tilemap == null || bounds.size.x <= 0 || bounds.size.y <= 0)
            {
                return false;
            }

            var found = 0;
            for (var y = bounds.yMin; y < bounds.yMax; y++)
            {
                for (var x = bounds.xMin; x < bounds.xMax; x++)
                {
                    var candidate = new Vector3Int(x, y, bounds.zMin);
                    if (!match(tilemap, candidate, bounds)) continue;

                    found++;
                    if (Random.Range(0, found) == 0)
                    {
                        cell = candidate;
                    }
                }
            }

            return found > 0;
        }

        private static bool MatchesSampleMode(TilemapCellSampleMode sampleMode, bool hasTile)
        {
            return sampleMode switch
            {
                TilemapCellSampleMode.AnyCell => true,
                TilemapCellSampleMode.OccupiedCell => hasTile,
                TilemapCellSampleMode.EmptyCell => !hasTile,
                _ => true
            };
        }

        public static Vector2 GetWorldPosition(Tilemap tilemap, Vector3Int cell, bool randomPointInCell)
        {
            if (tilemap == null)
            {
                return Vector2.zero;
            }

            if (!randomPointInCell)
            {
                return tilemap.GetCellCenterWorld(cell);
            }

            var grid = tilemap.layoutGrid;
            if (grid == null)
            {
                return tilemap.GetCellCenterWorld(cell);
            }

            var localPoint = grid.CellToLocalInterpolated((Vector3)cell + new Vector3(Random.value, Random.value, 0f));
            return grid.LocalToWorld(localPoint);
        }

        public static bool IsCircleClearOfTiles(Tilemap tilemap, BoundsIntVar bounds, Vector2 worldPosition, float clearance)
        {
            if (tilemap == null)
            {
                return false;
            }

            clearance = Mathf.Max(0f, clearance);

            var resolvedBounds = ResolveBounds(tilemap, bounds);
            if (resolvedBounds.size.x <= 0 || resolvedBounds.size.y <= 0)
            {
                return true;
            }

            var frame = TilemapGridFrame.BuildFrom(tilemap);
            var gridPosition = frame.WorldToGridCoords(worldPosition);
            var minCellSize = Mathf.Max(0.0001f, Mathf.Min(frame.CellSize.x, frame.CellSize.y));
            var cellRadius = Mathf.CeilToInt(Mathf.Max(0f, clearance) / minCellSize) + 2;

            var centerX = Mathf.FloorToInt(gridPosition.x);
            var centerY = Mathf.FloorToInt(gridPosition.y);

            var xMin = Mathf.Max(resolvedBounds.xMin, centerX - cellRadius);
            var yMin = Mathf.Max(resolvedBounds.yMin, centerY - cellRadius);
            var xMax = Mathf.Min(resolvedBounds.xMax, centerX + cellRadius + 1);
            var yMax = Mathf.Min(resolvedBounds.yMax, centerY + cellRadius + 1);

            for (var y = yMin; y < yMax; y++)
            {
                for (var x = xMin; x < xMax; x++)
                {
                    var cell = new Vector3Int(x, y, resolvedBounds.zMin);
                    if (!tilemap.HasTile(cell)) continue;

                    var closestPoint = GetClosestPointOnCell(frame, worldPosition, cell);
                    if (Vector2.Distance(worldPosition, closestPoint) <= clearance)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsNearWall(Tilemap tilemap, BoundsIntVar bounds, Vector2 worldPosition, float maxDistance)
        {
            return IsNearWall(tilemap, ResolveBounds(tilemap, bounds), worldPosition, maxDistance);
        }

        public static bool IsNearWall(Tilemap tilemap, BoundsInt bounds, Vector2 worldPosition, float maxDistance)
        {
            if (tilemap == null)
            {
                return false;
            }

            maxDistance = Mathf.Max(0f, maxDistance);
            if (bounds.size.x <= 0 || bounds.size.y <= 0)
            {
                return false;
            }

            var frame = TilemapGridFrame.BuildFrom(tilemap);
            var candidateCell = WorldToCell(tilemap, worldPosition);
            if (tilemap.HasTile(candidateCell)) return false;

            var gridPosition = frame.WorldToGridCoords(worldPosition);
            var minCellSize = Mathf.Max(0.0001f, Mathf.Min(frame.CellSize.x, frame.CellSize.y));
            var cellRadius = Mathf.CeilToInt(maxDistance / minCellSize) + 2;

            var centerX = Mathf.FloorToInt(gridPosition.x);
            var centerY = Mathf.FloorToInt(gridPosition.y);

            var xMin = Mathf.Max(bounds.xMin, centerX - cellRadius);
            var yMin = Mathf.Max(bounds.yMin, centerY - cellRadius);
            var xMax = Mathf.Min(bounds.xMax, centerX + cellRadius + 1);
            var yMax = Mathf.Min(bounds.yMax, centerY + cellRadius + 1);

            for (var y = yMin; y < yMax; y++)
            {
                for (var x = xMin; x < xMax; x++)
                {
                    var cell = new Vector3Int(x, y, bounds.zMin);
                    if (!tilemap.HasTile(cell)) continue;

                    var closestPoint = GetClosestPointOnCell(frame, worldPosition, cell);
                    if (Vector2.Distance(worldPosition, closestPoint) <= maxDistance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsNearWallCell(Tilemap tilemap, Vector3Int cell, BoundsInt bounds)
        {
            return IsNearWallCell(tilemap, cell, bounds, 0.5f);
        }

        public static bool IsNearWallCell(Tilemap tilemap, Vector3Int cell, BoundsInt bounds, float maxDistance)
        {
            return IsNearWall(tilemap, bounds, tilemap.GetCellCenterWorld(cell), maxDistance);
        }

        public static bool IsCornerCell(Tilemap tilemap, Vector3Int cell, BoundsInt bounds)
        {
            return IsCornerCell(tilemap, cell, bounds, 0.5f);
        }

        public static bool IsCornerCell(Tilemap tilemap, Vector3Int cell, BoundsInt bounds, float maxDistance)
        {
            if (tilemap == null || tilemap.HasTile(cell)) return false;

            maxDistance = Mathf.Max(0f, maxDistance);
            if (IsImmediateCornerCell(tilemap, cell, bounds))
            {
                return true;
            }

            if (maxDistance <= 0f)
            {
                return false;
            }

            var frame = TilemapGridFrame.BuildFrom(tilemap);
            var center = tilemap.GetCellCenterWorld(cell);
            var gridPosition = frame.WorldToGridCoords(center);
            var minCellSize = Mathf.Max(0.0001f, Mathf.Min(frame.CellSize.x, frame.CellSize.y));
            var cellRadius = Mathf.CeilToInt(maxDistance / minCellSize) + 1;

            var centerX = Mathf.FloorToInt(gridPosition.x);
            var centerY = Mathf.FloorToInt(gridPosition.y);

            var xMin = Mathf.Max(bounds.xMin, centerX - cellRadius);
            var yMin = Mathf.Max(bounds.yMin, centerY - cellRadius);
            var xMax = Mathf.Min(bounds.xMax, centerX + cellRadius + 1);
            var yMax = Mathf.Min(bounds.yMax, centerY + cellRadius + 1);

            for (var y = yMin; y < yMax; y++)
            {
                for (var x = xMin; x < xMax; x++)
                {
                    var candidateCornerCell = new Vector3Int(x, y, bounds.zMin);
                    if (!IsImmediateCornerCell(tilemap, candidateCornerCell, bounds)) continue;

                    if (Vector2.Distance(center, tilemap.GetCellCenterWorld(candidateCornerCell)) <= maxDistance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsImmediateCornerCell(Tilemap tilemap, Vector3Int cell, BoundsInt bounds)
        {
            if (tilemap == null || tilemap.HasTile(cell)) return false;

            var left = HasTile(tilemap, cell + Vector3Int.left, bounds);
            var right = HasTile(tilemap, cell + Vector3Int.right, bounds);
            var up = HasTile(tilemap, cell + Vector3Int.up, bounds);
            var down = HasTile(tilemap, cell + Vector3Int.down, bounds);

            return (left && up)
                   || (left && down)
                   || (right && up)
                   || (right && down);
        }

        private static bool HasTile(Tilemap tilemap, Vector3Int cell, BoundsInt bounds)
        {
            return bounds.Contains(cell) && tilemap.HasTile(cell);
        }

        private static Vector2 GetClosestPointOnCell(TilemapGridFrame frame, Vector2 worldPosition, Vector3Int cell)
        {
            var gridPosition = frame.WorldToGridCoords(worldPosition);
            var clampedX = Mathf.Clamp(gridPosition.x, cell.x, cell.x + 1f);
            var clampedY = Mathf.Clamp(gridPosition.y, cell.y, cell.y + 1f);
            var closestWorld = frame.GridToWorldMatrix().MultiplyPoint3x4(new Vector3(clampedX, clampedY, 0f));
            return closestWorld;
        }
    }
}
