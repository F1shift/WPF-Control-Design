using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonDesign
{
    /// <summary>
    /// NavigateButton.xaml 的互動邏輯
    /// </summary>
    public partial class NavigateButton : Button
    {
        public static readonly DependencyProperty OuterStrokeThicknessProperty =
            DependencyProperty.Register("OuterStrokeThickness", typeof(double), typeof(NavigateButton)
                );

        public double OuterStrokeThickness
        {
            get { return (double)this.GetValue(OuterStrokeThicknessProperty); }
            set { this.SetValue(OuterStrokeThicknessProperty, value); }
        }

        public NavigateButton()
        {
            InitializeComponent();
        }
    }
}
