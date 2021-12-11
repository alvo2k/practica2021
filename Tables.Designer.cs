namespace praktika3
{
    partial class Tables
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleate = new System.Windows.Forms.Button();
            this.btxUsers = new System.Windows.Forms.Button();
            this.btnZapisi = new System.Windows.Forms.Button();
            this.btnOutDated = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(776, 701);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 757);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 52);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(236, 757);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 52);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 757);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 52);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleate
            // 
            this.btnDeleate.Location = new System.Drawing.Point(639, 757);
            this.btnDeleate.Name = "btnDeleate";
            this.btnDeleate.Size = new System.Drawing.Size(133, 52);
            this.btnDeleate.TabIndex = 1;
            this.btnDeleate.Text = "Удалить";
            this.btnDeleate.UseVisualStyleBackColor = true;
            this.btnDeleate.Click += new System.EventHandler(this.btnDeleate_Click);
            // 
            // btxUsers
            // 
            this.btxUsers.Location = new System.Drawing.Point(12, 12);
            this.btxUsers.Name = "btxUsers";
            this.btxUsers.Size = new System.Drawing.Size(149, 32);
            this.btxUsers.TabIndex = 1;
            this.btxUsers.Text = "Пользователи";
            this.btxUsers.UseVisualStyleBackColor = true;
            this.btxUsers.Click += new System.EventHandler(this.btxUsers_Click);
            // 
            // btnZapisi
            // 
            this.btnZapisi.Location = new System.Drawing.Point(324, 12);
            this.btnZapisi.Name = "btnZapisi";
            this.btnZapisi.Size = new System.Drawing.Size(149, 32);
            this.btnZapisi.TabIndex = 1;
            this.btnZapisi.Text = "Записи";
            this.btnZapisi.UseVisualStyleBackColor = true;
            this.btnZapisi.Click += new System.EventHandler(this.btnZapisi_Click);
            // 
            // btnOutDated
            // 
            this.btnOutDated.Location = new System.Drawing.Point(639, 12);
            this.btnOutDated.Name = "btnOutDated";
            this.btnOutDated.Size = new System.Drawing.Size(149, 32);
            this.btnOutDated.TabIndex = 1;
            this.btnOutDated.Text = "Прошедшее";
            this.btnOutDated.UseVisualStyleBackColor = true;
            this.btnOutDated.Click += new System.EventHandler(this.btnOutDated_Click);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 821);
            this.Controls.Add(this.btnDeleate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnOutDated);
            this.Controls.Add(this.btnZapisi);
            this.Controls.Add(this.btxUsers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tables";
            this.Text = "Tables";
            this.Load += new System.EventHandler(this.Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleate;
        private System.Windows.Forms.Button btxUsers;
        private System.Windows.Forms.Button btnZapisi;
        private System.Windows.Forms.Button btnOutDated;
    }
}