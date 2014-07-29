using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{

    public class ThumbnailGenerator
    {

        private double _imageWidth;
        private double _imageHeight;
        private double _destWidth;
        private double _destHeight;

        public ThumbnailGenerator(int imageWidth, int imageHeight, int destWidth, int destHeight)
        {
            _imageHeight = imageHeight;
            _imageWidth = imageWidth;
            _destHeight = destHeight;
            _destWidth = destWidth;
            UpdateResults();
        }

        private void UpdateResults()
        {
            //System.Diagnostics.Debugger.Launch();
            
            double imageRatio = _imageHeight / _imageWidth;
            double destinationRatio = _destHeight / _destWidth;
            if (destinationRatio > imageRatio)
            {
                ThumbnailHeight = (int)Math.Floor(_destWidth * imageRatio);
                ThumbnailWidth = (int)Math.Floor(_destWidth);
            }
            else if (destinationRatio == imageRatio)
            {
                ThumbnailHeight = (int)Math.Floor(_destHeight);
                ThumbnailWidth = (int)Math.Floor(_destWidth);
            }
            else
            {
                ThumbnailHeight = (int)Math.Floor(_destHeight);
                ThumbnailWidth = (int)Math.Floor(_destHeight / imageRatio);
            }
            ThumbnailVerticalOffset = (int)Math.Floor((_destHeight - ThumbnailHeight) / 2.0);
            ThumbnailHorizontalOffset = (int)Math.Floor((_destWidth - ThumbnailWidth) / 2.0);
        }

        public int ThumbnailHeight { get; private set; }
        public int ThumbnailWidth { get; private set; }
        public int ThumbnailVerticalOffset { get; private set; }
        public int ThumbnailHorizontalOffset { get; private set; }

    }

}
