using System;
using System.Windows;
using System.Windows.Controls;

namespace Tetris.Controls
{
    public class SplashProgressBar : Control
    {
        static SplashProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SplashProgressBar),
                new FrameworkPropertyMetadata(typeof(SplashProgressBar)));
        }

        public SplashProgressBar()
        {
            SizeChanged += (_, __) => UpdateProgressWidth();
        }

        #region Value

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(SplashProgressBar),
                new PropertyMetadata(0d, OnProgressChanged));

        #endregion

        #region Minimum

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(
                nameof(Minimum),
                typeof(double),
                typeof(SplashProgressBar),
                new PropertyMetadata(0d, OnProgressChanged));

        #endregion

        #region Maximum

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(SplashProgressBar),
                new PropertyMetadata(100d, OnProgressChanged));

        #endregion

        #region IsReversed

        public bool IsReversed
        {
            get => (bool)GetValue(IsReversedProperty);
            set => SetValue(IsReversedProperty, value);
        }

        public static readonly DependencyProperty IsReversedProperty =
            DependencyProperty.Register(
                nameof(IsReversed),
                typeof(bool),
                typeof(SplashProgressBar),
                new PropertyMetadata(false));

        #endregion

        private static readonly DependencyPropertyKey ProgressWidthPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ProgressWidth),
                typeof(double),
                typeof(SplashProgressBar),
                new PropertyMetadata(0d));

        public static readonly DependencyProperty ProgressWidthProperty =
            ProgressWidthPropertyKey.DependencyProperty;

        public double ProgressWidth
        {
            get => (double)GetValue(ProgressWidthProperty);
            private set => SetValue(ProgressWidthPropertyKey, value);
        }

        private static void OnProgressChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            ((SplashProgressBar)d).UpdateProgressWidth();
        }

        private void UpdateProgressWidth()
        {
            if (Maximum <= Minimum)
            {
                ProgressWidth = 0;
                return;
            }

            double percent = (Value - Minimum) / (Maximum - Minimum);
            percent = Math.Max(0, Math.Min(1, percent));

            ProgressWidth = ActualWidth * percent;
        }
    }
}
