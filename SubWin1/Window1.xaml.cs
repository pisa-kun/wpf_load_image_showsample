using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SubWin1
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            GetImage();
        }

        private bool GetImage()
        {
            try
            {
                var target = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var resource1 = Path.Combine(target, @"python.jpg");
                this.image1.Source = BitmapFromFilePath(resource1);
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
