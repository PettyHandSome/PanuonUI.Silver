﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Children))]
    public class Carousel : Control
    {
        private StackPanel _stackPanel;

        static Carousel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Carousel), new FrameworkPropertyMetadata(typeof(Carousel)));
        }

        public Carousel() : base()
        {
            Children = new ObservableCollection<UIElement>();
            Loaded += Carousel_Loaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _stackPanel = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 0) as StackPanel;
        }

        private void Carousel_Loaded(object sender, RoutedEventArgs e)
        {
            if (Children == null)
                return;

            foreach (FrameworkElement child in Children)
            {
                child.Width = ActualWidth;
                child.Height = ActualHeight;
            }
        }

        #region Property
        /// <summary>
        /// get the children collection.
        /// </summary>
        public ObservableCollection<UIElement> Children
        {
            get { return (ObservableCollection<UIElement>)GetValue(ChildrenProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(ObservableCollection<UIElement>), typeof(Carousel));

        /// <summary>
        /// get or set orientation
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Carousel), new PropertyMetadata(Orientation.Horizontal));

        /// <summary>
        /// get or set index
        /// </summary>
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(Carousel), new PropertyMetadata(0, OnIndexChanged));

        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var carousel = d as Carousel;
            if (!carousel.IsLoaded)
                return;

            var targetIndex = 0;
            if(!carousel.Recyclable)
                targetIndex = carousel.Index > (carousel.Children.Count - 1) ? carousel.Children.Count - 1 : (carousel.Index < 0 ? 0 : carousel.Index);
            else
                targetIndex = carousel.Index > (carousel.Children.Count - 1) ? 0 : (carousel.Index < 0 ? carousel.Children.Count - 1 : carousel.Index);

            if(targetIndex != carousel.Index)
            {
                carousel.Index = targetIndex;
                return;
            }

            if (carousel.Orientation == Orientation.Vertical)
            {
                carousel._stackPanel.BeginAnimation(StackPanel.MarginProperty, new ThicknessAnimation()
                {
                    To = new Thickness(0, -1 * carousel.ActualHeight * carousel.Index, 0, 0),
                    Duration = carousel.AnimateDuration,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                });
            }
            else
            {
                carousel._stackPanel.BeginAnimation(StackPanel.MarginProperty, new ThicknessAnimation()
                {
                    To = new Thickness(-1 * carousel.ActualWidth * carousel.Index, 0, 0, 0),
                    Duration = carousel.AnimateDuration,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                });
            }
        }

        /// <summary>
        /// 获取或设置滑动动画的持续时间。默认为0.5秒。
        /// </summary>
        public TimeSpan AnimateDuration
        {
            get { return (TimeSpan)GetValue(AnimateDurationProperty); }
            set { SetValue(AnimateDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimateDurationProperty =
            DependencyProperty.Register("AnimateDuration", typeof(TimeSpan), typeof(Carousel), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));

        /// <summary>
        /// 获取或设置当滑动到最后一页（或第一页）时，是否允许回滚到第一页（或最后一页）。默认为False。
        /// </summary>
        public bool Recyclable
        {
            get { return (bool)GetValue(RecyclableProperty); }
            set { SetValue(RecyclableProperty, value); }
        }

        public static readonly DependencyProperty RecyclableProperty =
            DependencyProperty.Register("Recyclable", typeof(bool), typeof(Carousel), new PropertyMetadata(false));

        #endregion

        #region Function

        #endregion
    }
}
