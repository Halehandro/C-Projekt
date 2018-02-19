using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Threading;

namespace ListaProcesa
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            listView1.Items.Clear();

            Process[] Aktivni = Process.GetProcesses();

            foreach (Process proc in Aktivni)
            {
                PerformanceCounter PROCcpu =
                    new PerformanceCounter("Process", "% Processor Time", proc.ProcessName, true);

                ListViewItem item = new ListViewItem((proc.ProcessName).ToString());
                item.SubItems.Add(PROCcpu.NextValue() + " " + "%");
                item.SubItems.Add(((proc.WorkingSet64/ 1024) / 1024).ToString() + " " + "MB" );
                listView1.Items.Add(item);
            }

        }

        private void Osvjezi_Tick(object sender, EventArgs e)
        {
            LoadProcesses();
        }
    }
}
