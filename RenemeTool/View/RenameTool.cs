using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RenemeTool.Business;
using RenemeTool.Common;
using RenemeTool.View;
using Utility.Log;

namespace RenemeTool
{

    public partial class RenameTool : Form
    {
        public const string COMPLETE = "〇";

        private ProgressPad _pad;

        public RenameTool()
        {
            InitializeComponent();

            _pad = new ProgressPad();
        }

        private void dataGridViewFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドラッグ中のファイルやディレクトリの取得
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string d in drags)
                {
                    if (!System.IO.File.Exists(d))
                    {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dataGridViewFile_DragDrop(object sender, DragEventArgs e)
        {
            // 処理が行われているときは、何もしない
            if (renameBackgroundWorker.IsBusy)
                return;

            // ドラッグ＆ドロップされたファイル
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // buttonConvertを無効にする
            buttonConvert.Enabled = false;

            // BackgroundWorkerのProgressChangedイベントが発生するようにする
            renameBackgroundWorker.WorkerReportsProgress = true;
            // DoWorkで取得できるパラメータ(10)を指定して、処理を開始する
            // パラメータが必要なければ省略できる
            renameBackgroundWorker.RunWorkerAsync(files);

            _pad.ShowDialog(this, "処理中です。", "{0}/{1} ファイル", files.Length);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewFile.RowCount == 0)
            {
                MessageBox.Show("変更前ファイルと変更後ファイルを指定してください。", "情報");
                return;
            }

            DialogResult result = MessageBox.Show("ファイル名を変更してよろしいですか？", "確認", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                bool isException = false;
                foreach (DataGridViewRow item in dataGridViewFile.Rows)
                {
                    string befor = null;
                    string after = null;
                    int completeIndex = 1;
                    int beforIndex = 2;
                    int afterIndex = 3;

                    if (item.Cells[beforIndex].Value == null || item.Cells[afterIndex].Value == null
                        || string.IsNullOrWhiteSpace(item.Cells[beforIndex].Value.ToString()) || string.IsNullOrWhiteSpace(item.Cells[afterIndex].Value.ToString()))
                    {
                        continue;
                    }

                    if (item.Cells[completeIndex].Value != null && item.Cells[completeIndex].Value.ToString() == COMPLETE)
                    {
                        continue;
                    }

                    befor = item.Cells[beforIndex].Value.ToString();
                    after = item.Cells[afterIndex].Value.ToString();

                    try
                    {
                        File.Move(befor, after);
                        DebugOnFile.LogWrite(string.Format(@"【リネーム】{0}""{1}""{2}""{3}""", "\t", befor, "\t", after));
                    }
                    catch (Exception ex)
                    {
                        isException = true;
                        DebugOnFile.ExceptionWrite(ex);
                    }

                    item.Cells[completeIndex].Value = COMPLETE;
                    item.Cells[afterIndex].ReadOnly = true;

                    item.Cells[0].Style.BackColor = Color.Gray;
                    item.Cells[completeIndex].Style.BackColor = Color.Gray;
                    item.Cells[beforIndex].Style.BackColor = Color.Gray;
                    item.Cells[afterIndex].Style.BackColor = Color.Gray;
                }

                if (isException)
                {
                    MessageBox.Show("リネームに失敗したファイルがあります。ログファイルを確認してください。", "情報");
                }
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            textBoxDateTime.Text = RenameToolBiz.ConvertToDateTime(textBoxTimeSpan.Text);
        }

        private void buttonDistributeFolders_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DistributeFolders screen = new DistributeFolders();
            screen.StartPosition = FormStartPosition.CenterParent;
            screen.ShowDialog(this);
            this.Visible = true;
        }

        /// <summary>
        /// BackgroundWorker1のDoWorkイベントハンドラ
        /// ここで時間のかかる処理を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = (BackgroundWorker)sender;

            // パラメータを取得する
            string[] files = (string[])e.Argument;

            DataTable dt = new DataTable();
            dt.Columns.Add("変更前ファイル");
            dt.Columns.Add("変更後ファイル");
            dt.Columns.Add("変更完了");
            dt.Columns.Add("No");

            dt.Columns["No"].AutoIncrement = true;
            dt.Columns["No"].AutoIncrementSeed = 1;

            // DataSetにファイルを追加
            RenameToolBiz.SetFileDataSet(bgWorker.ReportProgress, dt, files);

            // グリッドの設定
            _setGridView(dt);

            // ProgressChangedで取得できる結果を設定する
            // 結果が必要なければ省略できる
            e.Result = files.Length;
        }

        private void _setGridView(DataTable dt)
        {
            // Action<string> dele = delegate (string s) { Console.WriteLine(s); };

            DtAction dtac = (dtpaarm) =>
            {
                //列の自動追加抑止
                dataGridViewFile.AutoGenerateColumns = false;
                dataGridViewFile.AllowUserToAddRows = true;

                dataGridViewFile.DataSource = dt;
            };

            Invoke(dtac, dt);
        }

        /// <summary>
        /// BackgroundWorker1のProgressChangedイベントハンドラ
        /// コントロールの操作は必ずここで行い、DoWorkでは絶対にしない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // ProgressBarの値を変更する
            _pad.SetProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// BackgroundWorker1のRunWorkerCompletedイベントハンドラ
        /// 処理が終わったときに呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _pad.SetButtonEnubled(true);

            if (e.Error != null)
            {
                // エラーが発生したとき
                DebugOnFile.ExceptionWrite(e.Error);
                _pad.SetCompletedMsg("エラーが発生しました。");
            }
            else
            {
                // 正常に終了したとき
                _pad.SetCompletedMsg("正常に終了しました。");
                // int result = (int)e.Result;
            }

            // buttonConvertを有効に戻す
            buttonConvert.Enabled = true;
        }
    }
}
