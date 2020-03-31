using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Horience.Core.Api.Colors
{
    class ColorHelper
    {
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

        public int FindMaxValue(List<int> list)
        {
            int MaxValue = 0;

            foreach (int val in list)
            {
                if (val > MaxValue) MaxValue = val;
            }

            return MaxValue;
        }

        public Color BrushToColor(Brush from)
        {
            if (from is SolidColorBrush toColor)
            {
                return toColor.Color;
            }

            return Color.FromRgb(0, 0, 0);
        }
    }
}
