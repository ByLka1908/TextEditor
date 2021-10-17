using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            BL.MessageService service = new BL.MessageService();
            BL.FileManager manager = new BL.FileManager();
            BL.MainPresenter presenter = new BL.MainPresenter(form, manager, service);


            Application.Run(form);
        }
    }
}
