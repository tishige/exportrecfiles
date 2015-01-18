using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Globalization;
using System.Text.RegularExpressions;

namespace exportrecfile
{
    /// <summary>
    /// 通録ファイルエクスポート本体
    /// </summary>
    class Program
    {
        // Logger
        private static readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string DATE_FORMAT_ARG = "yyyyMMddHHmmss";
        
        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            try
            {
                //引数チェック
                if (args.Length != 3)
                {
                    logger.Error(Properties.Resources.LMSG_E_001_INV_ARG);
                    printUsage();
                    return;
                }
                DateTime start;
                if (!DateTime.TryParseExact(args[0], DATE_FORMAT_ARG, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out start))
                {
                    logger.Error(Properties.Resources.LMSG_E_002_INV_DATE);
                    printUsage();
                    return;
                }
                DateTime end;
                if (!DateTime.TryParseExact(args[1], DATE_FORMAT_ARG, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out end))
                {
                    logger.Error(Properties.Resources.LMSG_E_002_INV_DATE);
                    printUsage();
                    return;
                }

                //開始
                logger.Info(Properties.Resources.LMSG_I_001_START);

                //From To 作成
                string Fromdate = args[0].Substring(0, 8) + "_" + args[0].Substring(8, 6);
                string Todate = args[1].Substring(0, 8) + "_" + args[1].Substring(8, 6);

                //DB
                DBAccessor acc = new DBAccessor();
                string sql =string.Format(Properties.Settings.Default.SelectCallDetail,start.ToString("yyyy-MM-dd HH:mm:ss"),end.ToString("yyyy-MM-dd HH:mm:ss"),args[2]);
                //logger.Info(sql);

                List<string[]> recdata = acc.GetRecordingData(sql);

                //csv&batch path
                string csvPath = Fromdate + "-" + Todate + ".csv";
                string batPath = Fromdate + "-" + Todate + ".bat";

                //wav files destination path
                string foldername = Properties.Settings.Default.DestinationDirectory;
                string pathString = System.IO.Path.Combine(foldername, Fromdate + "-" + Todate);

                FileUtil.CreateDirectory(pathString);

                if(recdata.Count()!=0)
                {
                    //csv header
                    string[] header = new string[] { "CallID,接続日時,通話時間秒,コールイベントログ,ワークグループ名,通録CallID,ファイル名,通録CallIdKey" };
                    
                    logger.Info("CSV作成開始");
                    FileUtil.CreateCsv(csvPath, header, recdata);
                    logger.Info("CSV作成完了");

                    logger.Info("Copy開始");
                    FileUtil fu = new FileUtil();
                    List<string[]> csvlist = fu.CopyFiles(recdata, pathString);
                    logger.Info("Copy終了");

                    logger.Info("BAT作成開始");
                    FileUtil.CreateBat(batPath, csvlist);
                    logger.Info("BAT完了");

                }
                else
                {
                    logger.Info("対象データなし");
                }

            }
            catch (Exception e)
            {
                logger.Error(String.Format(Properties.Resources.LMSG_E_999_ACCIDENTAL, e.Message), e);

            }
            finally
            {
                logger.Info(Properties.Resources.LMSG_I_002_END);
            }

        }

		/// <summary>
		/// Usageを出力します。
		/// </summary>
		private static void printUsage()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Usage:");
			sb.AppendLine("exportrecfile.exe 開始日　終了日 対象ワークグループ名");
			sb.AppendLine("");
			sb.AppendLine("開始日 終了日：CallHistoryテーブルを読み取る対象とする日");
			sb.AppendLine("　　　　yyyyMMddHHmmss形式で指定");
            sb.AppendLine("exportrecfile 20141201000000 20141231235959 ご注文");
            Console.Out.Write(sb.ToString());

        }
    }
}
