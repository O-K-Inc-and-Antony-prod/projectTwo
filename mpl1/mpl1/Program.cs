using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mpl1
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
            Application.Run(new Form1());
        }

    }

    /// <summary>
    /// класс для тестирование.
    /// </summary>
    public static class f
    {
        /// <summary>
        /// умножение  число на число.
        /// </summary>
        /// <param name="variable1">число 1</param>
        /// <param name="variable2">число 2</param>
        /// <returns></returns>
        public static double vozvedenie(double variable1, double variable2)
        {
            variable1++;
            variable2--;
            variable2--;
            var vozv = variable1 *variable2;

            return vozv;
        }
    }
}
