using HelloTriangle;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.IO;

namespace Pong
{
    public class Game : GameWindow
    {
        //VBO VAO e EBO do obj1
        int VertexBufferObject;
        int VertexArrayObject;
        int ElementBufferObject;
        //VBO VAO e EBO do obj2
        int VertexBufferObject2;
        int VertexArrayObject2;
        int ElementBufferObject2;
        //VBO VAO e EBO do obj3
        int VertexBufferObject3;
        int VertexArrayObject3;
        int ElementBufferObject3;

        private Shader _shader;


        float[] vertices = {
             -0.9f,  0.25f, 0.0f,  // top right
             -0.9f, -0.25f, 0.0f,  // bottom right
             -0.8f, -0.25f, 0.0f,  // bottom left
             -0.8f,  0.25f, 0.0f   // top left
        };

        float[] vertices2 = {
             0.8f,  0.25f, 0.0f,  // top right
             0.8f, -0.25f, 0.0f,  // bottom right
             0.9f, -0.25f, 0.0f,  // bottom left
             0.9f,  0.25f, 0.0f   // top left
        };

        float[] vertices3 = {
             0.024f,  0.024f, 0.0f,  // top right
             0.024f, -0.024f, 0.0f,  // bottom right
            -0.024f, -0.024f, 0.0f,  // bottom left
            -0.024f,  0.024f, 0.0f   // top left
        };

        uint[] indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

        public Game(int width, int height, string title) : base(GameWindowSettings.Default,
        new NativeWindowSettings() { Size = (width, height), Title = title })
        { }

        //atualiza a logica do jogo a cada frame
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

        }

        // Any initialization-related code should go here
        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //objeto 1
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            //objeto 2
            VertexBufferObject2 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject2);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices2.Length * sizeof(float), vertices2, BufferUsageHint.StaticDraw);

            VertexArrayObject2 = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject2);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            ElementBufferObject2 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject2);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            //objeto 3
            VertexBufferObject3 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject3);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices3.Length * sizeof(float), vertices3, BufferUsageHint.StaticDraw);

            VertexArrayObject3 = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject3);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            ElementBufferObject3 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject3);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);


            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
        }

        // Função que desenha as parada na tela a cada frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            _shader.Use();


            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            //desenha outro objeto
            GL.BindVertexArray(VertexArrayObject2);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
            //desenha outro objeto
            GL.BindVertexArray(VertexArrayObject3);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);



            SwapBuffers();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        
    }
}
