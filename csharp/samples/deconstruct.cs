using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace type.samples
{
    internal class Deconstruct
    {
        public class RectangleSample
        {
            public readonly float Width, Height;

            public RectangleSample(float width, float height)
            {
                Width = width;
                Height = height;
            }

            //This help to deconstruct
            public void Deconstruct(out float width, out float height)
            {
                width = Width;
                height = Height;
            }
        }
    }
}
