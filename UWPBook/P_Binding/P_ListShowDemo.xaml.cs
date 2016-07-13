using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace UWPBook.P_Binding
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class P_ListShowDemo : Page
    {
        public ObservableCollection<Person> Persons { get; set; }
        public P_ListShowDemo()
        {
            LoadData();

            this.InitializeComponent();
        }
       
        private void LoadData()
        {
            Persons = new ObservableCollection<Person>();
            
            Persons.Add(new Person { Name = "zhangsan", Age = 18, Sex = true });
            Persons.Add(new Person { Name = "lucy", Age = 8, Sex = false });
            Persons.Add(new Person { Name = "jim", Age = 22, Sex = true });
        }
    }    
}
