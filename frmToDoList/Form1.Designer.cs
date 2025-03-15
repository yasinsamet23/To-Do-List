namespace frmToDoList
{
    partial class frmToDoList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            txtTask = new TextBox();
            btnAdd = new Button();
            lstTasks = new ListBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnMarkComplete = new Button();
            lblTotalTasks = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            rdbtnlow = new RadioButton();
            rdbtnhg = new RadioButton();
            rdbtnmdm = new RadioButton();
            chcboxdartmode = new CheckBox();
            btncst = new Button();
            colorDialog1 = new ColorDialog();
            btndft = new Button();
            btnStartSpeech = new Button();
            btnStopSpeech = new Button();
            dtpDueDate = new DateTimePicker();
            btnSetDate = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.LightSteelBlue;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = SystemColors.WindowText;
            lblTitle.Location = new Point(125, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "To-Do List ";
            // 
            // txtTask
            // 
            txtTask.BackColor = Color.White;
            txtTask.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTask.Location = new Point(20, 50);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(320, 34);
            txtTask.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnAdd.ForeColor = Color.LightGreen;
            btnAdd.Location = new Point(350, 50);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Task";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstTasks
            // 
            lstTasks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lstTasks.ForeColor = Color.Black;
            lstTasks.FormattingEnabled = true;
            lstTasks.IntegralHeight = false;
            lstTasks.ItemHeight = 28;
            lstTasks.Location = new Point(20, 90);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(450, 200);
            lstTasks.TabIndex = 3;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEdit.ForeColor = Color.LightBlue;
            btnEdit.Location = new Point(12, 300);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(140, 30);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit Task";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDelete.ForeColor = Color.LightCoral;
            btnDelete.Location = new Point(158, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Task";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnMarkComplete
            // 
            btnMarkComplete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMarkComplete.ForeColor = Color.Orange;
            btnMarkComplete.Location = new Point(304, 300);
            btnMarkComplete.Name = "btnMarkComplete";
            btnMarkComplete.Size = new Size(180, 30);
            btnMarkComplete.TabIndex = 6;
            btnMarkComplete.Text = "Mark Completed\r\n";
            btnMarkComplete.UseVisualStyleBackColor = true;
            btnMarkComplete.Click += btnMarkComplete_Click;
            // 
            // lblTotalTasks
            // 
            lblTotalTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTotalTasks.ForeColor = Color.DarkBlue;
            lblTotalTasks.Location = new Point(20, 340);
            lblTotalTasks.Name = "lblTotalTasks";
            lblTotalTasks.Size = new Size(250, 30);
            lblTotalTasks.TabIndex = 7;
            lblTotalTasks.Text = "Total Tasks: 0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // rdbtnlow
            // 
            rdbtnlow.AutoSize = true;
            rdbtnlow.Location = new Point(181, 346);
            rdbtnlow.Name = "rdbtnlow";
            rdbtnlow.Size = new Size(108, 24);
            rdbtnlow.TabIndex = 8;
            rdbtnlow.TabStop = true;
            rdbtnlow.Text = "Low Priority";
            rdbtnlow.UseVisualStyleBackColor = true;
            rdbtnlow.CheckedChanged += rdbtnlow_CheckedChanged;
            // 
            // rdbtnhg
            // 
            rdbtnhg.AutoSize = true;
            rdbtnhg.Location = new Point(249, 376);
            rdbtnhg.Name = "rdbtnhg";
            rdbtnhg.Size = new Size(113, 24);
            rdbtnhg.TabIndex = 9;
            rdbtnhg.TabStop = true;
            rdbtnhg.Text = "High Priority";
            rdbtnhg.UseVisualStyleBackColor = true;
            // 
            // rdbtnmdm
            // 
            rdbtnmdm.AutoSize = true;
            rdbtnmdm.Location = new Point(321, 346);
            rdbtnmdm.Name = "rdbtnmdm";
            rdbtnmdm.Size = new Size(136, 24);
            rdbtnmdm.TabIndex = 10;
            rdbtnmdm.TabStop = true;
            rdbtnmdm.Text = "Medium Priority";
            rdbtnmdm.UseVisualStyleBackColor = true;
            // 
            // chcboxdartmode
            // 
            chcboxdartmode.AutoSize = true;
            chcboxdartmode.Location = new Point(661, 27);
            chcboxdartmode.Name = "chcboxdartmode";
            chcboxdartmode.Size = new Size(103, 24);
            chcboxdartmode.TabIndex = 11;
            chcboxdartmode.Text = "Dart Mode";
            chcboxdartmode.UseVisualStyleBackColor = true;
            chcboxdartmode.CheckedChanged += chcboxdartmode_CheckedChanged;
            // 
            // btncst
            // 
            btncst.Location = new Point(661, 75);
            btncst.Name = "btncst";
            btncst.Size = new Size(118, 29);
            btncst.TabIndex = 12;
            btncst.Text = "Customization ";
            btncst.UseVisualStyleBackColor = true;
            btncst.Click += btncst_Click;
            // 
            // btndft
            // 
            btndft.Location = new Point(661, 119);
            btndft.Name = "btndft";
            btndft.Size = new Size(117, 29);
            btndft.TabIndex = 13;
            btndft.Text = "Default Color";
            btndft.UseVisualStyleBackColor = true;
            btndft.Click += btndft_Click;
            // 
            // btnStartSpeech
            // 
            btnStartSpeech.Location = new Point(487, 90);
            btnStartSpeech.Name = "btnStartSpeech";
            btnStartSpeech.Size = new Size(113, 31);
            btnStartSpeech.TabIndex = 14;
            btnStartSpeech.Text = "Start Speech";
            btnStartSpeech.UseVisualStyleBackColor = true;
            btnStartSpeech.Click += btnStartSpeech_Click;
            // 
            // btnStopSpeech
            // 
            btnStopSpeech.Location = new Point(487, 144);
            btnStopSpeech.Name = "btnStopSpeech";
            btnStopSpeech.Size = new Size(113, 33);
            btnStopSpeech.TabIndex = 15;
            btnStopSpeech.Text = "Finish Speech";
            btnStopSpeech.UseVisualStyleBackColor = true;
            btnStopSpeech.Click += btnStopSpeech_Click;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(487, 221);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(250, 27);
            dtpDueDate.TabIndex = 16;
            // 
            // btnSetDate
            // 
            btnSetDate.Location = new Point(542, 270);
            btnSetDate.Name = "btnSetDate";
            btnSetDate.Size = new Size(94, 29);
            btnSetDate.TabIndex = 17;
            btnSetDate.Text = "Set Date";
            btnSetDate.UseVisualStyleBackColor = true;
            btnSetDate.Click += btnSetDate_Click;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 1800000;
            timer2.Tick += timer2_Tick;
            // 
            // frmToDoList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(791, 403);
            Controls.Add(btnSetDate);
            Controls.Add(dtpDueDate);
            Controls.Add(btnStopSpeech);
            Controls.Add(btnStartSpeech);
            Controls.Add(btndft);
            Controls.Add(btncst);
            Controls.Add(chcboxdartmode);
            Controls.Add(rdbtnmdm);
            Controls.Add(rdbtnhg);
            Controls.Add(rdbtnlow);
            Controls.Add(lblTotalTasks);
            Controls.Add(btnMarkComplete);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lstTasks);
            Controls.Add(btnAdd);
            Controls.Add(txtTask);
            Controls.Add(lblTitle);
            Name = "frmToDoList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "To-Do List Application";
            Load += frmToDoList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTask;
        private Button btnAdd;
        public ListBox lstTasks;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnMarkComplete;
        private Label lblTotalTasks;
        private System.Windows.Forms.Timer timer1;
        private RadioButton rdbtnlow;
        private RadioButton rdbtnhg;
        private RadioButton rdbtnmdm;
        private CheckBox chcboxdartmode;
        private Button btncst;
        private ColorDialog colorDialog1;
        private Button btndft;
        private Button btnStartSpeech;
        private Button btnStopSpeech;
        private DateTimePicker dtpDueDate;
        private Button btnSetDate;
        private System.Windows.Forms.Timer timer2;
    }
}
