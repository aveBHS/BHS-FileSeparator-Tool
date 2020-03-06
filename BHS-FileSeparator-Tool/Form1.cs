using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace BHS_FileSeparator_Tool
{
    public partial class Form1 : Form
    {
        string fileToSeparation = String.Empty;
        string folderToSeparation = String.Empty;
        public delegate void InvokeDelegate();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void RamEcoLabel_Click(object sender, EventArgs e)
        {

        }

        private void EnabledRamEco_CheckedChanged(object sender, EventArgs e)
        {
            ramEcoLabel.Enabled = enabledRamEco.Checked;
            ramEcoTrackBar.Enabled = enabledRamEco.Checked;
            label5.Enabled = enabledRamEco.Checked;
        }

        private void RamEcoTrackBar_Scroll(object sender, EventArgs e)
        {
            string[] values = { "32 МБ", "64 МБ", "128 МБ", "256 МБ", "512 МБ", "1 ГБ", "1.5 ГБ", "2 ГБ"};
            ramEcoLabel.Text = values[ramEcoTrackBar.Value];
        }

        private void BrowseFileUrl_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileToSeparation = openFileDialog.FileName;
                fileToSeparationUrlTextBox.Text = fileToSeparation;
                if (folderToSeparation == String.Empty)
                {
                    for (int i = 0; i < openFileDialog.FileName.Split('\\').Length - 1; i++)
                    {
                        folderToSeparation += openFileDialog.FileName.Split('\\')[i] + "\\";
                    }
                    folderToSeparation += "Parts\\";
                    folderToSeparationTextBox.Text = folderToSeparation;
                }
            }
        }

        private void BrowsreOutDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderToSeparation = folderBrowserDialog.SelectedPath;
                if (folderToSeparation[folderToSeparation.Length - 1] != '\\')
                    folderToSeparation += "\\";
                folderToSeparationTextBox.Text = folderToSeparation;
            }
        }

        private void StartSeparating_Click(object sender, EventArgs e)
        {
            sourceGroupBox.Enabled = false;
            outDirGroupBox.Enabled = false;
            checkGroupBox.Enabled = false;
            separationSettingsGroupBox.Enabled = false;
            ramEcoGroupBox.Enabled = false;
            startSeparating.Enabled = false;

            separationProgress.Style = ProgressBarStyle.Marquee;

            Thread separation = new Thread(new ThreadStart(Separation));
            separation.IsBackground = true;
            separation.Start();
            
        }
        public void UpdateGUI()
        {

        }
        private void Separation()
        {

            int step = 1;
            Invoke(new Action(() => { helpBar.Text = "Шаг " + step + ": подготовка..."; }));

            try
            {
                step++;

                separationProgress.Style = ProgressBarStyle.Continuous;

                FileStream file = new FileStream(fileToSeparation, FileMode.Open);
                int size = (int)file.Length;

                int[] sizeOfParts = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096 };
                int[] sizeMultiplier = { 1, 1024, 1048576, 1073741824 };

                int byteCount = sizeOfParts[sizeOfPart.SelectedIndex] * sizeMultiplier[sizeOfPartType.SelectedIndex];

                int partCount = (size / byteCount);
                if (file.Length % byteCount != 0) partCount++;

                separationProgress.Value += 10;

                int onePartProcent = 75 / partCount;
                byte[] lastByte = new byte[1];
                FileBuilder fileBuilder = new FileBuilder(openFileDialog.FileName.Split('\\')[0], file.Length, byteCount);
                string partName = partNameBox.Text.Replace("#", "{0}");

                for (int i = 0; i < partCount; i++)
                {
                    Invoke(new Action(() => { helpBar.Text = "Шаг " + step + ": запись " + (i + 1) + " части..."; }));
                   
                    if (!(i + 1 < partCount))
                    {
                        int lastPartSize = ((int)file.Length - ((partCount - 1) * byteCount));
                        Part lastPart = new Part(lastPartSize, string.Format(partName, i));
                        for (int j = 0; j < lastPartSize; j++)
                        {
                            file.Read(lastByte, 0, 1);
                            lastPart.WriteByte(folderToSeparation + string.Format(partName, i), lastByte);
                        }
                        fileBuilder.AddPart(lastPart);
                        break;
                    }
                    Part part = new Part(byteCount, string.Format(partName, i));
                    for (int j = 0; j < byteCount; j++)
                    {
                        file.Read(lastByte, 0, 1);
                        part.WriteByte(folderToSeparation + string.Format(partName, i), lastByte);
                    }
                    fileBuilder.AddPart(part);
                    Invoke(new Action(() => { separationProgress.Value += onePartProcent; }));
                }

                Invoke(new Action(() => { separationProgress.Value = 80; }));
                file.Close();

                if (enableMd5Check.Checked)
                {
                    helpBar.Text = "Шаг " + ++step + ": создание сборочного файла...";
                    fileBuilder.CalcMD5(folderToSeparation);
                }

                separationProgress.Value += 10;
                helpBar.Text = "Шаг " + step + ": создание сборочного файла...";

                XmlSerializer xml = new XmlSerializer(typeof(FileBuilder));
                StreamWriter builderFile = new StreamWriter(folderToSeparation + ".build");
                xml.Serialize(builderFile, fileBuilder);
                builderFile.Close();

                
                sourceGroupBox.Enabled = false;
                outDirGroupBox.Enabled = false;
                checkGroupBox.Enabled = false;
                separationSettingsGroupBox.Enabled = false;
                ramEcoGroupBox.Enabled = false;
                startSeparating.Enabled = false;

                separationProgress.Value = 100;
                helpBar.Text = "Готово!";

                MessageBox.Show("Готово!", "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                if (MessageBox.Show("Ошибка! Продолжить выполнение?\n" + error, "Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
    }
}
