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

		struct OptionalDownload
		{
			public string packageName, folderName;
			public OptionalDownload(string folder, string package)
			{
				this.folderName = folder;
				this.packageName = package;
			}
		}
		private List<OptionalDownload> optionaldownloads;
		private int NumberOfDownloadsFinished = 0;

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
			Properties.Settings.Default["DCSRootFolder"] = pathText.Text;
			Properties.Settings.Default.Save();

			optionaldownloads = new List<OptionalDownload>();
			if (a10cKneeboardCheck.Checked)
				optionaldownloads.Add(new OptionalDownload("A-10C", "A10C-Kneeboard"));
			if (m2000KneeboardCheck.Checked)
				optionaldownloads.Add(new OptionalDownload("M-2000C", "M2000-Kneeboard"));
			if (f18cKneeboardCheck.Checked)
				optionaldownloads.Add(new OptionalDownload("F/A-18", "F/A-18C-Kneeboard"));

			string versionNum = GetLastestVersionNumber();
			logTextBox.AppendText("Downloading Version: " + versionNum + "\n");
			//Download lastest version from github repository
			MakeDownload(versionNum);
			//prepareOptionalDownloads();
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
			string download_url = "https://github.com/byjokese/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/SkinPack_1.0.0.zip";
			Thread thread = new Thread(() => {
				System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
				WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Anything");
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				Uri serverUri = new Uri("https://github.com");
				Uri relativeUri = new Uri("byjokese/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/SkinPack_"+ versionNumber + ".zip", UriKind.Relative);
				Uri fullUri = new Uri(serverUri, relativeUri);
				try
				{
					webClient.DownloadFileAsync(fullUri, @"" + pathText.Text + "\\Bazar\\Liveries\\Temp.zip");
				}
					catch (WebException e)
				{
					logTextBox.AppendText(e.ToString());
					logTextBox.AppendText("Download failed. Skipping Skin Download...\n");

				}
			});
			thread.Start();
		}

		private void MakeOptionalDownload(string versionNumber, OptionalDownload optionalPackage)
		{
			/*this.BeginInvoke((MethodInvoker)delegate
			{
				logTextBox.AppendText("Downloading " + optionalPackage.folderName + " Kneeboard...\n");
			});*/
			string download_url_a10c = "https://github.com/byjokese/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/" + optionalPackage.packageName + ".zip";
			Thread thread = new Thread(() => {
				System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
				WebClient webClient = new WebClient();
				webClient.Headers.Add("user-agent", "Anything");
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadOptionalFilesCompleted);
				Uri serverUri = new Uri("https://github.com");
				Uri relativeUri = new Uri("byjokese/Frontside-Gaming-DCS-Skin-Pack-and-Updater/releases/download/v" + versionNumber + "/" + optionalPackage.packageName + ".zip", UriKind.Relative);
				Uri fullUri = new Uri(serverUri, relativeUri);
				try
				{
					webClient.DownloadFileAsync(fullUri, @"C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\" + optionalPackage.folderName + "\\Temp.zip");
				}
				catch (WebException e)
				{
					this.BeginInvoke((MethodInvoker)delegate
					{
						logTextBox.AppendText(e.ToString());
						logTextBox.AppendText(optionalPackage.folderName + "Download failed. Skipping...\n");
					});
				}
			});
			thread.Start();
			//threadA10.Join();
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				double bytesIn = double.Parse(e.BytesReceived.ToString());
				double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
				double percentage = bytesIn / totalBytes * 100;
				ProgressText_lbl.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive + " Bytes";
				progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
			});
		}
		void client_DownloadOptionalFilesCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				NumberOfDownloadsFinished++;
				if(optionaldownloads.Count == NumberOfDownloadsFinished)
				{
					logTextBox.AppendText("Optional Packages Downloads Finished.\n");
					ExtractFilesAndCopy();
				}
			});
		}

		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate {
				logTextBox.AppendText("Download Completed\n");
				//Reset Progress Bar and Download Optionals
				prepareOptionalDownloads();
			});
		}

		private void prepareOptionalDownloads()
		{
			logTextBox.AppendText("Downloading Optional Packages\n");
			NumberOfDownloadsFinished = 0;
			//int currentDownload = 0;
			if (optionaldownloads.Count > 0)
			{
				foreach (OptionalDownload optionalPackage in optionaldownloads)
				{
					string versionNumber = GetLastestVersionNumber();
					MakeOptionalDownload(versionNumber, optionalPackage);
				}
				/*string versionNumber = GetLastestVersionNumber();
				MakeOptionalDownload(versionNumber, optionaldownloads[0]);*/
			}
			else
			{
				ExtractFilesAndCopy();
			}
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

			foreach (OptionalDownload optionalPackage in optionaldownloads) {
				//Extrat A-10C Files
				string path = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\" + optionalPackage.folderName;
				if (!Directory.Exists(path))
				{
					// Try to create the directory.
					DirectoryInfo di = Directory.CreateDirectory(path);
				}
				ZipStorer zipA10 = ZipStorer.Open("C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\" + optionalPackage.folderName + "\\Temp.zip", FileAccess.Read);
				List<ZipStorer.ZipFileEntry> dirA10 = zipA10.ReadCentralDir();
				// Look for the desired file
				int fileNumberA10 = 0;
				progressBar1.Value = 0;
				foreach (ZipStorer.ZipFileEntry entry in dirA10)
				{
					//Deleting the first folder for extraction
					string fileName = entry.FilenameInZip;
					logTextBox.AppendText("Extracting: " + fileName + "\n");
					zipA10.ExtractFile(entry, "C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\" + optionalPackage.folderName + "\\" + fileName);
					progressBar1.Value = ((fileNumberA10++ / dirA10.Count()) * 100);
				}
				zipA10.Close();
				logTextBox.AppendText(optionalPackage.packageName + " Optional Files Extracted\n");
				logTextBox.AppendText("Deleting "+ optionalPackage.packageName + " Optional Temporal Files...\n");
				File.Delete("C:\\Users\\" + Environment.UserName + "\\Saved Games\\DCS\\Kneeboard\\" + optionalPackage.folderName + "\\Temp.zip");
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

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}
	}
}
