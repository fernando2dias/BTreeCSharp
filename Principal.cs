using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using EinarEgilsson;
using System.Collections.Generic;

namespace ExercArvore
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Principal : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtNum;
        
        private System.Windows.Forms.Button btnInsert;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Button button2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnEmOrdem;
        private Button button4;
        private Button button3;
        private Button button5;
        private BTree bt;

        public Principal()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEmOrdem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(16, 28);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 26);
            this.txtNum.TabIndex = 0;
            this.txtNum.Text = "0";
            // 
            // lblFind
            // 
            this.lblFind.Location = new System.Drawing.Point(12, 63);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(853, 23);
            this.lblFind.TabIndex = 1;
            this.lblFind.Click += new System.EventHandler(this.lblFind_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(124, 28);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(96, 32);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "&Inserir";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Procurar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnEmOrdem);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.lblFind);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operações com a Árvore:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(705, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 32);
            this.button5.TabIndex = 8;
            this.button5.Text = "Nível";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(611, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 32);
            this.button4.TabIndex = 7;
            this.button4.Text = "Pós Ord";
            this.button4.Click += new System.EventHandler(this.btnPosOrdem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(525, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 32);
            this.button3.TabIndex = 6;
            this.button3.Text = "Pré Ord";
            this.button3.Click += new System.EventHandler(this.btnPreOrdem_Click);
            // 
            // btnEmOrdem
            // 
            this.btnEmOrdem.Location = new System.Drawing.Point(430, 28);
            this.btnEmOrdem.Name = "btnEmOrdem";
            this.btnEmOrdem.Size = new System.Drawing.Size(89, 32);
            this.btnEmOrdem.TabIndex = 5;
            this.btnEmOrdem.Text = "Em Ord";
            this.btnEmOrdem.Click += new System.EventHandler(this.btnEmOrdem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Remover";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 509);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Árvore:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 484);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 321);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(877, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Principal";
            this.Text = "Árvore Binária";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Principal());
        }

        // Load - cria a árvore
        private void Principal_Load(object sender, System.EventArgs e)
        {
            bt = new BTree();
        }

        // Insere itens
        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            bt.Insert(Convert.ToInt32(txtNum.Text));
            DrawTree();
        }

        // Procura por itens
        private void button1_Click(object sender, System.EventArgs e)
        {
            Node n = bt.Find(Convert.ToInt32(txtNum.Text));
            if (n == null)
                lblFind.Text = "NÃO ENCONTRADO!!!";
            else
                lblFind.Text = "ENCONTRADO!!!";
            DrawTree();
        }

        // Apaga um item
        private void button2_Click_1(object sender, EventArgs e)
        {
            bt.Remove(Convert.ToInt32(txtNum.Text));
            DrawTree();
        }

        // Construindo a raiz da árvore
        private void DrawTree()
        {
            BinaryTreeImage bti = new BinaryTreeImage(bt.Root);
            pictureBox1.Image = bti.Bitmap;
            pictureBox1.Width = bti.Bitmap.Width;
            pictureBox1.Height = bti.Bitmap.Height;
        }
        
        private void btnEmOrdem_Click(object sender, EventArgs e)
        {
            List<Node> list = bt.InOrder();
            ShowList(list);
        }

        private void btnPreOrdem_Click(object sender, EventArgs e)
        {
            List<Node> list = bt.PreOrder();
            ShowList(list);
        }

        private void btnPosOrdem_Click(object sender, EventArgs e)
        {
            List<Node> list = bt.PosOrder();
            ShowList(list);
        }

        private void ShowList(List<Node> list)
        {
            string nos = String.Empty;
            if (list != null)
            {
                foreach (var n in list)
                {
                    nos += n.Info.ToString() + " ";
                }
            }
            lblFind.Text = nos;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //List<Node> list = bt.InLevel();
            //ShowList(list);
            
        }

        private void lblFind_Click(object sender, EventArgs e)
        {

        }
    }
}
