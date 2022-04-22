using System;
using System.Collections.Generic;
using Shared;
using UnityEngine;

namespace DungeonGenerator
{
    public class Cell
    {
        public int X;
        public int Y;
        public bool Active;

        public Dictionary<Dir, bool> Walls = new()
        {
            {Dir.Top, true},
            {Dir.Down, true},
            {Dir.Left, true},
            {Dir.Right, true}
        };
        public bool Visited;
        public Vector2Int Coords => new Vector2Int(X, Y);

        public Cell(int x, int y, bool active = true)
        {
            X = x;
            Y = y;
            Active = active;
        }

        public void BreakWallsBetween(Cell cell)
        {
            var positionDiff = new Vector2Int(cell.X - X, cell.Y - Y);
            var dir = positionDiff.ToDir();
            Walls[dir] = false;
            cell.Walls[dir.Mirror()] = false;
        }

        public void BreakAllWalls(bool visited = true)
        {
            foreach(Dir dir in Enum.GetValues(typeof(Dir))) {
                Walls[dir] = false;
                Visited = visited;
            }
        }
    }
}
