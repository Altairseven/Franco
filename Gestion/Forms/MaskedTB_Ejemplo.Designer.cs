namespace Gestion
{
    partial class MaskedTB_Ejemplo
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
            this.mTextBox_Edit1 = new Gestion.Components.MTextBox_Edit();
            this.mTextBox_Edit2 = new Gestion.Components.MTextBox_Edit();
            this.mTextBox_Edit3 = new Gestion.Components.MTextBox_Edit();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mTextBox_Edit1
            // 
            this.mTextBox_Edit1.Location = new System.Drawing.Point(12, 120);
            this.mTextBox_Edit1.Name = "mTextBox_Edit1";
            this.mTextBox_Edit1.Size = new System.Drawing.Size(167, 20);
            this.mTextBox_Edit1.TabIndex = 0;
            // 
            // mTextBox_Edit2
            // 
            this.mTextBox_Edit2.Location = new System.Drawing.Point(13, 157);
            this.mTextBox_Edit2.Name = "mTextBox_Edit2";
            this.mTextBox_Edit2.Size = new System.Drawing.Size(167, 20);
            this.mTextBox_Edit2.TabIndex = 1;
            // 
            // mTextBox_Edit3
            // 
            this.mTextBox_Edit3.Location = new System.Drawing.Point(12, 192);
            this.mTextBox_Edit3.Name = "mTextBox_Edit3";
            this.mTextBox_Edit3.Size = new System.Drawing.Size(167, 20);
            this.mTextBox_Edit3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 96);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modificacion Propia hecha al maskedtextbox, mejorando la que hicmiso en clase, es" +
    "ta vez, es directamente una clase que hereda del maskedtextbox, y agrega la func" +
    "ionalidad del enter y la seleccion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MaskedTB_Ejemplo
            // 
            this.ClientSize = new System.Drawing.Size(192, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mTextBox_Edit3);
            this.Controls.Add(this.mTextBox_Edit2);
            this.Controls.Add(this.mTextBox_Edit1);
            this.Name = "MaskedTB_Ejemplo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Components.MTextBox_Edit mTextBox_Edit1;
        private Components.MTextBox_Edit mTextBox_Edit2;
        private Components.MTextBox_Edit mTextBox_Edit3;
        private System.Windows.Forms.Label label1;
    }
}

