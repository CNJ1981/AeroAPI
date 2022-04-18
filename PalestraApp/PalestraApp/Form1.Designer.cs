namespace PalestraApp
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.iniciarbutton = new System.Windows.Forms.Button();
            this.respostabutton = new System.Windows.Forms.Button();
            this.replicabutton = new System.Windows.Forms.Button();
            this.treplicabutton = new System.Windows.Forms.Button();
            this.zerabutton = new System.Windows.Forms.Button();
            this.tempoNormaltextBox = new System.Windows.Forms.TextBox();
            this.tempoRespostatextBox = new System.Windows.Forms.TextBox();
            this.tempoReplicatextBox = new System.Windows.Forms.TextBox();
            this.tempoTreplicatextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 170);
            this.label1.TabIndex = 0;
            this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDoubleClick);
            // 
            // iniciarbutton
            // 
            this.iniciarbutton.Location = new System.Drawing.Point(504, 9);
            this.iniciarbutton.Name = "iniciarbutton";
            this.iniciarbutton.Size = new System.Drawing.Size(92, 32);
            this.iniciarbutton.TabIndex = 1;
            this.iniciarbutton.Text = "Iniciar";
            this.iniciarbutton.UseVisualStyleBackColor = true;
            this.iniciarbutton.Click += new System.EventHandler(this.iniciarbutton_Click);
            // 
            // respostabutton
            // 
            this.respostabutton.Location = new System.Drawing.Point(504, 99);
            this.respostabutton.Name = "respostabutton";
            this.respostabutton.Size = new System.Drawing.Size(92, 32);
            this.respostabutton.TabIndex = 2;
            this.respostabutton.Text = "Resposta";
            this.respostabutton.UseVisualStyleBackColor = true;
            this.respostabutton.Click += new System.EventHandler(this.respostabutton_Click);
            // 
            // replicabutton
            // 
            this.replicabutton.Location = new System.Drawing.Point(504, 132);
            this.replicabutton.Name = "replicabutton";
            this.replicabutton.Size = new System.Drawing.Size(92, 32);
            this.replicabutton.TabIndex = 3;
            this.replicabutton.Text = "Réplica";
            this.replicabutton.UseVisualStyleBackColor = true;
            this.replicabutton.Click += new System.EventHandler(this.replicabutton_Click);
            // 
            // treplicabutton
            // 
            this.treplicabutton.Location = new System.Drawing.Point(504, 165);
            this.treplicabutton.Name = "treplicabutton";
            this.treplicabutton.Size = new System.Drawing.Size(92, 32);
            this.treplicabutton.TabIndex = 4;
            this.treplicabutton.Text = "Tréplica";
            this.treplicabutton.UseVisualStyleBackColor = true;
            this.treplicabutton.Click += new System.EventHandler(this.treplicabutton_Click);
            // 
            // zerabutton
            // 
            this.zerabutton.Location = new System.Drawing.Point(504, 47);
            this.zerabutton.Name = "zerabutton";
            this.zerabutton.Size = new System.Drawing.Size(92, 32);
            this.zerabutton.TabIndex = 5;
            this.zerabutton.Text = "Zerar";
            this.zerabutton.UseVisualStyleBackColor = true;
            this.zerabutton.Click += new System.EventHandler(this.zerabutton_Click);
            // 
            // tempoNormaltextBox
            // 
            this.tempoNormaltextBox.Location = new System.Drawing.Point(658, 9);
            this.tempoNormaltextBox.Name = "tempoNormaltextBox";
            this.tempoNormaltextBox.Size = new System.Drawing.Size(100, 26);
            this.tempoNormaltextBox.TabIndex = 7;
            this.tempoNormaltextBox.Text = "10";
            // 
            // tempoRespostatextBox
            // 
            this.tempoRespostatextBox.Location = new System.Drawing.Point(658, 104);
            this.tempoRespostatextBox.Name = "tempoRespostatextBox";
            this.tempoRespostatextBox.Size = new System.Drawing.Size(100, 26);
            this.tempoRespostatextBox.TabIndex = 8;
            this.tempoRespostatextBox.Text = "5";
            // 
            // tempoReplicatextBox
            // 
            this.tempoReplicatextBox.Location = new System.Drawing.Point(658, 136);
            this.tempoReplicatextBox.Name = "tempoReplicatextBox";
            this.tempoReplicatextBox.Size = new System.Drawing.Size(100, 26);
            this.tempoReplicatextBox.TabIndex = 9;
            this.tempoReplicatextBox.Text = "3";
            // 
            // tempoTreplicatextBox
            // 
            this.tempoTreplicatextBox.Location = new System.Drawing.Point(658, 168);
            this.tempoTreplicatextBox.Name = "tempoTreplicatextBox";
            this.tempoTreplicatextBox.Size = new System.Drawing.Size(100, 26);
            this.tempoTreplicatextBox.TabIndex = 10;
            this.tempoTreplicatextBox.Text = "3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 201);
            this.Controls.Add(this.tempoTreplicatextBox);
            this.Controls.Add(this.tempoReplicatextBox);
            this.Controls.Add(this.tempoRespostatextBox);
            this.Controls.Add(this.tempoNormaltextBox);
            this.Controls.Add(this.zerabutton);
            this.Controls.Add(this.treplicabutton);
            this.Controls.Add(this.replicabutton);
            this.Controls.Add(this.respostabutton);
            this.Controls.Add(this.iniciarbutton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "VII FOCOTRAN";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button iniciarbutton;
        private System.Windows.Forms.Button respostabutton;
        private System.Windows.Forms.Button replicabutton;
        private System.Windows.Forms.Button treplicabutton;
        private System.Windows.Forms.Button zerabutton;
        private System.Windows.Forms.TextBox tempoNormaltextBox;
        private System.Windows.Forms.TextBox tempoRespostatextBox;
        private System.Windows.Forms.TextBox tempoReplicatextBox;
        private System.Windows.Forms.TextBox tempoTreplicatextBox;
    }
}

