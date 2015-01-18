using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace exportrecfile
{

    /// <summary>
    /// ファイル出力失敗例外
    /// </summary>
    /// 

    class Fileoutexception : Exception
    {
        public Fileoutexception(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Fileutil
    /// </summary>
    
    class FileUtil
    {

        // Logger
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Encoding
        private static System.Text.Encoding FILE_ENCODING = System.Text.Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// 通録結果一覧のCSVファイルを作成
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="header"></param>
        /// <param name="dataList"></param>

        public static void CreateCsv(string outputPath, string[] header, List<string[]> dataList)
        {
            try
            {
                using(System.IO.StreamWriter sr=new System.IO.StreamWriter(outputPath,false,FILE_ENCODING))//append=false
                {
                    // header
                    if (header !=null)
                    {
                        sr.WriteLine(string.Join(",", header));

                    }

                    // data
                    foreach (string[] data in dataList)
                    {
                        sr.WriteLine(string.Join(",", data));
                    }

                }
            }
            catch (Exception e )
            {
                
                throw new Fileoutexception(string.Format(Properties.Resources.LMSG_E_201_FILE_WRITE,e.Message));
            }
            logger.Info("CSV " + outputPath + " 作成完了");

        }

        /// <summary>
        /// バッチファイルを作成
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="dataList"></param>

        public static void CreateBat(string outputPath,List<string[]> dataList)
        {
            try
            {
                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(outputPath, false, FILE_ENCODING))//append=false

                foreach (string[] data in dataList)
                {
                        string filename = Path.GetFileNameWithoutExtension(data[0]);
                        string path = Path.GetDirectoryName(data[0]);
                        sr.WriteLine(Properties.Settings.Default.EncryptExePath + " -d "+path+@"\"+filename + ".i3r -o " + path+@"\"+filename+".wav");
                        logger.Info(filename+ " Encrypt bat完了");

                }
               
            }
            catch (Exception e )
            {
                throw new Fileoutexception(string.Format(Properties.Resources.LMSG_E_201_FILE_WRITE,e.Message));
            }
        }

        /// <summary>
        /// コピー先にディレクトリを作成
        /// </summary>
        /// <param name="outputDirectory"></param>

        public static void CreateDirectory(string outputDirectory)
        {
            try
            {
                System.IO.Directory.CreateDirectory(outputDirectory);
                logger.Info(outputDirectory + "作成完了");

            }
            catch (Exception e)
            {
                throw new Fileoutexception(string.Format(Properties.Resources.LMSG_E_201_FILE_WRITE, e.Message));
            }
        }

        /// <summary>
        /// 通録一覧のファイルをコピー
        /// </summary>
        /// <param name="FromPath"></param>
        /// <param name="ToPath"></param>

        public List<string[]> CopyFiles(List<string[]> FromPath, string ToPath)
        {
            try
            {
                List<string[]> ret = new List<string[]>();
                foreach (string[] data in FromPath)
                {
                    if (data[6] == "")
                    {
                        logger.Info("CallID " + data[0] + " はファイルパスが存在しないためスキップ");
                    }
                    else
                    {
                        string filename = Path.GetFileName(data[6]);
                        System.IO.File.Copy(data[6], ToPath + @"\" + filename,true);
                        logger.Info("Copy " + data[6] + " to " + ToPath + " 完了");
                        ret.Add(new string [] {ToPath + @"\" + filename});
                    }
                }
                return ret;
            }
             
            catch (Exception e)
            {
                throw new Fileoutexception(string.Format(Properties.Resources.LMSG_E_201_FILE_WRITE, e.Message));
            }



        }



        //public static void CopyFiles(List<string[]> FromPath, string ToPath)
        //{
        //    try
        //    {
        //        foreach(string[] data in FromPath)
        //        {
        //            if (data[6]=="")
        //            {
        //                logger.Info("CallID " + data[0] + " はファイルパスが存在しないためスキップ");
        //             }
        //            else
        //            {
        //                string filename = Path.GetFileName(data[6]);
        //                System.IO.File.Copy(data[6], ToPath+@"\"+filename);
        //                logger.Info("Copy " + data[6] + " to " + ToPath + " 完了");
 
        //            }
        //         }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Fileoutexception(string.Format(Properties.Resources.LMSG_E_201_FILE_WRITE, e.Message));
        //    }
        //}




    }
}
