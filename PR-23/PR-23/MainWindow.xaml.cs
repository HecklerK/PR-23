using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Drawing;
using System.IO;

namespace PR_23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap BitmapImage2Bitmap()
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)P1.Source));
                enc.Save(outStream);
                Bitmap bmp = new Bitmap(outStream);
                return new Bitmap(bmp);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.DefaultExt = ".jpg";
            fd.Filter = "Изображение (*.BMP, *.JPG, *.GIF, *.PNG)|*.bmp; *.jpg; *.gif; *.png";
            var result = fd.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    BitmapImage bm1 = new BitmapImage();
                    bm1.BeginInit();
                    bm1.UriSource = new Uri(fd.FileName, UriKind.Relative);
                    bm1.CacheOption = BitmapCacheOption.OnLoad;
                    bm1.EndInit();
                    P1.Source = bm1;
                    L1.Content = "Пользовательское изображение";
                    SA.IsEnabled = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    break;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/evrope.jpg", UriKind.Relative));
            L1.Content = "Европа";
            SA.IsEnabled = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void SA_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = "Изображение";
            sd.Title = "Сохранить картинку как...";
            sd.OverwritePrompt = true;
            sd.CheckPathExists = true;
            sd.DefaultExt = ".jpg";
            sd.Filter = "Bitmap File(*.bmp)|*.bmp|" + "JPEG File(*.JPG)|*.jpg|" + "GIF File(*.GIF)|*.gif|" + "PNG File(*.PNG)|*.png";
            var result = sd.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    Bitmap bmp = BitmapImage2Bitmap();
                    string fn = sd.FileName;
                    string sfe = fn.Remove(0, fn.Length - 3);
                    switch (sfe)
                    {
                        case "bmp":
                            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "png":
                            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    break;
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/asia.jpg", UriKind.Relative));
            L1.Content = "Азия";
            SA.IsEnabled = true;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/afrika.jpg", UriKind.Relative));
            L1.Content = "Африка";
            SA.IsEnabled = true;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/sa.jpg", UriKind.Relative));
            L1.Content = "Северная Америка";
            SA.IsEnabled = true;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/ua.jpg", UriKind.Relative));
            L1.Content = "Южная Америка";
            SA.IsEnabled = true;
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            P1.Source = new BitmapImage(new Uri("Resource/a.jpg", UriKind.Relative));
            L1.Content = "Австралия";
            SA.IsEnabled = true;
        }
    }
}
