namespace RenemeTool
{
    partial class RenameTool
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewFile = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompleteFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.befor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.after = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDistributeFolders = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTimeSpan = new System.Windows.Forms.TextBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.textBoxDateTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.renameBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFile
            // 
            this.dataGridViewFile.AllowDrop = true;
            this.dataGridViewFile.AllowUserToAddRows = false;
            this.dataGridViewFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CompleteFlg,
            this.befor,
            this.after});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewFile, 3);
            this.dataGridViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFile.Location = new System.Drawing.Point(10, 97);
            this.dataGridViewFile.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewFile.Name = "dataGridViewFile";
            this.dataGridViewFile.RowTemplate.Height = 21;
            this.dataGridViewFile.Size = new System.Drawing.Size(862, 285);
            this.dataGridViewFile.TabIndex = 1;
            this.dataGridViewFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewFile_DragDrop);
            this.dataGridViewFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewFile_DragEnter);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 44;
            // 
            // CompleteFlg
            // 
            this.CompleteFlg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CompleteFlg.Frozen = true;
            this.CompleteFlg.HeaderText = "変更完了";
            this.CompleteFlg.Name = "CompleteFlg";
            this.CompleteFlg.ReadOnly = true;
            this.CompleteFlg.Width = 61;
            // 
            // befor
            // 
            this.befor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.befor.DataPropertyName = "変更前ファイル";
            this.befor.HeaderText = "変更前ファイル";
            this.befor.Name = "befor";
            this.befor.ReadOnly = true;
            this.befor.Width = 69;
            // 
            // after
            // 
            this.after.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.after.DataPropertyName = "変更後ファイル";
            this.after.HeaderText = "変更後ファイル";
            this.after.Name = "after";
            this.after.Width = 69;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDistributeFolders, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonChange, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonDistributeFolders
            // 
            this.buttonDistributeFolders.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDistributeFolders.Location = new System.Drawing.Point(794, 395);
            this.buttonDistributeFolders.Name = "buttonDistributeFolders";
            this.buttonDistributeFolders.Size = new System.Drawing.Size(85, 39);
            this.buttonDistributeFolders.TabIndex = 5;
            this.buttonDistributeFolders.Text = "フォルダ振分▶";
            this.buttonDistributeFolders.UseVisualStyleBackColor = true;
            this.buttonDistributeFolders.Click += new System.EventHandler(this.buttonDistributeFolders_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonChange.Location = new System.Drawing.Point(794, 3);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(85, 81);
            this.buttonChange.TabIndex = 2;
            this.buttonChange.Text = "▼変更";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTimeSpan, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonConvert, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxDateTime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 87);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(297, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "日時";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // textBoxTimeSpan
            // 
            this.textBoxTimeSpan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTimeSpan.Location = new System.Drawing.Point(3, 32);
            this.textBoxTimeSpan.Name = "textBoxTimeSpan";
            this.textBoxTimeSpan.Size = new System.Drawing.Size(288, 19);
            this.textBoxTimeSpan.TabIndex = 5;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonConvert.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.buttonConvert.Location = new System.Drawing.Point(500, 61);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(85, 23);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "▲変換";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // textBoxDateTime
            // 
            this.textBoxDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDateTime.Location = new System.Drawing.Point(297, 32);
            this.textBoxDateTime.Name = "textBoxDateTime";
            this.textBoxDateTime.Size = new System.Drawing.Size(288, 19);
            this.textBoxDateTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "タイムスパン";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // renameBackgroundWorker
            // 
            this.renameBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.renameBackgroundWorker_DoWork);
            this.renameBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.renameBackgroundWorker_ProgressChanged);
            this.renameBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.renameBackgroundWorker_RunWorkerCompleted);
            // 
            // RenameTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RenameTool";
            this.Text = "RenemeTool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TextBox textBoxDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTimeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn befor;
        private System.Windows.Forms.DataGridViewTextBoxColumn after;
        private System.Windows.Forms.Button buttonDistributeFolders;
        private System.ComponentModel.BackgroundWorker renameBackgroundWorker;
    }
}

