using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ARC.res
{
    public partial class PromptForm : Form
    {
        private PromptForm()
        {
            InitializeComponent();
        }
        public static PromptResult Show(string text, string title, string button2 = "", string button1 = "")
        {
            var dlg = Initialize(title, text, button1, button2);
            var r = dlg.ShowDialog();
            return new PromptResult(dlg.textBox1.Text, r);
        }

        public static PromptResult Show(string text, string title, out PromptForm form, string button2 = "", string button1 = "")
        {
            var dlg = Initialize(title, text, button1, button2);
            form = dlg;
            var r = dlg.ShowDialog();
            return new PromptResult(dlg.textBox1.Text, r);
        }
        private static PromptForm Initialize(string title, string text, string button1, string button2)
        {
            var dlg = new PromptForm();
            dlg.label1.Text = text;
            dlg.Text = title;
            if (button1 == "") dlg.button1.Text = "OK";
            dlg.button2.Visible = button2 != "";
            dlg.button1.Visible = button1 != "";
            dlg.button1.Click += (s, ee) => dlg.Close();
            dlg.button2.Click += (s, ee) => dlg.Close();
            return dlg;
        }
    }
    public class PromptResult
    {
        public string Value { get; private set; }
        public DialogResult Result { get; private set; }
        public PromptResult(string value, DialogResult result) { Value = value; Result = result; }
    }
}
