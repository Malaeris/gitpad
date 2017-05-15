using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainRichTextBox : System.Windows.Forms.Form
    {


        public MainRichTextBox()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Text = "";
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help!!!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(richtext.Text.Length>0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;

            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.Copy();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectAll();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dateTimeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            richtext.Text += DateTime.Now;

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Need to learn how to disable word wrap and enable on click
            
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //Needs to learn how to bring up find form dialog to query text  richtext.FindForm();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectionFont = new Font(richtext.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectionFont = new Font(richtext.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectionFont = new Font(richtext.Font, FontStyle.Underline);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectionFont = new Font(richtext.Font, FontStyle.Strikeout);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtext.SelectionFont = new Font(richtext.Font, FontStyle.Regular);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if(saveFile1.ShowDialog() == DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                richtext.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Open my new File";
            of.Filter ="Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
                richtext.LoadFile(of.FileName, RichTextBoxStreamType.PlainText);
            this.Text = of.FileName;
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richtext.Font;
            fd.ShowDialog();
            richtext.Font = fd.Font;
        }

        private void MainRichTextBox_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure you want to close?");

        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
