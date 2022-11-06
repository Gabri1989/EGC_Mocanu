using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace ConsoleApp5
{
    class Axe
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private bool visibility;
        private float width;
        private Color color;
        private float BIG_SIZE = 5.0f;
        private float DEFAULT_SIZE = 50.0f;

        public Axe(Randomiz _r)
        {
            pointA = new Vector3(0, 0, 0);
            pointB = new Vector3(10, 0, 0);
            visibility = true;
            width = DEFAULT_SIZE;
            color = _r.GenerareCuloare();
        }
        public Axe(Vector3 a, Vector3 b, Randomiz _r)
        {
            pointA = a;
            pointB = b;
            visibility = true;
            width = DEFAULT_SIZE;
            color = _r.GenerareCuloare();
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.LineWidth(width);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.End();
            }
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleWidth()
        {
            if (width == DEFAULT_SIZE)
            {
                width = BIG_SIZE;
            }
            else
            {
                width = DEFAULT_SIZE;
            }
        }

        public void DiscoMode(Randomiz _r)
        {
            color = _r.GenerareCuloare();
        }
    }
}
