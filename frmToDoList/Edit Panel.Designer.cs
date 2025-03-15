namespace frmToDoList
{
    partial class Edit_Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            renametextbox = new TextBox();
            renamebutton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(0, 35);
            label1.Name = "label1";
            label1.Size = new Size(207, 38);
            label1.TabIndex = 0;
            label1.Text = "Rename to-do :";
            label1.Click += label1_Click;
            // 
            // renametextbox
            // 
            renametextbox.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            renametextbox.Location = new Point(213, 46);
            renametextbox.Name = "renametextbox";
            renametextbox.Size = new Size(190, 43);
            renametextbox.TabIndex = 1;
            // 
            // renamebutton
            // 
            renamebutton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            renamebutton.Location = new Point(33, 93);
            renamebutton.Name = "renamebutton";
            renamebutton.Size = new Size(92, 48);
            renamebutton.TabIndex = 2;
            renamebutton.Text = "Rename";
            renamebutton.UseVisualStyleBackColor = true;
            renamebutton.Click += button1_Click;
            // 
            // Edit_Panel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 153);
            Controls.Add(renamebutton);
            Controls.Add(renametextbox);
            Controls.Add(label1);
            Name = "Edit_Panel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit_Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox renametextbox;
        private Button renamebutton;
    }
}