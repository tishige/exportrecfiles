﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.18444
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace exportrecfile.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("exportrecfile.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   引数が間違っています。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_E_001_INV_ARG {
            get {
                return ResourceManager.GetString("LMSG_E_001_INV_ARG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   日付の指定が正しくありません。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_E_002_INV_DATE {
            get {
                return ResourceManager.GetString("LMSG_E_002_INV_DATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   DBアクセスで異常が発生しました。詳細＝{0} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_E_100_DB_ERR {
            get {
                return ResourceManager.GetString("LMSG_E_100_DB_ERR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ファイル出力で異常が発生しました。詳細={0} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_E_201_FILE_WRITE {
            get {
                return ResourceManager.GetString("LMSG_E_201_FILE_WRITE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   予期せぬエラーが発生しました。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_E_999_ACCIDENTAL {
            get {
                return ResourceManager.GetString("LMSG_E_999_ACCIDENTAL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   開始します。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_I_001_START {
            get {
                return ResourceManager.GetString("LMSG_I_001_START", resourceCulture);
            }
        }
        
        /// <summary>
        ///   終了します。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string LMSG_I_002_END {
            get {
                return ResourceManager.GetString("LMSG_I_002_END", resourceCulture);
            }
        }
    }
}
