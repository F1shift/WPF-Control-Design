﻿using System;
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
        private static FrameworkPropertyMetadata OuterStrokeThicknessPropertyMetaData =
            new FrameworkPropertyMetadata(
                1.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(OuterStrokeThickness_PropertyChanged),
                new CoerceValueCallback(OuterStrokeThickness_CoerceValue),
                false,
                UpdateSourceTrigger.PropertyChanged
                );
        private static FrameworkPropertyMetadata InnerStrokeThicknessPropertyMetaData =
            new FrameworkPropertyMetadata(
                1.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                new PropertyChangedCallback(OuterStrokeThickness_PropertyChanged),
                new CoerceValueCallback(OuterStrokeThickness_CoerceValue),
                false,
                UpdateSourceTrigger.PropertyChanged
                );

        public static readonly DependencyProperty OuterStrokeThicknessProperty =
            DependencyProperty.Register(
                "OuterStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                OuterStrokeThicknessPropertyMetaData,
                new ValidateValueCallback(OuterStrokeThicknessValidate)
                );
        public static readonly DependencyProperty InnerStrokeThicknessProperty =
            DependencyProperty.Register(
                "InnerStrokeThickness",
                typeof(double),
                typeof(NavigateButton),
                InnerStrokeThicknessPropertyMetaData,
                new ValidateValueCallback(InnerStrokeThicknessValidate)
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

        public static void OuterStrokeThickness_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {

        }

        public static object OuterStrokeThickness_CoerceValue(DependencyObject dobj, object value)
        {
            return value;
        }

        public static bool OuterStrokeThicknessValidate(object o)
        {
            return Convert.ToDouble(o) >= 0;
        }

        public static void InnerStrokeThickness_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {

        }

        public static object InnerStrokeThickness_CoerceValue(DependencyObject dobj, object value)
        {
            return value;
        }

        public static bool InnerStrokeThicknessValidate(object o)
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
