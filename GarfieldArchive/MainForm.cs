using System;
using System.IO;
using System.Windows.Forms;

namespace GarfieldArchive
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChooseOutputDir_Click(object sender, EventArgs e)
        {
            var fld = new FolderBrowserDialog
            {
                ShowNewFolderButton = true // Show the "Make new folder" button
            };

            if (fld.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            outputDir.Text = fld.SelectedPath;
        }

        private async void StartDownload_Click(object sender, EventArgs e)
        {
            var outputDir = this.outputDir.Text;

            if (!Directory.Exists(outputDir))
            {
                MessageBox.Show("Specified output directory doesn't exist!", "oops");
                return;
            }

            var dl = new Downloader();
            dataGridView1.DataSource = dl.DataTable;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor = Cursors.WaitCursor;
            button2.Enabled = false;
            await dl.DownloadAll(outputDir);
            button2.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}