using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GKMoveFolders
{
	public partial class frmMain : Form
	{

		bool selectFolderDropBox = false;
		bool selectFolderOneDrive = false;

		public frmMain()
		{
			InitializeComponent();



			lblDesktop.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			lblDocuments.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			//lblDownloads.Text = Environment.GetFolderPath(Environment.SpecialFolder.Download);
			var pathDownload = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
			lblDownloads.Text = pathDownload;
			lblMusic.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
			lblPictures.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			lblVideo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
			
			try
			{
				var pathDropBox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dropbox\\info.json");

				if (File.Exists(pathDropBox))
				{
					string stpath = File.ReadAllText(pathDropBox);
					lblDropbox.Text = "Please browse for the Location you want to store your folders in!";
					btnDropbox.Visible = true;
				}
			}

			catch (Exception)

			{

				lblDropbox.Text = "There is no Dropbox Location!";

			}

			try

			{
				var pathOneDrive = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\OneDrive\\settings\\Business1");

				if (Directory.Exists(pathOneDrive))
				{
					lblOneDrive.Text = "Please browse for the Location you want to store your folders in!";
					btnOneDrive.Visible = true;
					//var pathOneDrive = Path.Combine(Environment.GetFolderPath(Environment.GetFolderPath(), "Dropbox\\info.json");
				}
			}

			catch (Exception)

			{

				lblOneDrive.Text = "There is no OneDrive Location!";

			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnDropbox_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			//fbd.RootFolder = Environment.SpecialFolder.UserProfile;

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				lblDropbox.Text = fbd.SelectedPath;
				selectFolderDropBox = true;
				rdoDropbox.Checked = true;
				rdoDropbox.Select();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			//fbd.RootFolder = Environment.SpecialFolder.UserProfile;

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				lblOneDrive.Text = fbd.SelectedPath;
				selectFolderOneDrive = true;
				rdoOneDrive.Checked = true;
				rdoOneDrive.Select();
			}
		}

		private void btnMove_Click(object sender, EventArgs e)
		{
			if (!rdoDropbox.Checked && !rdoOneDrive.Checked)
			{
				MessageBox.Show("Please Choose a path to either Dropbox or OneDrive");
			}

			if (rdoDropbox.Checked || selectFolderDropBox)
			{
				MessageBox.Show("Please Select a DropBox Location!");
				rdoDropbox.Checked = false;
			}

			if (rdoOneDrive.Checked || selectFolderOneDrive)
			{
				MessageBox.Show("Please Select a OneDrive Location!");
				rdoOneDrive.Checked = false;
			}
		}
	}
}
