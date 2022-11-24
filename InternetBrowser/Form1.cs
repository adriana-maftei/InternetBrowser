using System;
using System.Windows.Forms;

namespace InternetBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Navigate()
        {
            toolStripStatusLabel1.Text = "Navigation has started";

            btn_browse.Enabled = false; //disable them until the navigation process is finished
            box_URL.Enabled = false;

            webBrowser1.Navigate(box_URL.Text); //core command of navigation to URL
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            Navigate();
        }

        private void box_URL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                Navigate(); //if enter it's pressed, automatically navigate to URL
            //also possible by cloning the button behavior using: btn_browse_Click(null, null);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            box_URL.Text = webBrowser1.Url.ToString();
        }

        private void btn_GoForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a functional internet browser. Please enter a URL to navigate and test it.");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btn_browse.Enabled = true;
            box_URL.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation complete";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0) //to avoid division by zero error
                toolStripProgressBar1.ProgressBar.Value = (int)((e.CurrentProgress * 100) / (e.MaximumProgress * 100));
            // this will display loading time in progress bar
        }
    }
}