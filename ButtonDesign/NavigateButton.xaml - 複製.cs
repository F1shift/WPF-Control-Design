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
        private static FrameworkPropertyMetadata propertyMetaData =
            new FrameworkPropertyMetadata(
                1.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(StrokeThickness_PropertyChanged),
                new CoerceValueCallback(StrokeThickness_CoerceValue),
                false,
                UpdateSourceTrigger.PropertyChanged
                );

        public static readonly DependencyProperty OuterStrokeThicknessProperty =
            DependencyProperty.Register(
                "OuterStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                propertyMetaData,
                new ValidateValueCallback(StrokeThickness_Validate)
                );
        public static readonly DependencyProperty InnerStrokeThicknessProperty =
            DependencyProperty.Register(
                "InnerStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                propertyMetaData,
                new ValidateValueCallback(StrokeThickness_Validate)
                );

        public double OuterStrokeThickness
        {
            get { return (double)this.GetValue(OuterStrokeThicknessProperty); }
            set { this.SetValue(OuterStrokeThicknessProperty, value); }
        }

        public double InnerStrokeThickness
        {
            get { return (double)this.GetValue(InnerStrokeThicknessProperty); }
            set { this.SetValue(InnerStrokeThicknessProperty, value); }
        }

        public static void StrokeThickness_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {

        }

        public static object StrokeThickness_CoerceValue(DependencyObject dobj, object value)
        {
            return value;
        }

        public static bool StrokeThickness_Validate(object o)
        {
            return Convert.ToDouble(o) >= 0;
        }

        public NavigateButton()
            : base()
        {
            InitializeComponent();
        }
    }
}
