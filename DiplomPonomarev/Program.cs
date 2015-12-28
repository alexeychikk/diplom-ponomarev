using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomPonomarev
{
    static class Program
    {
        static void Main()
        {
            using (Form1 frm = new Form1())
            {
                if (!frm.InitializeGraphics())
                {
                    MessageBox.Show("Помилка ініціалізації Direct3D!\nНатисніть ОК для завершення програми.", "Direct3D Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frm.Show();

                while (frm.Created)
                {
                    frm.Render();
                    Application.DoEvents();
                }
            }
        }
    }
}
