using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyInstallerClass
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
            this.Committed += MyInstaller_Committed;
        }
        private void MyInstaller_Committed(object sender, InstallEventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location));
                Process.Start(Path.GetDirectoryName(
                  Assembly.GetExecutingAssembly().Location) + "\\MyApp.exe");

                //重開機自動啟動
                RegistryKey RKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                RKey.SetValue("MyApp", Path.GetDirectoryName(
                  Assembly.GetExecutingAssembly().Location) + "\\MyApp.exe");

                //執行程式
                Application.Run(new Form1());
            }
            catch
            {
                // Do nothing... 
            }
        }
    }
}
