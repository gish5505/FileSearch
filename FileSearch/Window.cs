using FileSearch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Window : Form
    {        
        private RecursiveSearch _recursiveSearch;

        public Window()
        {
            InitializeComponent();

            _recursiveSearch = new RecursiveSearch();
                       
        }

        private void Window_Load(object sender, EventArgs e)
        {
            var config = StateFileHelper.ReadConfig();

            targetFileInput.Text = config.SearchPattern;
            targetDirectoryInput.Text = config.SearchPath;

            timer.TimerElapsed += (s, arg) =>
            {
                try
                {
                    elapsedTimerLabel.BeginInvoke(new Action(() => { SetTimeElapsed(arg.TimeElapsed); }));
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
                }
            };
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            var config = new StateFile();
            config.SearchPattern = targetFileInput.Text;
            config.SearchPath = targetDirectoryInput.Text;
            StateFileHelper.WriteConfig(config);
        }

    }
}
