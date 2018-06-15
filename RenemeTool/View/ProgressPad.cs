using System;
using System.Security.Permissions;
using System.Windows.Forms;

namespace RenemeTool.View
{
    public partial class ProgressPad : Form
    {
        private string _pmsg;
        private int _max;

        public ProgressPad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 処理中PADダイアログ表示
        /// </summary>
        /// <param name="owner">親コントロール</param>
        /// <param name="msg">処理中に表示するメッセージ</param>
        /// <param name="pmsg">進捗メッセージ　※「{0}」と「{1}」を使用していること。
        /// <para>{0}：進捗値に使用される</para>
        /// <para>{1}：最大値に使用される</para>
        /// </param>
        /// <param name="max">最大値</param>
        public void ShowDialog(IWin32Window owner, string msg, string pmsg, int max)
        {
            _pmsg = pmsg;
            _max = max;

            // コントロールを初期化する
            buttonClose.Enabled = false;

            renameProgress.Minimum = 0;
            renameProgress.Maximum = _max = max;
            renameProgress.Value = 0;

            labelMsg.Text = msg;
            labelProgress.Text = string.Format(_pmsg, 0, _max);

            this.ShowDialog(owner);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetProgress(int value)
        {
            renameProgress.Value = value;
            labelProgress.Text = string.Format(_pmsg, value, _max);
        }

        /// <summary>
        /// 完了メッセージ設定
        /// </summary>
        /// <param name="msg"></param>
        public void SetCompletedMsg(string msg)
        {
            labelMsg.Text = msg;
        }

        public void SetButtonEnubled(bool isEnubled)
        {
            buttonClose.Enabled = isEnubled;
        }

        /// <summary>
        /// ×ボタンを無効に
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
