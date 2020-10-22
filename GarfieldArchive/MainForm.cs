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
            startDate.Value = new DateTime(1978, 6, 19);
            startDate.CustomFormat = "  yyyy-MM-dd";
            startDate.MaxDate = DateTime.Today;
            setconvert2PNG();
            setchooseISO();
            setMonthFolders();
            setStartStrip();
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

        public static bool convert2PNG { set; get; }
        public void setconvert2PNG() { convert2PNG = true; }
        private void ConvertChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (convertChoose.Checked)
            {
                convert2PNG = true;
            }
            else
            {
                convert2PNG = false;
            }
        }

        public static bool chooseISOCheck { set; get; }
        public void setchooseISO() { chooseISOCheck = true; }
        private void chooseISO_CheckedChanged(object sender, EventArgs e)
        {
            if (chooseISO.Checked)
            {
                chooseISOCheck = true;
            }
            else
            {
                chooseISOCheck = false;
            }
        }

        public static bool monthFoldersCheck { set; get; }
        public void setMonthFolders() { monthFoldersCheck = true; }
        private void monthFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (monthFolders.Checked)
            {
                monthFoldersCheck = true;
            }
            else
            {
                monthFoldersCheck = false;
            }
        }

        public static DateTime startStrip { get; set; }
        public void setStartStrip() { startStrip = startDate.Value; }
        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            startStrip = startDate.Value;
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
            convertChoose.Enabled = false;
            chooseISO.Enabled = false;
            monthFolders.Enabled = false;
            startDate.Enabled = false;
            await dl.DownloadAll(outputDir);
            button2.Enabled = true;
            convertChoose.Enabled = true;
            chooseISO.Enabled = true;
            monthFolders.Enabled = true;
            startDate.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}