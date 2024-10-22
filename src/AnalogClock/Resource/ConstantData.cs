using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AnalogClock.Resource
{
    /// <summary>
    /// 定数データ
    /// </summary>
    class ConstantData
    {
        public static readonly string VERSION = "0.1.0";

        /// <summary>
        /// 時計の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_CLOCK_LENGTH = 200;

        /// <summary>
        /// 文字盤の基本フォントサイズ
        /// </summary>
        public static readonly double ORIGINAL_NUMBER_FONT_SIZE = 24;

        /// <summary>
        /// 影の基本長さ
        /// </summary>
        public static readonly double ORIGINAL_SHADOW_SIZE = 8;

        /// <summary>
        /// 秒針の基本長さ
        /// 時計全体の半分の94%とする
        /// </summary>
        public static readonly double ORIGINAL_SECOND_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.94;

        /// <summary>
        /// 秒針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_SECOND_HAND_WIDTH = 1;

        /// <summary>
        /// 分針の基本長さ
        /// 時計全体の半分の78%とする
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.78;

        /// <summary>
        /// 分針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_MINUTE_HAND_WIDTH = 3;

        /// <summary>
        /// 時針の基本長さ
        /// 時計全体の半分の45%とする
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_LENGTH = ORIGINAL_CLOCK_LENGTH / 2 * 0.45;

        /// <summary>
        /// 時針の基本幅
        /// </summary>
        public static readonly double ORIGINAL_HOUR_HAND_WIDTH = 6;

        /// <summary>
        /// 秒目盛りの基本長さ
        /// </summary>
        public static readonly double ORIGINAL_SECOND_SCALE_LENGTH = 5;

        /// <summary>
        /// 秒目盛りの基本幅
        /// </summary>
        public static readonly double ORIGINAL_SECOND_SCALE_WIDTH = 0.6;

        /// <summary>
        /// 5の倍数の秒目盛りのサイズ比率
        /// </summary>
        public static readonly double ORIGINAL_5SECOND_SCALE_SIZE_RATE = 1.6;

        /// <summary>
        /// ハルマゲドンのクールダウンタイム(秒)
        /// </summary>
        public static readonly double COOL_DOWN_TIME_SECOND = 4 * 60 + 55;

        /// <summary>
        /// クールダウンタイムの警告色
        /// </summary>
        public static readonly Brush COOL_DOWN_TIME_WARN_BACKGROUND = new SolidColorBrush(Color.FromArgb(0xA0, 0xFF, 0xFF, 0x00));

        /// <summary>
        /// クールダウンタイムが時間切れになったときの色
        /// </summary>
        public static readonly Brush COOL_DOWN_TIME_UP_BACKGROUND = new SolidColorBrush(Color.FromArgb(0x70, 0xFF, 0x00, 0x00));

        /// <summary>
        /// ヘルプの表示文字列
        /// </summary>
        public static readonly string HELP_MESSAGE = "■使い方\n" +
            "・ハルマゲドンボタンを押すと、ハルマゲドンモードになります\n" +
            "・ハルマゲドンモードになると、クールタイム終了時刻を4分55秒後にセットします\n" +
            "・クールタイム終了時刻の1分前になると、文字盤が徐々に黄色に点滅します\n" +
            "・クールタイム終了時刻を過ぎると、文字盤全体が赤色に点滅します\n" +
            "・ハルマゲドンで戦闘を開始したらクールタイムスタートボタンを押してください。クールタイムを再設定します。\n" +
            "・ハルマゲドンボタンを再度押すとハルマゲドンモードを解除できます\n" +
            "\n" +
            "※画面スペースの都合上クールダウンタイムのことをクールタイムと呼んでいます\n" +
            "\n" +
            "■補足\n" +
            "・本アプリケーションの時刻は、システム(=Windows)の時刻と一致しています。カゲマスサーバーの時刻とずれていると感じたら、システムの時刻を修正してください。\n" +
            "・本アプリケーションの使用によって生じたいかなる損害にも、作成者は一切の責任を負いません。自己責任でご使用ください。\n" +
            "・ソースコードはGitHubにて公開しています。GitHubアカウントは「作成者」をご参照ください。\n" +
            "\n" +
            "■バージョン\n" + VERSION;

        /// <summary>
        /// 作成者情報
        /// </summary>
        internal static readonly string CREATOR_INFO = "Xアカウント: @SimonKagemasu\n" +
            "GitHubアカウント: simon-mog\n" +
            "\n" +
            "ご要望があればXアカウントへご連絡ください\n" +
            "対応するかもしれません";
    }
}
