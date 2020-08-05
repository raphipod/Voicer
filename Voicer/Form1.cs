using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Voicer
{
    public partial class Form1 : Form
    {
        public static SpeechSynthesizer ss = new SpeechSynthesizer();
        public Dictionary<string, string> voiceDict = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();

            SpeechSynthesizer ss = new SpeechSynthesizer();

            foreach (InstalledVoice voice in ss.GetInstalledVoices())
            {
                voiceDict.Add(voice.VoiceInfo.Name, voice.VoiceInfo.Description);
            }
            

            foreach (var voiceInfoPair in voiceDict)
            {
                voiceBox.Items.Add(voiceInfoPair.Value);
            }

            voiceBox.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedVoice = voiceBox.SelectedItem.ToString();
            string voiceName = voiceDict.FirstOrDefault(x => x.Value == selectedVoice).Key;
            ss.SelectVoice(voiceName);
            ss.SpeakAsync(textBox1.Text.ToString());
        }
    }
}
