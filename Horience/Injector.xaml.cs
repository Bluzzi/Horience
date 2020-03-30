using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Horience.Core;

namespace Horience
{
    public partial class Injector : Window
    {
        public Injector()
        {
            InitializeComponent();
        }

        // Inject the cheat, this close injector window and open the panel with specified mode :

        private void Inject(object sender, RoutedEventArgs e)
        {
            // Get checkbox values :
            bool CheatBoxIsChecked = CheatCheckBox.IsChecked ?? false;
            bool UtilsBoxIsChecked = UtilsCheckBox.IsChecked ?? false;

            // Check if a checkbox is checked and create Main instance with the mode :
            if (CheatBoxIsChecked && UtilsBoxIsChecked)
            {
                new Main((int) Main.MODES.ALL);
            }
            else if (CheatBoxIsChecked)
            {
                new Main((int) Main.MODES.CHEAT);
            }
            else if (UtilsBoxIsChecked)
            {
                new Main((int) Main.MODES.UTILS);
            }
            else
            {
                ErrorLabel.Content = "Select a category !";
                return;
            }
            
            // Close this window :
            Close();
        }

        private void CheatCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Color toGo = Color.FromRgb(114, 18, 18);
        }

        private void CheatCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Color from = convert(CheatLabel.Foreground);
            Color to = Color.FromRgb(114, 18, 18);
            List<Color> colorList = GenerateGradientList(from, to);
            foreach(Color color in colorList)
            {
                CheatCheckBox.Foreground = new SolidColorBrush(color);
                Thread.Sleep(100);
            }
        }

        private List<Color> GenerateGradientList(Color from, Color to)
        {
            List<int> Values = new List<int>();

            int ToRMax = to.R;
            int ToGMax = to.G;
            int ToBMax = to.B;

            int FromRMax = from.R;
            int FromGMax = from.G;
            int FromBMax = from.B;

            Values.Add(ToRMax);
            Values.Add(ToGMax);
            Values.Add(ToBMax);

            Values.Add(FromRMax);
            Values.Add(FromGMax);
            Values.Add(FromBMax);

            List<Color> colorList = new List<Color>();

            for (int i = 0; i < FindMaxValue(Values); i++)
            {
                if (FromRMax != ToRMax)
                {
                    if (FromRMax < ToRMax)
                    {
                        FromRMax++;
                    }
                    else
                    {
                        FromRMax--;
                    }
                }

                if (FromGMax != ToGMax)
                {
                    if (FromGMax < ToGMax)
                    {
                        FromGMax++;
                    }
                    else
                    {
                        FromGMax--;
                    }
                }

                if (FromBMax != ToBMax)
                {
                    if (FromBMax < ToBMax)
                    {
                        FromBMax++;
                    }
                    else
                    {
                        FromBMax--;
                    }
                }

                colorList.Add(Color.FromRgb(Convert.ToByte(FromRMax), Convert.ToByte(FromGMax), Convert.ToByte(FromBMax)));
            }

            return colorList;
        }

        private int FindMaxValue(List<int> list)
        {
            int MaxValue = 0;

            foreach(int val in list)
            {
                if (val > MaxValue) MaxValue = val;
            }

            return MaxValue;
        }

        private Color convert(Brush from)
        {
            if (from is SolidColorBrush toColor)
            {
                return toColor.Color;
            }

            return Color.FromRgb(0, 0, 0);
        }
    }
}
