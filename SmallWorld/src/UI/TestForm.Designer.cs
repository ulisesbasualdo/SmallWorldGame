﻿namespace SmallWorld.src.UI
{
    partial class TestForm
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
            this.btnCreateEntity = new System.Windows.Forms.Button();
            this.cbKingdom = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDiet = new System.Windows.Forms.ComboBox();
            this.cbHabitat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAttack = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDefense = new System.Windows.Forms.TrackBar();
            this.lblAttackPoints = new System.Windows.Forms.Label();
            this.lblDefensePoints = new System.Windows.Forms.Label();
            this.iKingdomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vegetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vegetableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.animalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vegetableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKingdomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateEntity
            // 
            this.btnCreateEntity.Location = new System.Drawing.Point(76, 285);
            this.btnCreateEntity.Name = "btnCreateEntity";
            this.btnCreateEntity.Size = new System.Drawing.Size(197, 23);
            this.btnCreateEntity.TabIndex = 0;
            this.btnCreateEntity.Text = "Crear Entidad";
            this.btnCreateEntity.UseVisualStyleBackColor = true;
            this.btnCreateEntity.Click += new System.EventHandler(this.btnCreateEntity_Click);
            // 
            // cbKingdom
            // 
            this.cbKingdom.FormattingEnabled = true;
            this.cbKingdom.Location = new System.Drawing.Point(232, 76);
            this.cbKingdom.Name = "cbKingdom";
            this.cbKingdom.Size = new System.Drawing.Size(121, 21);
            this.cbKingdom.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(232, 123);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre Entidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dieta";
            // 
            // cbDiet
            // 
            this.cbDiet.FormattingEnabled = true;
            this.cbDiet.Location = new System.Drawing.Point(462, 75);
            this.cbDiet.Name = "cbDiet";
            this.cbDiet.Size = new System.Drawing.Size(121, 21);
            this.cbDiet.TabIndex = 7;
            // 
            // cbHabitat
            // 
            this.cbHabitat.FormattingEnabled = true;
            this.cbHabitat.Location = new System.Drawing.Point(462, 127);
            this.cbHabitat.Name = "cbHabitat";
            this.cbHabitat.Size = new System.Drawing.Size(121, 21);
            this.cbHabitat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Habitat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fuerza de Ataque";
            // 
            // tbAttack
            // 
            this.tbAttack.LargeChange = 10;
            this.tbAttack.Location = new System.Drawing.Point(234, 197);
            this.tbAttack.Maximum = 90;
            this.tbAttack.Minimum = 10;
            this.tbAttack.Name = "tbAttack";
            this.tbAttack.Size = new System.Drawing.Size(104, 45);
            this.tbAttack.TabIndex = 11;
            this.tbAttack.Value = 10;
            this.tbAttack.Scroll += new System.EventHandler(this.tbAttack_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Escudo de Defensa";
            // 
            // tbDefense
            // 
            this.tbDefense.Enabled = false;
            this.tbDefense.LargeChange = 10;
            this.tbDefense.Location = new System.Drawing.Point(540, 197);
            this.tbDefense.Maximum = 100;
            this.tbDefense.Name = "tbDefense";
            this.tbDefense.Size = new System.Drawing.Size(104, 45);
            this.tbDefense.TabIndex = 13;
            this.tbDefense.Value = 90;
            // 
            // lblAttackPoints
            // 
            this.lblAttackPoints.AutoSize = true;
            this.lblAttackPoints.Location = new System.Drawing.Point(140, 214);
            this.lblAttackPoints.Name = "lblAttackPoints";
            this.lblAttackPoints.Size = new System.Drawing.Size(0, 13);
            this.lblAttackPoints.TabIndex = 14;
            // 
            // lblDefensePoints
            // 
            this.lblDefensePoints.AutoSize = true;
            this.lblDefensePoints.Location = new System.Drawing.Point(418, 214);
            this.lblDefensePoints.Name = "lblDefensePoints";
            this.lblDefensePoints.Size = new System.Drawing.Size(0, 13);
            this.lblDefensePoints.TabIndex = 15;
            // 
            // iKingdomBindingSource
            // 
            this.iKingdomBindingSource.DataSource = typeof(SmallWorld.src.Interfaces.IKingdom);
            // 
            // vegetableBindingSource
            // 
            this.vegetableBindingSource.DataSource = typeof(SmallWorld.src.Model.Reino.Vegetable);
            // 
            // vegetableBindingSource1
            // 
            this.vegetableBindingSource1.DataSource = typeof(SmallWorld.src.Model.Reino.Vegetable);
            // 
            // animalBindingSource
            // 
            this.animalBindingSource.DataSource = typeof(SmallWorld.src.Model.Reino.Animal);
            // 
            // vegetableBindingSource2
            // 
            this.vegetableBindingSource2.DataSource = typeof(SmallWorld.src.Model.Reino.Vegetable);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(362, 285);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(266, 121);
            this.listBox1.TabIndex = 16;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Mostrar Entidades Por Consola";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblDefensePoints);
            this.Controls.Add(this.lblAttackPoints);
            this.Controls.Add(this.tbDefense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAttack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbHabitat);
            this.Controls.Add(this.cbDiet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbKingdom);
            this.Controls.Add(this.btnCreateEntity);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.tbAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKingdomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vegetableBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateEntity;
        private System.Windows.Forms.ComboBox cbKingdom;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDiet;
        private System.Windows.Forms.ComboBox cbHabitat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbAttack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbDefense;
        private System.Windows.Forms.Label lblAttackPoints;
        private System.Windows.Forms.Label lblDefensePoints;
        private System.Windows.Forms.BindingSource vegetableBindingSource;
        private System.Windows.Forms.BindingSource vegetableBindingSource1;
        private System.Windows.Forms.BindingSource iKingdomBindingSource;
        private System.Windows.Forms.BindingSource animalBindingSource;
        private System.Windows.Forms.BindingSource vegetableBindingSource2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}