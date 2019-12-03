using System.Drawing;

namespace ConsoleApp2
{
    public abstract class Client<TFigure> where TFigure : IFigure
    {
        public double Area;
        public double Perimeter;
        public Bitmap Picture;
        public readonly TFigure Figure;

        public Client(TFigure figure)
        {
            Figure = figure;
        }
    }
    
    public class CircleClient : Client<Circle>
    {
        public CircleClient(Circle figure) : base(figure)
        {
        }
    }

    public class RectangleClient : Client<Rectangle>
    {
        public RectangleClient(Rectangle figure) : base(figure)
        {
        }
    }

    public class TriangleClient : Client<Triangle>
    {
        public TriangleClient(Triangle figure) : base(figure)
        {
        }
    }
}