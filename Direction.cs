using System;
using UnityEngine;

public enum Direction
{
        North, South, East, West
}

public static class DirectionExtensions
{
        public static Vector2Int ToCoords(this Direction self)
        {
                return self switch
                {
                        Direction.North => new Vector2Int(0, 1),
                        Direction.South => new Vector2Int(0, -1),
                        Direction.East => new Vector2Int(1, 0),
                        Direction.West => new Vector2Int(-1, 0),
                        _ => throw new ArgumentOutOfRangeException()
                };
        }

        public static Direction ToDirection(this Vector2Int self)
        {
                if (self == new Vector2Int(0, 1)) return Direction.North;
                if (self == new Vector2Int(0, -1)) return Direction.South;
                if (self == new Vector2Int(1, 0)) return Direction.East;
                if (self == new Vector2Int(-1, 0)) return Direction.West;
                throw new ArgumentException();
        }
}
