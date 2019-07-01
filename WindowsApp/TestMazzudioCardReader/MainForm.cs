using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mazzudio.Card.Sdk;

namespace TestMazzudioCardReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Reader _reader;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _reader = new Reader("COM7");
            _reader.OnReadCard += _reader_OnReadCard;
            _reader.StartReadCard();
        }

        private void _reader_OnReadCard(object sender, ReadCardEventArgs e)
        {
            systemStatusRichTextBox.Invoke(new EventHandler(delegate
            {
                string msg = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), e.UIDString);
                systemStatusRichTextBox.AppendText(msg + "\r\n");
                systemStatusRichTextBox.ScrollToCaret();
            }));
            //richTextBox1.Text += e.UIDString + "\r\n";
        }
    }
}
