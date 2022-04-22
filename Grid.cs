using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shared
{
    public class Grid<T>
    {
        public T[] Cells { get; }
        public int Width { get; }
        public int Height { get; }

        public Grid(int width, int height, Func<int, int, T> init)
        {
            Width = width;
            Height = height;
            Cells = new T[Width * Height];
            for (var i = 0; i < Cells.Length; i++)
            {
                var coords = IndexToCoordinates(i);
                Cells[i] = init(coords.x, coords.y);
            }
        }

        public Vector2Int GetCoords(T cell)
        {
            return IndexToCoordinates(Array.IndexOf(Cells, cell));
        }
        
        public int CoordinatesToIndex(Vector2Int coords)
        {
            return coords.x + Width * coords.y;
        }
        
        public int CoordinatesToIndex(int x, int y)
        {
            return x + Width * y;
        }

        public Vector2Int IndexToCoordinates(int i)
        {
            return new Vector2Int(i % Width, i / Width);
        }

        public bool AreCoordsValid(Vector2Int coords, bool safeWalls = false)
        {
            return AreCoordsValid(coords.x, coords.y, safeWalls);
        }

        public bool AreCoordsValid(int x, int y, bool safeWalls = false)
        {
            return safeWalls ? 
                x >= 1 && y >= 1 && x < Width - 1 && y < Height - 1 :
                x >= 0 && y >= 0 && x < Width && y < Height;
        }
        
        public void Set(int i, T value)
        {
            Cells[i] = value;
        }

        public T Get(int i)
        {
            return Cells[i];
        }

        public void Set(Vector2Int coords, T value)
        {
            Cells[CoordinatesToIndex(coords)] = value;
        }

        public T Get(Vector2Int coords)
        {
            return Cells[CoordinatesToIndex(coords)];
        }

        public T Get(int x, int y)
        {
            return Cells[CoordinatesToIndex(x, y)];
        }

        public List<T> GetNeighbours(Vector2Int coords, Func<T, bool> predicate)
        {
            var neighbours = new List<T>();
            if (coords.x > 0) neighbours.Add(Get(coords.x - 1, coords.y));
            if (coords.y > 0) neighbours.Add(Get(coords.x, coords.y - 1));
            if (coords.x < Width - 1) neighbours.Add(Get(coords.x + 1, coords.y));
            if (coords.y < Height - 1) neighbours.Add(Get(coords.x, coords.y + 1));
            return neighbours.Where(predicate).ToList();
        }
    }
}
