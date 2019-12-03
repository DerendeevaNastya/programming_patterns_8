using System;
using System.Drawing;
using System.Threading;

namespace ConsoleApp2
{
    public interface IFigure
    {
    }

    public class Circle : IFigure
    {
        public readonly int Radius;

        public Circle(int radius)
        {
            Radius = radius;
        }
    }

    public class Rectangle : IFigure
    {
        public readonly int Width;
        public readonly int Height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class Triangle : IFigure
    {
        public readonly Point X;
        public readonly Point Y;
        public readonly Point Z;

        public double GetPerimeter => GetASide + GetBSide + GetCSide;
        public double GetASide => Math.Sqrt(Math.Pow(X.X - Y.X, 2) + Math.Pow(X.Y - Y.Y, 2));
        public double GetBSide => Math.Sqrt(Math.Pow(X.X - Z.X, 2) + Math.Pow(X.Y - Z.Y, 2));
        public double GetCSide => Math.Sqrt(Math.Pow(Z.X - Y.X, 2) + Math.Pow(Z.Y - Y.Y, 2));

        public Triangle(Point x, Point y, Point z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}