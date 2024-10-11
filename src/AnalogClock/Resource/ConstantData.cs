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
        public static readonly double COOL_DOWN_TIME_SECOND = 65;// 4 * 60 + 55;

        /// <summary>
        /// ヘルプの表示文字列
        /// </summary>
        public static readonly string HELP_MESSAGE = "・ハルマゲドンボタン\n" +
            "　・押すととハルマゲドンモードになる\n" +
            "　・ハルマゲドンモードのときに押すとハルマゲドンモードを解除する\n" +
            "\n" +
            "・ハルマゲドンモード\n" +
            "　・4分55秒間隔でタイマーが走る\n" +
            "　・終了1分前になると文字盤の色が変わる\n" +
            "　・ハルマゲドンボタンが濃ければハルマゲドンモード\n" +
            "\n" + 
            "商用利用を禁止します";

        /// <summary>
        /// 作成者情報
        /// </summary>
        internal static readonly string CREATOR_INFO = "Xアカウント: @SimonKagemasu";
    }
}
