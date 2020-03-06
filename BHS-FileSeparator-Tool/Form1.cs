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

        private void RamEcoTrackBar_Scroll(object sender, EventArgs e)
        {
            string[] values = { "32 МБ", "64 МБ", "128 МБ", "256 МБ", "512 МБ", "1 ГБ"};
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

                Invoke(new Action(() => { separationProgress.Style = ProgressBarStyle.Continuous; }));

                FileStream file = new FileStream(fileToSeparation, FileMode.Open);
                long size = file.Length;

                int[] ramRangeBytes = { 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824};
                int ramRange = 0;
                Invoke(new Action(() => { ramRange = ramRangeBytes[ramEcoTrackBar.Value]; }));

                int[] sizeOfParts = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096};
                int[] sizeMultiplier = {1, 1024, 1048576, 1073741824};

                int sizeOfPart_local = 0;
                int sizeOfPartType_local = 0;
                Invoke(new Action(() => { sizeOfPart_local = sizeOfPart.SelectedIndex; sizeOfPartType_local = sizeOfPartType.SelectedIndex; }));

                long byteCount = sizeOfParts[sizeOfPart_local] * sizeMultiplier[sizeOfPartType_local];
                byte[] lastBytes = null;

                if (byteCount > ramRange)
                {
                    lastBytes = new byte[ramRange];
                }
                else
                {
                    if (byteCount < int.MaxValue) lastBytes = new byte[int.MaxValue];
                    else lastBytes = new byte[byteCount];
                }

                int partCount = (int)(size / byteCount);
                if (file.Length % byteCount != 0) partCount++;

                Invoke(new Action(() => { separationProgress.Value += 10; }));

                int onePartProcent = 75 / partCount;
                FileBuilder fileBuilder = new FileBuilder(openFileDialog.FileName.Split('\\')[0], file.Length, byteCount);
                string partName = partNameBox.Text.Replace("#", "{0}");

                for(int i = 0; i < partCount; i++)
                {
                    if (File.Exists(folderToSeparation + string.Format(partName, i + 1))) 
                        File.Delete(folderToSeparation + string.Format(partName, i + 1));
                }

                for (int i = 0; i < partCount; i++)
                {
                    Invoke(new Action(() => { helpBar.Text = "Шаг " + step + ": запись " + (i + 1) + " части..."; }));
                   
                    if (i + 1 == partCount)
                    {
                        long lastPartSize = (file.Length - ((partCount - 1) * byteCount));
                        Part lastPart = new Part(lastPartSize, string.Format(partName, i+1));
                        for (int j = 0; j < lastPartSize; j += lastBytes.Length)
                        {
                            if (j + lastBytes.Length > lastPartSize)
                            {
                                lastPartSize -= j;
                                lastBytes = new byte[lastPartSize];
                                if (lastPartSize > int.MaxValue)
                                {
                                    while(true){
                                        file.Read(lastBytes, 0, int.MaxValue);
                                        lastPartSize -= int.MaxValue;
                                        if(lastPartSize <= int.MaxValue)
                                        {
                                            file.Read(lastBytes, 0, (int) lastPartSize);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    file.Read(lastBytes, 0, (int) lastPartSize);
                                }
                                lastPart.WriteByte(folderToSeparation + string.Format(partName, i + 1), lastBytes);
                            }
                            else
                            {
                                file.Read(lastBytes, 0, lastBytes.Length);
                                lastPart.WriteByte(folderToSeparation + string.Format(partName, i + 1), lastBytes);
                            }
                        }
                        fileBuilder.AddPart(lastPart);
                        break;
                    }
                    Part part = new Part(byteCount, string.Format(partName, i+1));
                    for (int j = 0; j < byteCount; j += lastBytes.Length)
                    {
                        if (j + lastBytes.Length > byteCount)
                        {
                            byteCount -= j;
                            if (byteCount > int.MaxValue)
                            {
                                while (true)
                                {
                                    file.Read(lastBytes, 0, int.MaxValue);
                                    byteCount -= int.MaxValue;
                                    if (byteCount <= int.MaxValue)
                                    {
                                        file.Read(lastBytes, 0, (int)byteCount);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                file.Read(lastBytes, 0, (int) byteCount);
                            }
                            part.WriteByte(folderToSeparation + string.Format(partName, i + 1), lastBytes);
                        }
                        else
                        {
                            file.Read(lastBytes, 0, lastBytes.Length);
                            part.WriteByte(folderToSeparation + string.Format(partName, i + 1), lastBytes);
                        }
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

                Invoke(new Action(() => { separationProgress.Value += 10; }));
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

                Invoke(new Action(() => { separationProgress.Value = 100; }));
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
