﻿using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TextBoxHelper
    {
        #region TextBoxStyle
        public static TextBoxStyle GetTextBoxStyle(DependencyObject obj)
        {
            return (TextBoxStyle)obj.GetValue(TextBoxStyleProperty);
        }

        public static void SetTextBoxStyle(DependencyObject obj, TextBoxStyle value)
        {
            obj.SetValue(TextBoxStyleProperty, value);
        }

        public static readonly DependencyProperty TextBoxStyleProperty =
            DependencyProperty.RegisterAttached("TextBoxStyle", typeof(TextBoxStyle), typeof(TextBoxHelper), new PropertyMetadata(TextBoxStyle.Standard));
        #endregion

        #region FocusedBorderBrush
        public static Brush GetFocusedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region FocusedShadowColor
        public static Color GetFocusedShadowColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(FocusedShadowColorProperty);
        }

        public static void SetFocusedShadowColor(DependencyObject obj, Color value)
        {
            obj.SetValue(FocusedShadowColorProperty, value);
        }

        public static readonly DependencyProperty FocusedShadowColorProperty =
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color), typeof(TextBoxHelper));

        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(TextBoxHelper));
        #endregion

        #region Watermark
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper));


        #endregion

        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(TextBoxHelper));
        #endregion
    }
}
