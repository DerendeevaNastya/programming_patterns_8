using System;
using System.Drawing;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(4);
            var rectangle = new Rectangle(1, 3);
            var triangle = new Triangle(new Point(2, 2), new Point(4, 4), new Point(4, 2));
            
            var rectangleClient = new RectangleClient(rectangle);
            var circleClient = new CircleClient(circle); 
            var triangleClient = new TriangleClient(triangle);

            var perimeterVisitor = new PerimeterVisitor();
            var areaVisitor = new GetAreaVisitor();
            var drawVisitor = new DrawVisitor();
            var visitors = new IVisitor[] {perimeterVisitor, areaVisitor, drawVisitor};
            
            foreach (var visitor in visitors)
            {
                visitor.Visit(circleClient);
                visitor.Visit(rectangleClient);
                visitor.Visit(triangleClient);
            }
            Console.WriteLine("Perimeters");
            Console.WriteLine(rectangleClient.Perimeter);
            Console.WriteLine(circleClient.Perimeter);
            Console.WriteLine(triangleClient.Perimeter);

            Console.WriteLine();

            Console.WriteLine("Areas");
            Console.WriteLine(rectangleClient.Area);
            Console.WriteLine(circleClient.Area);
            Console.WriteLine(triangleClient.Area);
        }
    }
}