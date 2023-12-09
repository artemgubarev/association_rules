namespace association_rules.demo
{
    partial class Form1
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
            this.association_rules_user_control1 = new association_rules.core.AprioriUserControl();
            this.SuspendLayout();
            // 
            // association_rules_user_control1
            // 
            this.association_rules_user_control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.association_rules_user_control1.Location = new System.Drawing.Point(0, 0);
            this.association_rules_user_control1.Name = "association_rules_user_control1";
            this.association_rules_user_control1.Size = new System.Drawing.Size(881, 529);
            this.association_rules_user_control1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 529);
            this.Controls.Add(this.association_rules_user_control1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ассоциативные правила";
            this.ResumeLayout(false);

        }

        #endregion

        private core.AprioriUserControl association_rules_user_control1;
    }
}

