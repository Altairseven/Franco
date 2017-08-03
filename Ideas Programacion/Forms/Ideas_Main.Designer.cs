namespace Ideas_Programacion {
    partial class Ideas_Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Numeros");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Texto");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Redes");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Aplicaciones Para Empresas");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Procesos e Hilos");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Web");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Archivos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Bases de Dato");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Graficos y Multimedia");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Juegos");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Sin Acomodar");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Numeros";
            treeNode1.ToolTipText = "Programas Usando Numeros";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Texto";
            treeNode2.ToolTipText = "Programas Usando Texto";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Redes";
            treeNode3.ToolTipText = "Programas utilizando funciones de redes";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Aplicaciones Para Empresas";
            treeNode4.ToolTipText = "Programas que podrian servir para empresas o negocios chichos";
            treeNode5.Name = "Node4";
            treeNode5.Text = "Procesos e Hilos";
            treeNode5.ToolTipText = "Programas que trabajan usando mas de un hilo de proceso";
            treeNode6.Name = "Node5";
            treeNode6.Text = "Web";
            treeNode6.ToolTipText = "Posibles Aplicaciones Web";
            treeNode7.Name = "Node6";
            treeNode7.Text = "Archivos";
            treeNode7.ToolTipText = "Programas que de una manera u otra manejan Archivos";
            treeNode8.Name = "Node7";
            treeNode8.Text = "Bases de Dato";
            treeNode8.ToolTipText = "Programas que aplican uso de de Bases de datos de cualquier tipo";
            treeNode9.Name = "Node8";
            treeNode9.Text = "Graficos y Multimedia";
            treeNode9.ToolTipText = "Programas que trabajan con imagenes, videos o musica";
            treeNode10.Checked = true;
            treeNode10.Name = "Node9";
            treeNode10.Text = "Juegos";
            treeNode10.ToolTipText = "Juegos Simples de Programar";
            treeNode11.Name = "Node11";
            treeNode11.Text = "Sin Acomodar";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(269, 429);
            this.treeView1.TabIndex = 1;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 453);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}

