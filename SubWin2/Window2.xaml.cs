using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


namespace SubWin2
{
    /// <summary>
    /// Window2.xaml の相互作用ロジック
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            GetImage();
        }

        private bool GetImage()
        {
            try
            {
                var target = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var resource2 = Path.Combine(target, @"golang.png");
                this.image2.Source = BitmapFromFilePath(resource2);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Bitmapを作るよ
        /// </summary>
        /// <param name="path"></param>
        private BitmapImage BitmapFromFilePath(string path)
        {
            BitmapImage bitmap = new BitmapImage(); // デコードされたビットマップイメージのインスタンスを作る。
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path); // ビットマップイメージのソースにファイルを指定する。
            bitmap.EndInit();
            return bitmap;

        }
    }
}
