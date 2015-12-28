using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace DiplomPonomarev
{
    public partial class Form1 : Form
    {
        public Device device = null;

        public Form1()
        {
            InitializeComponent();
        }

        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                device = new Device(0, DeviceType.Hardware, this.pnlDevice, CreateFlags.HardwareVertexProcessing, presentParams);

                InitCamera();
                InitVerticies();

                return true;
            }
            catch (DirectXException)
            {
                return false;
            }
        }

        private float angle = 0.0f;
        private void InitCamera()
        {
            // Параметры камеры
            device.Transform.Projection =
                // представление поля y (угол при вершине пирамиды).
                Matrix.PerspectiveFovLH((float)Math.PI / 4f,
                (float)this.Width / (float)this.Height, 1, 10000);
            // Установка камеры
            device.Transform.View =
                // положение камеры во внешней системе координат
                Matrix.LookAtLH(new Vector3(0, 0, 50),
                // местоположение объекта, на который нацелена камера
                new Vector3(),
                // направление камеры (у нас - вверх). 
                new Vector3(0, 1, 0));

            // Отключим освещение в сцене. Это позволяет видеть объект
            // в обычном режиме без установки нормалей. 
            //device.RenderState.Lighting = false;

            //----!!!Режим отбора и устранения(исключени невидимой поверхности)
            // В таком режиме, треугольник не исчезает при вращении, обернувшись
            // к нам задней поверхностью.
            device.RenderState.CullMode = Cull.None;

        }

        CustomVertex.PositionColored[] Vertex = new CustomVertex.PositionColored[3];
        public void InitVerticies()
        {
            Vertex[0] = new CustomVertex.PositionColored(new Vector3(), Color.Black.ToArgb());
            Vertex[1] = new CustomVertex.PositionColored(new Vector3(5, 0, 0), Color.Black.ToArgb());
            Vertex[2] = new CustomVertex.PositionColored(new Vector3(0, 5, 0), Color.Black.ToArgb());
        }

        public void RotateTriangle()
        {
            //-----!!!----- Вращение объекта относительно оси Z  
            //device.Transform.World = Matrix.RotationZ((float)Math.PI/6.0f);
            //device.Transform.World = Matrix.RotationY((System.Environment.TickCount / 25.0f) / (float)Math.PI / 6);
            //device.Transform.World = Matrix.RotationZ(angle/(float)Math.PI);
            // В следующей функции мы сначала определяем ось, вокруг которой намерены
            // вращать треугольник, а затем вводим угол поворота.
            device.Transform.World = Matrix.RotationAxis(
               new Vector3(angle / ((float)Math.PI * 2.0f),
                angle / ((float)Math.PI * 4.0f),
                angle / ((float)Math.PI * 6.0f)),
                angle / (float)Math.PI);
            angle += 0.06f; // такой подход вообще говоря не оправдан, поскольку скорость 
            // вращения зависит от мощности компьютера
        }

        public void Draw()
        {
            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, Vertex.Length / 3, Vertex); 
        }

        public void Render()
        {
            device.Clear(ClearFlags.Target, Color.White, 0, 1);
            RotateTriangle();
            device.BeginScene();
            Draw();
            device.EndScene();
            device.Present();
        }
    }
}
