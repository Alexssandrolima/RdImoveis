﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rd_Imoveis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. alexssandrolima@gmal.com  agora vai
        /// </summary> 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.FormPrincipal());
        }
    }
}
