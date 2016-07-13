using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace UWPBook
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void toasttext1_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastxml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            XmlNodeList elements = toastxml.GetElementsByTagName("text");
            elements[0].AppendChild(toastxml.CreateTextNode("heoole win10 mobile"));
            ToastNotification toast = new ToastNotification(toastxml);
            //绑定事件
            toast.Activated += Toast_Activated;
            toast.Dismissed += Toast_Dismissed;
            toast.Failed += Toast_Failed;
            
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private async void Toast_Failed(ToastNotification sender, ToastFailedEventArgs args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                txtInfo.Text = "Failed---" + args.ErrorCode.Message;
            });
        }

        private async void Toast_Dismissed(ToastNotification sender, ToastDismissedEventArgs args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                txtInfo.Text = "dismissed---" + args.Reason.ToString();
            });
        }

        private async void Toast_Activated(ToastNotification sender, object args)
        {
            //txtInfo.Text = "activated";
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {

                txtInfo.Text = "activated";
            });

        }

        private void toasttext2_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastxml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            XmlNodeList elements = toastxml.GetElementsByTagName("text");
            elements[0].AppendChild(toastxml.CreateTextNode("win10"));
            elements[1].AppendChild(toastxml.CreateTextNode("i love your"));
            ToastNotification toast = new ToastNotification(toastxml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        public int num = 0;
        private void toasttext3_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument toastxml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            XmlNodeList elements = toastxml.GetElementsByTagName("text");
            elements[0].AppendChild(toastxml.CreateTextNode("zlm"));
            elements[1].AppendChild(toastxml.CreateTextNode("ztj love you,time=" + num));
            DateTime startTime = DateTime.Now.AddSeconds(3);


            ScheduledToastNotification recurringToast = new ScheduledToastNotification(toastxml, startTime, TimeSpan.FromMinutes(1), 5);
            recurringToast.Id = "scheduleToast1";
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(recurringToast);
        }
        private string titleId = "001";
        private async void metroc_Click(object sender, RoutedEventArgs e)
        {
            if (SecondaryTile.Exists(titleId))
            {
                SecondaryTile secondaryTitle = new SecondaryTile(titleId);
                bool isUnpinned = await secondaryTitle.RequestDeleteAsync();
                if (isUnpinned)
                {
                    metroc.Content = "创建一个磁贴";
                    await new MessageDialog("取消成功").ShowAsync();
                    return;
                }
            }
            Uri square71_71Logo = new Uri("ms-appx:///Assets/Square71x71Logo.scale-100.png");
            Uri square150_150Logo = new Uri("ms-appx:///Assets/Square150x150Logo.scale-100.png");
            Uri square310_150Logo = new Uri("ms-appx:///Assets/Wide310x150Logo.scale-100.png");
            //创建一个磁贴对象
            SecondaryTile secondaryTile = new SecondaryTile(titleId, "mytitle,这是显示的名字", DateTime.Now.ToString()+"这个是创建的参数", square150_150Logo, TileSize.Square150x150);
            //设置logo所对应的logo地址
            secondaryTile.VisualElements.Wide310x150Logo = square310_150Logo;
            secondaryTile.VisualElements.Square150x150Logo = square150_150Logo;
            secondaryTile.VisualElements.Square71x71Logo = square71_71Logo;
            //显示磁贴名字
            //secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            //是否显示磁贴的展示名
            //secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            //secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;
            //创建磁贴
            bool isPinned = await secondaryTile.RequestCreateAsync();//???
            if (isPinned)
            {
                txtInfo.Text = "title create success";
                metroc.Content = "删除这个磁贴";
            }

        }    
        //进入当前页面事件的处理程序    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (SecondaryTile.Exists(titleId))
            {
                metroc.Content = "取消磁贴";
            }
            else
            {
                metroc.Content = "创建一个磁贴";
            }
            //获取页面传递过来的参数，从磁贴开来可以通过这种方式获取其参数
            if (e.Parameter != null)
            {
                txtInfo.Text = e.Parameter.ToString();
            }
        }

        private async void metrou_Click(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<SecondaryTile> titleList = await SecondaryTile.FindAllAsync();
            foreach (var item in titleList)
            {
                SecondaryTile secondaryTitle = new SecondaryTile(item.TileId);
                secondaryTitle.Arguments = "Updated Arguments(TileId:" + item.TileId + ")";
                secondaryTitle.VisualElements.Square310x310Logo = new Uri("ms-appx:///Images/widelong.jpg");

                //更新磁贴
                bool success = await secondaryTitle.UpdateAsync();
                await new MessageDialog(item.TileId + "update success").ShowAsync();

            }
        }

        private async void metron_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument wideTitleXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150IconWithBadgeAndText);
            XmlNodeList wideTileTextAttributes = wideTitleXml.GetElementsByTagName("text");
            wideTileTextAttributes[0].AppendChild(wideTitleXml.CreateTextNode("hello"));
            wideTileTextAttributes[1].AppendChild(wideTitleXml.CreateTextNode("windows 10 mobile"));
            XmlNodeList wideTileImageAttributes = wideTitleXml.GetElementsByTagName("image");
            ((XmlElement)wideTileImageAttributes[0]).SetAttribute("src", "ms-appx:///Images/startcraft.jpg");

            TileNotification wideTitleNotification = new TileNotification(wideTitleXml);
            wideTitleNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);

            TileUpdateManager.CreateTileUpdaterForApplication(titleId).Update(wideTitleNotification);
            await new MessageDialog("更新磁贴通知成功").ShowAsync();
        }
        //获取磁贴按钮事件处理程序
        private async void metrog_Click(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<SecondaryTile> titleList = await SecondaryTile.FindAllAsync();
            txtInfo.Text = "应用程序全部SecondaryTile的tileId列表：";
            foreach (var item in titleList)
            {
                txtInfo.Text += item.TileId + "-->";
            }
        }
        

    }
}
