using System.Collections.Generic;
using System.Drawing;

namespace ConvertVectorIntoImage
{
    public interface IImageConverter
    {
        void ConvertImage(List<Point> arrayOfPoints);
    }
}
