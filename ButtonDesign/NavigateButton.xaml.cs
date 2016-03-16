using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        #region FrameworkPropertyMetadata
        private static FrameworkPropertyMetadata MouseOverMaskColorPropertyMetaData =
            new FrameworkPropertyMetadata(
                new SolidColorBrush(Color.FromArgb(40,150,210,255)),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                null,
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata PressedMaskColorPropertyMetaData =
            new FrameworkPropertyMetadata(
                new SolidColorBrush(Color.FromArgb(80, 0, 0, 0)),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                null,
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata OuterStrokeThicknessRatioPropertyMetaData =
            new FrameworkPropertyMetadata(
                0.1,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(OuterStrokeThicknessRatioChanged_Callback),
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata InnerStrokeThicknessRatioPropertyMetaData =
            new FrameworkPropertyMetadata(
                0.12,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(InnerStrokeThicknessRatioChanged_Callback),
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata OuterStrokeThicknessPropertyMetaData =
            new FrameworkPropertyMetadata(
                10.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(OuterStrokeThicknessChanged_Callback),
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata InnerStrokeThicknessPropertyMetaData =
            new FrameworkPropertyMetadata(
                10.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(InnerStrokeThicknessChanged_Callback),
                null,
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        #endregion

        #region DependencyProperty
        public static readonly DependencyProperty MouseOverMaskColorProperty =
            DependencyProperty.Register(
                "MouseOverMaskColor",
                typeof(Brush),
                typeof(NavigateButton),
                MouseOverMaskColorPropertyMetaData
                );
        public static readonly DependencyProperty PressedMaskColorProperty =
            DependencyProperty.Register(
                "PressedMaskColor",
                typeof(Brush),
                typeof(NavigateButton),
                PressedMaskColorPropertyMetaData
                );
        public static readonly DependencyProperty OuterStrokeThicknessRatioProperty =
            DependencyProperty.Register(
                "OuterStrokeThicknessRatio",
                typeof(double),
                typeof(NavigateButton),
                OuterStrokeThicknessRatioPropertyMetaData,
                new ValidateValueCallback(UIDimentionValidate)
                );
        public static readonly DependencyProperty InnerStrokeThicknessRatioProperty =
            DependencyProperty.Register(
                "InnerStrokeThicknessRatio",
                typeof(double),
                typeof(NavigateButton),
                InnerStrokeThicknessRatioPropertyMetaData,
                new ValidateValueCallback(UIDimentionValidate)
                );
        public static readonly DependencyProperty OuterStrokeThicknessProperty =
            DependencyProperty.Register(
                "OuterStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                OuterStrokeThicknessPropertyMetaData,
                new ValidateValueCallback(UIDimentionValidate)
                );
        public static readonly DependencyProperty InnerStrokeThicknessProperty =
            DependencyProperty.Register(
                "InnerStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                InnerStrokeThicknessPropertyMetaData,
                new ValidateValueCallback(UIDimentionValidate)
                );
        #endregion

        #region CLR Property to wrap the dependency property
        public Brush MouseOverMaskColor
        {
            get { return (Brush)this.GetValue(MouseOverMaskColorProperty); }
            set { this.SetValue(MouseOverMaskColorProperty, value); }
        }

        public Brush PressedMaskColor
        {
            get { return (Brush)this.GetValue(PressedMaskColorProperty); }
            set { this.SetValue(PressedMaskColorProperty, value); }
        }

        public double OuterStrokeThicknessRatio
        {
            get { return (double)this.GetValue(OuterStrokeThicknessRatioProperty); ; }
            set { this.SetValue(OuterStrokeThicknessRatioProperty, value); }
        }

        public double InnerStrokeThicknessRatio
        {
            get { return (double)this.GetValue(InnerStrokeThicknessRatioProperty); }
            set { this.SetValue(InnerStrokeThicknessRatioProperty, value); }
        }

        public double OuterStrokeThickness
        {
            get { return (double)this.GetValue(OuterStrokeThicknessProperty); ; }
            set { this.SetValue(OuterStrokeThicknessProperty, value); }
        }

        public double InnerStrokeThickness
        {
            get { return (double)this.GetValue(InnerStrokeThicknessProperty); }
            set { this.SetValue(InnerStrokeThicknessProperty, value); }
        }
        #endregion CLR Property to wrap the dependency property

        #region dependency property callback
        public static void OuterStrokeThicknessRatioChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigateButton nbt = (NavigateButton)d;
            nbt.OuterStrokeThickness = (double)e.NewValue * nbt.ActualHeight;
        }

        public static void InnerStrokeThicknessRatioChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigateButton nbt = (NavigateButton)d;
            nbt.InnerStrokeThickness = (double)e.NewValue * nbt.ActualHeight;
        }

        private static void OuterStrokeThicknessChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigateButton nbt = (NavigateButton)d;
            if (nbt.ActualHeight != 0)
                nbt.OuterStrokeThicknessRatio = (double)e.NewValue / nbt.ActualHeight;
        }

        private static void InnerStrokeThicknessChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigateButton nbt = (NavigateButton)d;
            if (nbt.ActualHeight != 0)
                nbt.InnerStrokeThicknessRatio = (double)e.NewValue / nbt.ActualHeight;
        }
        #endregion dependency property callback

        #region dependency property validate
        public static bool UIDimentionValidate(object o)
        {
            return Convert.ToDouble(o) >= 0;
        }
        #endregion dependency property validate

        public NavigateButton()
            : base()
        {
            SizeChanged += NavigateButton_SizeChanged;
            InitializeComponent();
        }

        private void NavigateButton_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            NavigateButton nbt = (NavigateButton)sender;
            nbt.OuterStrokeThickness = nbt.OuterStrokeThicknessRatio * nbt.ActualHeight;
            nbt.InnerStrokeThickness = nbt.InnerStrokeThicknessRatio * nbt.ActualHeight;
        }
    }
}
