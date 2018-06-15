namespace RenemeTool
{
    partial class DistributeFolders
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
            this.groupBoxFrom = new System.Windows.Forms.GroupBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.renameBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.CompleteFlg.DataPropertyName = "移動完了";
            this.CompleteFlg.Frozen = true;
            this.CompleteFlg.HeaderText = "移動完了";
            this.CompleteFlg.Name = "CompleteFlg";
            this.CompleteFlg.ReadOnly = true;
            this.CompleteFlg.Width = 61;
            // 
            // befor
            // 
            this.befor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.befor.DataPropertyName = "移動前ファイルパス";
            this.befor.HeaderText = "移動前ファイルパス";
            this.befor.Name = "befor";
            this.befor.ReadOnly = true;
            this.befor.Width = 75;
            // 
            // after
            // 
            this.after.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.after.DataPropertyName = "移動後ファイルパス";
            this.after.HeaderText = "移動後ファイルパス";
            this.after.Name = "after";
            this.after.Width = 75;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMove, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBoxFrom
            // 
            this.groupBoxFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFrom.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFrom.Name = "groupBoxFrom";
            this.groupBoxFrom.Size = new System.Drawing.Size(288, 81);
            this.groupBoxFrom.TabIndex = 6;
            this.groupBoxFrom.TabStop = false;
            this.groupBoxFrom.Text = "From";
            // 
            // buttonMove
            // 
            this.buttonMove.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMove.Location = new System.Drawing.Point(794, 3);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(85, 81);
            this.buttonMove.TabIndex = 2;
            this.buttonMove.Text = "▼移動";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // renameBackgroundWorker
            // 
            this.renameBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.renameBackgroundWorker_DoWork);
            this.renameBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.renameBackgroundWorker_ProgressChanged);
            this.renameBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.renameBackgroundWorker_RunWorkerCompleted);
            // 
            // DistributeFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DistributeFolders";
            this.Text = "DistributeFolders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn befor;
        private System.Windows.Forms.DataGridViewTextBoxColumn after;
        private System.Windows.Forms.GroupBox groupBoxFrom;
        private System.ComponentModel.BackgroundWorker renameBackgroundWorker;
    }
}

