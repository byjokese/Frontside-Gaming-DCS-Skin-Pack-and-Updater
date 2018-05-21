using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FSG_DCS_Skin_Installer_Updater
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private bool downloadsCompleted = false;

		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
			if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				pathText.Text = folderBrowser.SelectedPath;
			}
		}

		private void UpdateBtn_Click(object sender, EventArgs e)
		{
			pathText.ReadOnly = true;
			string versionNum = GetLastestVersionNumber();
			logTextBox.AppendText("Downloading Version: " + versionNum + "\n");
			//Download lastest version from github repository
			MakeDownload(versionNum);
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			if (System.Windows.Forms.Application.MessageLoop)
			{
				// WinForms app
				System.Windows.Forms.Application.Exit();
			}
			else
			{
				// Console app
				System.Environment.Exit(1);
			}
		}

		private string GetLastestVersionNumber()
		{
			string m_strFilePath = "https://raw.githubusercontent.com/FrontsideGaming/Frontside-Gaming-DCS-Skin-Pack-and-Updater/master/version.xml";
			XmlDocument versionsXMLDoc = new XmlDocument();
			versionsXMLDoc.Load(m_strFilePath);

			string versionNumber = "";

			XmlNodeList versions = versionsXMLDoc.SelectNodes("/versions");
			foreach (XmlNode version in versions)
			{
				versionNumber = version.SelectSingleNode("lastest").InnerText;
			}
			return versionNumber;
		}

		private void MakeDownload(string versionNumber)
		{
			string download_url = "https://github.com/FrontsideGaming/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/SkinPack_1.0.0.zip";
			Thread thread = new Thread(() => {
				System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
				WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Anything");
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				Uri serverUri = new Uri("https://github.com");
				Uri relativeUri = new Uri("FrontsideGaming/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/SkinPack_"+ versionNumber + ".zip", UriKind.Relative);
				Uri fullUri = new Uri(serverUri, relativeUri);
				webClient.DownloadFileAsync(fullUri, @"" + pathText.Text + "\\Bazar\\Liveries\\Temp.zip");
			});
			thread.Start();
		}

		private void MakeOptionalDownloads(string versionNumber)
		{
			if (a10cKneeboardCheck.Checked)
			{
				logTextBox.AppendText("Downloading A-10C Kneeboard...\n");
				string download_url_a10c = "https://github.com/FrontsideGaming/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/A10C-Kneeboard.zip";
				Thread threadA10 = new Thread(() => {
					System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
					WebClient webClientA10 = new WebClient();
					webClientA10.Headers.Add("user-agent", "Anything");
					webClientA10.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
					webClientA10.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadOptionalFilesCompleted);
					Uri serverUri = new Uri("https://github.com");
					Uri relativeUri = new Uri("FrontsideGaming/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/A10C-Kneeboard.zip", UriKind.Relative);
					Uri fullUri = new Uri(serverUri, relativeUri);
					webClientA10.DownloadFileAsync(fullUri, @"" + "C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\A-10C\\Temp.zip");
				});
				threadA10.Start();
			}
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				double bytesIn = double.Parse(e.BytesReceived.ToString());
				double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
				double percentage = bytesIn / totalBytes * 100;
				//logTextBox.AppendText("Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive);
				progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
			});
		}
		void client_DownloadOptionalFilesCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				logTextBox.AppendText("Optional Packages Downloads Finished.\n");
				ExtractFilesAndCopy();
			});
		}

		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				logTextBox.AppendText("Download Completed\n");
				//Reset Progress Bar and Download Optionals
				if (a10cKneeboardCheck.Checked){
					logTextBox.AppendText("Downloading Optional Packages\n");
					MakeOptionalDownloads(GetLastestVersionNumber());
				}else{
					downloadsCompleted = true;
				}
				//Extract the files and copy to DCS Directory.
				if (downloadsCompleted)
					ExtractFilesAndCopy();
			});
		}

		private void ExtractFilesAndCopy()
		{
			logTextBox.AppendText("Extracting Files\n");
			ZipStorer zip = ZipStorer.Open(@"" + pathText.Text + "\\Bazar\\Liveries\\Temp.zip", FileAccess.Read);
			List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();
			// Look for the desired file
			int fileNumber = 0;
			progressBar1.Value = 0;
			foreach (ZipStorer.ZipFileEntry entry in dir)
			{
				//Deleting the first folder for extraction
				string fileName = entry.FilenameInZip.Substring(10, entry.FilenameInZip.Length - 10);
				logTextBox.AppendText("Extracting: " + fileName + "\n");
				zip.ExtractFile(entry, pathText.Text + "\\Bazar\\Liveries\\" + fileName);
				progressBar1.Value = ((fileNumber++ / dir.Count()) * 100);
			}
			zip.Close();
			logTextBox.AppendText("All Files Extracted\n");
			logTextBox.AppendText("Deleting Temporal Files...\n");
			File.Delete("" + pathText.Text + "\\Bazar\\Liveries\\Temp.zip");

			if (a10cKneeboardCheck.Checked){
				//Extrat A-10C Files
				ZipStorer zipA10 = ZipStorer.Open(@"" + "C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\A-10C\\Temp.zip", FileAccess.Read);
				List<ZipStorer.ZipFileEntry> dirA10 = zipA10.ReadCentralDir();
				// Look for the desired file
				int fileNumberA10 = 0;
				progressBar1.Value = 0;
				foreach (ZipStorer.ZipFileEntry entry in dirA10)
				{
					//Deleting the first folder for extraction
					string fileName = entry.FilenameInZip;
					logTextBox.AppendText("Extracting: " + fileName + "\n");
					zipA10.ExtractFile(entry, "C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\A-10C\\" + fileName);
					progressBar1.Value = ((fileNumberA10++ / dirA10.Count()) * 100);
				}
				zipA10.Close();
				logTextBox.AppendText("All Optional Files Extracted\n");
				logTextBox.AppendText("Deleting Optional Temporal Files...\n");
				File.Delete("C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\A-10C\\Temp.zip");
			}
			logTextBox.AppendText("Update/Install Proccess COMPLETED\n");
			pathText.ReadOnly = false;
			System.Media.SystemSounds.Hand.Play();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
