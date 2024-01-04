namespace XsdToCsharp
{
    partial class NamespaceDialog
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
            label2 = new Label();
            edtXsd = new TextBox();
            edtCSharp = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 20);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 0;
            label1.Text = "Xsd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 48);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 1;
            label2.Text = "CSharp";
            // 
            // edtXsd
            // 
            edtXsd.Location = new Point(69, 16);
            edtXsd.Name = "edtXsd";
            edtXsd.Size = new Size(455, 23);
            edtXsd.TabIndex = 2;
            // 
            // edtCSharp
            // 
            edtCSharp.Location = new Point(69, 44);
            edtCSharp.Name = "edtCSharp";
            edtCSharp.Size = new Size(455, 23);
            edtCSharp.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(378, 106);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 32);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(459, 106);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 32);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NamespaceDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 140);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(edtCSharp);
            Controls.Add(edtXsd);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NamespaceDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xsd To CSharp Namespace";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox edtXsd;
        private TextBox edtCSharp;
        private Button btnOK;
        private Button btnCancel;
    }
}