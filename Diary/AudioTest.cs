using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Diary
{
    public partial class AudioTest : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");

        string FileName;
        string outputFolder = "d:\\audio";
        private WaveIn waveIn = null;
        private WaveFileWriter waveWriter = null;
        private WaveFileReader waveReader = null;
        private DirectSoundOut output = null;
        Stopwatch Count_Down = new Stopwatch();

        public AudioTest()
        {
            InitializeComponent();
            btnStop.Enabled = false;
            AddtoCombo();
            lblTimer.Text = "00:00:00";
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Count_Down.Restart();

            btnStop.Enabled = true;
            btnStart.Enabled = false;

            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(8000, 1);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordStopped);

            FileName = string.Format(@"Test{0:yyyy-MM-dd hh-mm}.wav", DateTime.Now);
            waveWriter = new WaveFileWriter(Path.Combine(outputFolder, FileName), waveIn.WaveFormat);
            waveIn.StartRecording();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Count_Down.Stop();

            btnStop.Enabled = false;
            btnStart.Enabled = true;
            waveIn.StopRecording();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            CleanOutput_Reader();
            waveReader = new WaveFileReader(Path.Combine(outputFolder, listBox1.SelectedItem.ToString()));
            output = new DirectSoundOut();
            output.Init(new WaveChannel32(waveReader));
            output.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == PlaybackState.Playing)
                {
                    output.Pause();
                }
                else
                {
                    output.Play();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem!= null)
            {
                string delName = listBox1.SelectedItem.ToString();
                File.Delete(Path.Combine(outputFolder, delName));
                listBox1.Items.Remove(listBox1.SelectedItem);

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
            }

        }

        private void waveIn_RecordStopped(object sender, StoppedEventArgs e)
        {
            cleanIn_Writer();

            int newRecording = listBox1.Items.Add(FileName);
            listBox1.SelectedIndex = newRecording;
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if(waveIn != null)
            {
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();
            }
        }

        private void cleanIn_Writer()
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }

            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

        private void CleanOutput_Reader()
        {
            if (output != null)
            {
                output.Dispose();
                output = null;
            }
            if (waveReader != null)
            {
                waveReader.Dispose();
                waveReader = null;
            }
        }

        private void AddtoCombo()
        {
            listBox1.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(outputFolder);
            if (Directory.EnumerateFileSystemEntries(outputFolder).Any() == true)
            {
                FileInfo[] file = dinfo.GetFiles("*.wav");
                foreach (FileInfo f in file)
                {
                    listBox1.Items.Add(f);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "00:00:00";
            TimeSpan elapsed = Count_Down.Elapsed;
            lblTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string delName = listBox1.SelectedItem.ToString();
            MediaPlayer.URL = Path.Combine(outputFolder,delName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
