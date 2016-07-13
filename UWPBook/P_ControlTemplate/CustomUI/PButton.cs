using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace UWPBook.P_ControlTemplate.CustomUI
{
    public sealed class PButton : Windows.UI.Xaml.Controls.Button
    {
        public PButton()
        {
            this.DefaultStyleKey = typeof(PButton);
        }
    }
}
