using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using SubWin1;
using SubWin2;

namespace MainWin
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TempMove();
        }

        string Path1 { get; set; }
        string Path2 { get; set; }

        /// <summary>
        /// tempフォルダにResourcesの画像をMoveする
        /// </summary>
        private void TempMove()
        {
            var currentD = Environment.CurrentDirectory;
            var file1 = @"python.jpg";
            var file2 = @"golang.png";

            var resource1 = Path.Combine(currentD, file1);
            var resource2 = Path.Combine(currentD, file2);

            var target = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if(!File.Exists(resource1) || !File.Exists(resource2))
            {
                MessageBox.Show(
                    "リソースファイルがないです",
                    "失敗!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            try
            {
                Path1 = Path.Combine(target, file1);
                Path2 = Path.Combine(target, file2);
                File.Copy(
                    resource1,
                    Path1,
                    true);

                File.Copy(
                    resource2,
                    Path2,
                    true);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Bitmapを作るよ
        /// 一つのクラスに持たせたほうがよさそう
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

        private void showsub1_Click(object sender, RoutedEventArgs e)
        {
            if(this.main.Source != null)
            {
                this.main.Source = null;
            }
            this.main.Source = BitmapFromFilePath(Path1);
            var subwin1 = new SubWin1.Window1();
            subwin1.ShowDialog();
        }

        private void showsub2_Click(object sender, RoutedEventArgs e)
        {
            if (this.main.Source != null)
            {
                this.main.Source = null;
            }
            this.main.Source = BitmapFromFilePath(Path2);
            var subwin2 = new SubWin2.Window2();
            subwin2.ShowDialog();
        }


    }
}
