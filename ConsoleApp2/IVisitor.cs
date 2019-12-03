using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp2
{
    public interface IVisitor
    {
        void Visit(TriangleClient client);
        void Visit(RectangleClient client);
        void Visit(CircleClient client);
    }

    public class DrawVisitor : IVisitor
    {
        public void Visit(TriangleClient client)
        {
            var maxW = Math.Max(Math.Max(client.Figure.X.X, client.Figure.Y.X), client.Figure.Z.X);
            var maxH = Math.Max(Math.Max(client.Figure.X.Y, client.Figure.Y.Y), client.Figure.Z.Y);
            var picture = new Bitmap(maxW, maxH);

            using (var graphics = Graphics.FromImage(picture))
            {
                graphics.DrawPolygon(Pens.Aqua, new[] {client.Figure.X, client.Figure.Y, client.Figure.Z});
            }

            client.Picture = picture;
        }

        public void Visit(RectangleClient client)
        {
            var length = Math.Max(client.Figure.Width, client.Figure.Height);
            var picture = new Bitmap(length, length);

            using (var graphics = Graphics.FromImage(picture))
            {
                graphics.DrawRectangle(Pens.Blue, 0, 0, client.Figure.Width, client.Figure.Height);
            }

            client.Picture = picture;
        }

        public void Visit(CircleClient client)
        {
            var length = 2 * client.Figure.Radius;
            var picture = new Bitmap(length, length);

            using (var graphics = Graphics.FromImage(picture))
            {
                graphics.DrawEllipse(Pens.Blue, client.Figure.Radius, client.Figure.Radius,
                    client.Figure.Radius * 2, client.Figure.Radius * 2);
            }

            client.Picture = picture;
        }
    }

    public class PerimeterVisitor : IVisitor
    {
        public void Visit(TriangleClient client)
        {
            client.Perimeter = client.Figure.GetPerimeter;
        }

        public void Visit(RectangleClient client)
        {
            client.Perimeter = (client.Figure.Width + client.Figure.Height) * 2;
        }

        public void Visit(CircleClient client)
        {
            client.Perimeter = Math.PI * 2 * client.Figure.Radius;
        }
    }

    public class GetAreaVisitor : IVisitor
    {
        public void Visit(TriangleClient client)
        {
            var halfP = client.Figure.GetPerimeter / 2;
            client.Area = Math.Sqrt(
                halfP * (halfP - client.Figure.GetASide) * (halfP - client.Figure.GetBSide) *
                (halfP - client.Figure.GetCSide)
            );
        }

        public void Visit(RectangleClient client)
        {
            client.Area = client.Figure.Width * client.Figure.Height;
        }

        public void Visit(CircleClient client)
        {
            client.Area = Math.PI * Math.Pow(client.Figure.Radius, 2);
        }
    }
}