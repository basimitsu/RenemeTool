using System.Deployment.Application;

namespace Utility.Assembly
{
    /// <summary>
    /// バージョンユーティリティー
    /// </summary>
    public class Vertion
    {
        /// <summary>
        /// クリックワンスのバージョンを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetAppVer()
        {
            // 現在のアプリケーションが ClickOnce アプリケーションかチェック
            // デバッグ時に呼び出すと例外になっちゃうので・・・。
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                // **バージョン取得
                return ad.CurrentVersion.ToString();
                // **最終更新日取得
                // update_date = "最終更新日:" + ad.TimeOfLastUpdateCheck.ToLongDateString().ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
