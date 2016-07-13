using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace UWPBook.P_File
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class P_FileBase : Page
    {
        public P_FileBase()
        {
            this.InitializeComponent();
        }
        StorageFolder folder = ApplicationData.Current.LocalFolder;

        private async void btnSet_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file= await folder.CreateFileAsync("test.txt", CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                using (var write = new StreamWriter(stream))
                {
                    await write.WriteAsync(txtContent.Text);                    
                }
            }
            //await FileIO.WriteTextAsync(file, txtContent);    读取小型数据时可以使用FileIO对象
            await new MessageDialog("ok").ShowAsync();
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await folder.CreateFileAsync("test.txt", CreationCollisionOption.OpenIfExists);
            using(Stream stream=await file.OpenStreamForReadAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    txtContent.Text = reader.ReadToEnd();
                }
            }
            await new MessageDialog("read ok").ShowAsync();
        }
    }
}
