using AnalogClock.Resource;
using AnalogClock.Model;
using AnalogClock.View;
using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;

namespace AnalogClock.ViewModel
{
    /// <summary>
    /// メインのViewModel
    /// 使用するView:
    ///   ・MainWindow(時計画面)
    /// </summary>
    class MainViewModel : BindableBase
    {
        #region Binding用プロパティ

        /// <summary>
        /// 【Binding用プロパティ】
        /// 数字位置オフセット
        /// 配列インデックス[0～11]は、数字の1～12に対応する。
        /// </summary>
        private Point[] _numberPositionOffsetArray;
        public Point[] NumberPositionOffsetArray
        {
            get { return _numberPositionOffsetArray; }
            set { SetProperty(ref _numberPositionOffsetArray, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒目盛り位置オフセット
        /// </summary>
        private Point _secondScalePositionOffset;
        public Point SecondScalePositionOffset
        {
            get { return _secondScalePositionOffset; }
            set { SetProperty(ref _secondScalePositionOffset, value); }
        }
        /// <summary>
        /// 【Binding用プロパティ】
        /// 5の倍数の秒目盛り位置オフセット
        /// </summary>
        private Point _secondScalePositionOffset5;
        public Point SecondScalePositionOffset5
        {
            get { return _secondScalePositionOffset5; }
            set { SetProperty(ref _secondScalePositionOffset5, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒目盛り角度
        /// </summary>
        private double[] _secondScaleAngleArray;
        public double[] SecondScaleAngleArray
        {
            get { return _secondScaleAngleArray; }
            set { SetProperty(ref _secondScaleAngleArray, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒目盛りサイズ
        /// </summary>
        private Size _secondScaleSize = new Size(ConstantData.ORIGINAL_SECOND_SCALE_WIDTH, ConstantData.ORIGINAL_SECOND_SCALE_LENGTH);
        public Size SecondScaleSize
        {
            get { return _secondScaleSize; }
            set { SetProperty(ref _secondScaleSize, value); }
        }
        /// <summary>
        /// 【Binding用プロパティ】
        /// 5の倍数の秒目盛りサイズ
        /// </summary>
        private Size _secondScaleSize5 = new Size(
            ConstantData.ORIGINAL_SECOND_SCALE_WIDTH * ConstantData.ORIGINAL_5SECOND_SCALE_SIZE_RATE,
            ConstantData.ORIGINAL_SECOND_SCALE_LENGTH * ConstantData.ORIGINAL_5SECOND_SCALE_SIZE_RATE);
        public Size SecondScaleSize5
        {
            get { return _secondScaleSize5; }
            set { SetProperty(ref _secondScaleSize5, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 影の長さ
        /// </summary>
        private double _shadowSize = ConstantData.ORIGINAL_SHADOW_SIZE;
        public double ShadowSize
        {
            get { return _shadowSize; }
            set { SetProperty(ref _shadowSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時計半径
        /// </summary>
        private double _clockBoardRadius = ConstantData.ORIGINAL_CLOCK_LENGTH / 2;
        public double ClockBoardRadius
        {
            get { return _clockBoardRadius; }
            set { SetProperty(ref _clockBoardRadius, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針のサイズ
        /// </summary>
        private Size _secondHandSize = new Size(ConstantData.ORIGINAL_SECOND_HAND_WIDTH, ConstantData.ORIGINAL_SECOND_HAND_LENGTH);
        public Size SecondHandSize
        {
            get { return _secondHandSize; }
            set { SetProperty(ref _secondHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の長さ
        /// </summary>
        private Size _minuteHandSize = new Size(ConstantData.ORIGINAL_MINUTE_HAND_WIDTH, ConstantData.ORIGINAL_MINUTE_HAND_LENGTH);
        public Size MinuteHandSize
        {
            get { return _minuteHandSize; }
            set { SetProperty(ref _minuteHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の長さ
        /// </summary>
        private Size _hourHandSize = new Size(ConstantData.ORIGINAL_HOUR_HAND_WIDTH, ConstantData.ORIGINAL_HOUR_HAND_LENGTH);
        public Size HourHandSize
        {
            get { return _hourHandSize; }
            set { SetProperty(ref _hourHandSize, value); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の角度
        /// </summary>
        public double SecondHandAngle
        {
            get { return TimeUtility.GetSecondAngle(); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の角度
        /// </summary>
        public double MinuteHandAngle
        {
            get { return TimeUtility.GetMinuteAngle(); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の角度
        /// </summary>
        public double HourHandAngle
        {
            get { return TimeUtility.GetHourAngle(); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 秒針の縦位置オフセット
        /// </summary>
        public double SecondHandYOffset
        {
            /// 上方向に、秒針の長さの4割の長さだけ移動
            get { return -this.SecondHandSize.Height * 0.4; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 分針の縦位置オフセット
        /// </summary>
        public double MinuteHandYOffset
        {
            get { return -this.MinuteHandSize.Height * 0.4; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// 時針の縦位置オフセット
        /// </summary>
        public double HourHandYOffset
        {
            get { return -this.HourHandSize.Height * 0.4; }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// ハルマゲドンモード時の表示状態
        /// </summary>
        public Visibility ArmageddonModeVisibility
        {
            get { return (this.armageddonMode ? Visibility.Visible : Visibility.Hidden); }
        }

        /// <summary>
        /// 【Binding用プロパティ】
        /// ハルマゲドンのクールダウンタイム終了時刻
        /// </summary>
        public string CoolDownEndTime
        {
            get { return armageddonCoolDownEndTime.ToString("HH:mm:ss"); }
        }

        #endregion

        #region Binding用コマンド

        /// <summary>
        /// 【Binding用コマンド】
        /// 基本サイズに対するコントロールの大きさ比
        /// </summary>
        private double _controlSizeRate = 1.0;
        public double ControlSizeRate
        {
            get { return _controlSizeRate; }
            set { SetProperty(ref _controlSizeRate, value); }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// 終了コマンド
        /// </summary>
        public ICommand ClosingCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    App.Current.MainWindow.Close();
                });
            }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// ヘルプを表示する
        /// </summary>
        public ICommand ShowHelp
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessageBox.Show(
                        ConstantData.HELP_MESSAGE,
                        "ヘルプ",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                });
            }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// 作成者情報を表示する
        /// </summary>
        public ICommand ShowCreator
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessageBox.Show(
                        ConstantData.CREATOR_INFO,
                        "作成者について",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                });
            }
        }

        /// <summary>
        /// 【Binding用コマンド】
        /// ハルマゲドンモードのオン・オフを切り替える
        /// </summary>
        public ICommand ArmageddonButtonCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (this.armageddonMode)
                    {
                        // ハルマゲドンモードを解除したい
                        MessageBoxResult mbResult = MessageBox.Show(
                            "ハルマゲドンモードを解除しますか？",
                            "ハルマゲドンモード解除の確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                        if (mbResult == MessageBoxResult.Yes)
                        {
                            this.armageddonMode = false;
                        }
                    }
                    else
                    {
                        // ハルマゲドンモードにする
                        MessageBox.Show("魔界殲滅戦争！");
                        this.armageddonCoolDownEndTime = DateTime.Now.AddSeconds(ConstantData.COOL_DOWN_TIME_SECOND);
                        this.armageddonMode = true;
                        RaisePropertyChanged(nameof(CoolDownEndTime));
                    }
                    RaisePropertyChanged(nameof(ArmageddonModeVisibility));
                });
            }
        }

        // Binding用のプロパティ・コマンドは以上。

        #endregion

        /// <summary>
        /// 時刻更新監視タイマー
        /// </summary>
        private DispatcherTimer timeUpdatingTimer;

        /// <summary>
        /// 魔界殲滅戦争モード
        /// true: オン
        /// false: オフ
        /// </summary>
        private bool armageddonMode = false;

        /// <summary>
        /// クールダウンが終わる時刻
        /// </summary>
        private DateTime armageddonCoolDownEndTime;

        /// <summary>
        /// コンストラクタ
        /// ・プロパティ初期化
        /// </summary>
        public MainViewModel()
        {
            this.NumberPositionOffsetArray = new Point[12];
            this.SecondScaleAngleArray = new double[60];

            this.timeUpdatingTimer = new DispatcherTimer();
            this.timeUpdatingTimer.Interval = TimeSpan.FromMilliseconds(200);
            this.timeUpdatingTimer.Tick += (object sender, EventArgs e) =>
            {
                RaisePropertyChanged(nameof(HourHandAngle));
                RaisePropertyChanged(nameof(MinuteHandAngle));
                RaisePropertyChanged(nameof(SecondHandAngle));
                RaisePropertyChanged(nameof(CoolDownEndTime));
            };
            this.timeUpdatingTimer.Start();

            this.LocateControls();
        }

        /// <summary>
        /// デストラクタ。
        /// ・時刻監視タイマーの停止
        /// </summary>
        ~MainViewModel()
        {
            this.timeUpdatingTimer.Stop();
        }
        
        /// <summary>
        /// 固定位置のコントロールのサイズ・配置関係の設定を行う。
        /// 対象のコントロール：
        ///   ・文字盤
        ///   ・縁
        ///   など
        /// </summary>
        private void LocateControls()
        {
            /// 定数 π÷6
            const double PI_OVER_6 = Math.PI / 6.0;

            /// 数字半径設定
            const double NUMBER_POSITION_RATE = 1.05;   //秒目盛り無し → 1.12
            /// 文字盤の数字を示すテキストブロックの位置を調整する。初期位置は文字盤の中心になっている。
            for (int i = 0; i < 12; i++)
            {
                this.NumberPositionOffsetArray[i].X =  Math.Sin((i + 1) * PI_OVER_6) * (this.ClockBoardRadius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE) * NUMBER_POSITION_RATE;
                this.NumberPositionOffsetArray[i].Y = -Math.Cos((i + 1) * PI_OVER_6) * (this.ClockBoardRadius - ConstantData.ORIGINAL_NUMBER_FONT_SIZE) * NUMBER_POSITION_RATE;
            }

            /// 秒目盛りオフセット位置設定
            SecondScalePositionOffset = new Point(0, -(this.ClockBoardRadius - ConstantData.ORIGINAL_SECOND_SCALE_LENGTH / 2.0));
            SecondScalePositionOffset5 = new Point(0, -(this.ClockBoardRadius - ConstantData.ORIGINAL_SECOND_SCALE_LENGTH * ConstantData.ORIGINAL_5SECOND_SCALE_SIZE_RATE / 2.0));
            /// 秒目盛り角度設定
            for (int i = 0; i < 60; i++)
            {
                SecondScaleAngleArray[i] = i * 6.0;    // ⇔ i*360/60
            }
        }
    }
}
