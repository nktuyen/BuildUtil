using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuildUtil
{
    public partial class frmMain : Form
    {
        public BuildCommandLine CommandLine { get; set; }

        public frmMain(BuildCommandLine cmdLine)
        {
            InitializeComponent();

            this.CommandLine = cmdLine;
        }
    }
}
