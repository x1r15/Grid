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
        
        public static Direction Mirror(this Direction dir) => dir switch
        {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new ArgumentOutOfRangeException()
        };
}
