using System;
using UnityEngine;

namespace Shared
{
    public enum Dir
    {
        Top, Down, Left, Right
    }

    public static class DirExtensions
    {
        public static Vector2Int ToCoords(this Dir dir) => dir switch
        {
            Dir.Top => new Vector2Int(0, 1),
            Dir.Down => new Vector2Int(0, -1),
            Dir.Left => new Vector2Int(-1, 0),
            Dir.Right => new Vector2Int(1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };

        public static Dir ToDir(this Vector2Int coords) => coords.x switch
        {
            -1 when coords.y == 0 => Dir.Left,
            1 when coords.y == 0 => Dir.Right,
            0 when coords.y == -1 => Dir.Down,
            0 when coords.y == 1 => Dir.Top,
            _ => throw new ArgumentOutOfRangeException(nameof(coords), coords, null)
        };

        public static Dir Mirror(this Dir dir) => dir switch
        {
            Dir.Top => Dir.Down,
            Dir.Down => Dir.Top,
            Dir.Left => Dir.Right,
            Dir.Right => Dir.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };
    }
}
