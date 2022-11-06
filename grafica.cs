using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace ConsoleApp5
{
    internal class grafica : GameWindow
    {

        private KeyboardState previousKeyboard;
        private Randomiz rando;
        private Triunghi firstTriangle;

        Color DEFAULT_BKG_COLOR = Color.Azure;

        public grafica() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            rando = new Randomiz();
            firstTriangle = new Triunghi(rando);

            Meniu();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // set the eye
            Matrix4 eye = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

         
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
               Meniu();
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.GenerareCuloare());
            }

            if (currentKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
               
                firstTriangle.DiscoMode();
            }

            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
              
                firstTriangle.ToggleVisibility();
            }
            if (currentKeyboard[Key.M] && !previousKeyboard[Key.M])
            {

                firstTriangle.Morph();
            }
            previousKeyboard = currentKeyboard;
            
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            firstTriangle.Draw();

            SwapBuffers();
        }

        private void Meniu()
        {
            Console.WriteLine("\n     MENIU");
            Console.WriteLine(" H - meniu ajutor");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" R - resetare scena");
            Console.WriteLine(" B - schimbare culoare de fundal");
            Console.WriteLine(" V - afiseaza/ascunde triunghiurile");
            Console.WriteLine(" X - schimbare culoare triunghi");
            Console.WriteLine(" M - modifica pozitie");
        }
    }
} 
