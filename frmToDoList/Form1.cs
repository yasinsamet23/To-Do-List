using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;
using Microsoft.VisualBasic;

namespace frmToDoList
{
    public partial class frmToDoList : Form
    {
        private string filePath = "tasks.txt"; // G�revleri kaydedece�imiz dosya
        
        private SpeechRecognitionEngine recognizer;
        private bool isRecognizing = false;
        public frmToDoList()
        {
            InitializeSpeechRecognition();
            InitializeComponent();
            lstTasks.DrawMode = DrawMode.OwnerDrawFixed;  // Kendi �izim modumuzu se�iyoruz
            lstTasks.DrawItem += lstTasks_DrawItem;      // �izim olay�na abone oluyoruz
            this.FormClosing += frmToDoList_FormClosing;

            // Radio buton olaylar�na abone ol
            rdbtnlow.CheckedChanged += rdbtnlow_CheckedChanged;
            rdbtnmdm.CheckedChanged += rdbtnmdm_CheckedChanged;
            rdbtnhg.CheckedChanged += rdbtnhg_CheckedChanged;

            LoadTasks(); // Uygulama a��ld���nda g�revleri y�kle
        }
        private void InitializeSpeechRecognition()
        {
            try
            {
                // recognizer = new SpeechRecognitionEngine();
                recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));


                recognizer.SetInputToDefaultAudioDevice(); // Varsay�lan mikrofonu se�
                recognizer.LoadGrammarAsync(new DictationGrammar());
                recognizer.UpdateRecognizerSetting("AdaptationOn", 1);

                // Olaylar� ekle
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);
                recognizer.RecognizeCompleted += Recognizer_RecognizeCompleted; // Olay� tan�mlad�k
            }
            catch (Exception ex)
            {
                MessageBox.Show("Microphone initialization failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Tan�nan metni TextBox'a yazd�r
            txtTask.Text = e.Result.Text;
        }

        private void Recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error occurred: " + e.Error.Message);
            }
            else
            {
                isRecognizing = false; // Tan�ma i�lemi tamamland�
                recognizer.SetInputToNull(); // Mikrofonu s�f�rla (E�er gerekliyse)
            }
        }
        private void btnStartSpeech_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRecognizing)
                {
                    MessageBox.Show("Recognition is already active", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;  // E�er zaten tan�ma i�lemi aktifse, i�lemi durduruyoruz.
                }

                // Yeni bir ses tan�ma i�lemi ba�lat
                recognizer.SetInputToDefaultAudioDevice(); // Varsay�lan mikrofonu se�
                recognizer.RecognizeAsync(RecognizeMode.Multiple); // Tan�may� ba�lat
                isRecognizing = true; // Tan�ma i�lemi ba�lad���n� belirt
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Voice recognition failed to start: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopSpeech_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRecognizing)
                {
                    recognizer.RecognizeAsyncCancel(); // Tan�may� iptal et

                }
                else
                {
                    MessageBox.Show("Recognition is currently not active.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping recognition: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // TaskItem s�n�f�
        public class TaskItem
        {
            public string Text { get; set; }
            public string Priority { get; set; } // "Low", "Medium", "High"
            public bool IsPrioritySet { get; set; } // �ncelik sonradan ayarland� m�?
            public DateTime? DueDate { get; set; } // Tarih

            public TaskItem(string text, string priority = "None", bool isPrioritySet = false, DateTime? dueDate = null)
            {
                Text = text;
                Priority = priority;
                IsPrioritySet = isPrioritySet;
                DueDate = dueDate;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        // ListBox ��elerini �izme
        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();  // Arka plan� �iz

            // Se�ili ��e mi kontrol edelim
            if (e.Index >= 0)
            {
                TaskItem taskItem = (TaskItem)lstTasks.Items[e.Index];
                string taskText = taskItem.Text;

                // �nceli�e g�re renk se�imi
                Color taskColor = Color.Black;  // Varsay�lan renk 

                string prefix = ""; // Ba��na eklenecek i�aret


                if (taskItem.IsPrioritySet)
                {
                    if (taskItem.Priority == "Low")
                    {
                        taskColor = Color.Green;  // D���k �ncelik ye�il
                    }
                    else if (taskItem.Priority == "Medium")
                    {
                        taskColor = Color.Blue;  // Orta �ncelik mavi
                    }
                    else if (taskItem.Priority == "High")
                    {
                        taskColor = Color.Red;  // Y�ksek �ncelik k�rm�z�
                    }
                }

                // G�rev tarihi kontrol�
                if (taskItem.DueDate.HasValue)
                {
                    DateTime today = DateTime.Today;
                    DateTime dueDate = taskItem.DueDate.Value;

                    if (dueDate < today) // Tarihi ge�mi�se
                    {
                        taskColor = Color.Black;
                        prefix = "\u2716 "; // �arp� ekle
                    }
                    else if ((dueDate - today).TotalDays <= 7) // 1 hafta kald�ysa
                    {
                        taskColor = Color.FromArgb(255, 204, 0); // Koyu sar� renk
                    }
                }

                // G�revi �iz
                e.Graphics.DrawString(prefix + taskText, e.Font, new SolidBrush(taskColor), e.Bounds);
            }

            e.DrawFocusRectangle();  // Se�ili ��e i�in odaklanma kutusu �izin
        }

        // G�rev ekleme butonu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text)) return;

            // ListBox'a TaskItem ekle (ba�lang��ta �ncelik yok)
            lstTasks.Items.Add(new TaskItem(txtTask.Text));

            txtTask.Clear(); // TextBox'� temizle
        }

        // Radio buton de�i�ti�inde g�revin �nceli�ini g�ncelle
        private void UpdateSelectedTaskPriority()
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskItem taskItem = (TaskItem)lstTasks.SelectedItem;

                if (rdbtnlow.Checked)
                {
                    taskItem.Priority = "Low";
                }
                else if (rdbtnmdm.Checked)
                {
                    taskItem.Priority = "Medium";
                }
                else if (rdbtnhg.Checked)
                {
                    taskItem.Priority = "High";
                }

                taskItem.IsPrioritySet = true; // �ncelik ayarland�
                lstTasks.Invalidate(); // ListBox'� yeniden �iz
            }
        }

        // Radio buton de�i�iklikleri
        private void rdbtnlow_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedTaskPriority();
        }

        private void rdbtnmdm_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedTaskPriority();
        }

        private void rdbtnhg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedTaskPriority();
        }

        // G�rev d�zenleme butonu
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Edit_Panel edpanel = new Edit_Panel(this);
                edpanel.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an item");
            }
        }

        // G�rev silme butonu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                int selectedIndex = lstTasks.SelectedIndex;  // Se�ilen g�rev index'ini al
                lstTasks.Items.RemoveAt(selectedIndex); // ListBox'tan ��eyi sil
            }
        }

        // G�revi tamamland� olarak i�aretleme butonu
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskItem taskItem = (TaskItem)lstTasks.SelectedItem;
                if (!taskItem.Text.StartsWith("\u2714"))
                {
                    taskItem.Text = "\u2714  " + taskItem.Text;
                    lstTasks.Items[lstTasks.SelectedIndex] = taskItem;
                }
            }
        }

        // Form kapanmadan �nce g�revleri kaydet
        private void frmToDoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks();
        }

        // G�revleri dosyaya kaydet
        private void SaveTasks()
        {
            try
            {
                var tasks = lstTasks.Items.Cast<TaskItem>()
           .Select(t => $"{t.Text}|{t.Priority}|{t.IsPrioritySet}|{(t.DueDate.HasValue ? t.DueDate.Value.ToString("yyyy-MM-dd") : "None")}");
                File.WriteAllLines(filePath, tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Uygulama a��ld���nda g�revleri y�kle
        private void LoadTasks()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] tasks = File.ReadAllLines(filePath);
                    foreach (var task in tasks)
                    {
                        string[] parts = task.Split('|');
                        if (parts.Length == 4)
                        {
                            DateTime? dueDate = parts[3] != "None" ? DateTime.Parse(parts[3]) : (DateTime?)null;
                            TaskItem taskItem = new TaskItem(parts[0], parts[1], bool.Parse(parts[2]), dueDate);

                            // Tarih kontrol� ve g�ncelleme
                            if (taskItem.DueDate.HasValue)
                            {
                                DateTime today = DateTime.Today;
                                DateTime dueDateValue = taskItem.DueDate.Value;
                                if (dueDateValue < today) // Tarihi ge�mi�se
                                {
                                    taskItem.Text = "\u2716 " + taskItem.Text; // �arp� i�areti ekle
                                }
                            }

                            lstTasks.Items.Add(taskItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while loading tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Di�er olaylar
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lstTasks.Items.Count != 0)
            {
                lblTotalTasks.Text = "Total Tasks: " + lstTasks.Items.Count;
            }

        }

        private void chcboxdartmode_CheckedChanged(object sender, EventArgs e)
        {
            if (chcboxdartmode.Checked)
            {
                // Dark mode renkleri
                this.BackColor = Color.FromArgb(30, 30, 30); // Koyu arka plan
                this.ForeColor = Color.White; // Beyaz yaz�
                lblTitle.BackColor = Color.FromArgb(30, 30, 30); // Koyu arka plan
                lblTitle.ForeColor = Color.White; // Beyaz yaz�
                txtTask.BackColor = Color.FromArgb(50, 50, 50); // Koyu gri TextBox arka plan�
                txtTask.ForeColor = Color.White; // Beyaz yaz� rengi
                lstTasks.BackColor = Color.FromArgb(54, 69, 79); // K�m�r gri
                btnEdit.BackColor = Color.FromArgb(30, 30, 30);
                btnDelete.BackColor = Color.FromArgb(30, 30, 30);
                btnMarkComplete.BackColor = Color.FromArgb(30, 30, 30);
                btnAdd.BackColor = Color.FromArgb(30, 30, 30);
                btnStartSpeech.BackColor=Color.Black;
                btnStartSpeech.ForeColor = Color.White;
                btnStopSpeech.BackColor = Color.Black;
                btnStopSpeech.ForeColor = Color.White;
                btncst.BackColor=Color.Black;
                btncst.ForeColor = Color.White;
                btndft.BackColor=Color.Black;
                btndft.ForeColor = Color.White;
                btnSetDate.BackColor = Color.Black;
                btnSetDate.ForeColor = Color.White;

                
            }
            else
            {
                this.BackColor = Color.LightSteelBlue;
                this.ForeColor = SystemColors.ControlText;
                lblTitle.BackColor = Color.LightSteelBlue;
                lblTitle.ForeColor = SystemColors.ControlText;
                txtTask.BackColor = Color.White;
                txtTask.ForeColor = SystemColors.WindowText;
                lstTasks.BackColor = SystemColors.Window;
                lstTasks.ForeColor = Color.Black;
                btnEdit.BackColor = Color.White;
                btnEdit.ForeColor = Color.LightBlue;
                btnDelete.BackColor = Color.White;
                btnDelete.ForeColor = Color.LightCoral;
                btnMarkComplete.BackColor = Color.White;
                btnMarkComplete.ForeColor = Color.Orange;
                btnAdd.BackColor = Color.White;
                btnAdd.ForeColor = Color.LightGreen;
                btnStartSpeech.BackColor = Color.White;
                btnStartSpeech.ForeColor = SystemColors.ControlText;
                btnStopSpeech.BackColor = Color.White;
                btnStopSpeech.ForeColor = SystemColors.ControlText;
                btncst.BackColor = Color.White;
                btncst.ForeColor = SystemColors.ControlText;
                btndft.BackColor = Color.White;
                btndft.ForeColor = SystemColors.ControlText;
                btnSetDate.BackColor = Color.White;
                btnSetDate.ForeColor = SystemColors.ControlText;





            }
        }

        private void frmToDoList_Load(object sender, EventArgs e)
        {

        }

        private void btncst_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void btndft_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSteelBlue;
            this.ForeColor = SystemColors.ControlText;
        }

        private void btnSetDate_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                TaskItem taskItem = (TaskItem)lstTasks.SelectedItem;
                taskItem.DueDate = dtpDueDate.Value; // Tarihi ayarla
                lstTasks.Invalidate(); // ListBox'� g�ncelle
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lstTasks.Invalidate();  // ListBox'� yeniden �iz
        }
    }
}