using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace PhotoTimeSync.Specs
{
    [Binding]
    public class ThumbnailGenerationSteps
    {
        int ImageWidth, ImageHeight, DisplayWidth, DisplayHeight;
        ThumbnailGenerator gen;

        [Given(@"The image size is (.*) x (.*) pixels")]
        public void GivenTheImageSizeIsXPixels(int p0, int p1)
        {
            ImageWidth = p0;
            ImageHeight = p1;
        }

        [Given(@"The display size is (.*) x (.*) pixels")]
        public void GivenTheDisplaySizeIsXPixels(int p0, int p1)
        {
            DisplayWidth = p0;
            DisplayHeight = p1;
        }

        [When(@"The thumbnail generator is initialized")]
        public void WhenTheThumbnailGeneratorIsInitialized()
        {
            gen = new ThumbnailGenerator(ImageWidth, ImageHeight, DisplayWidth, DisplayHeight);
        }

        [Then(@"The thumbnail size is (.*) x (.*) pixels")]
        public void ThenTheThumbnailSizeIsXPixels(int p0, int p1)
        {
            Assert.AreEqual(p0, gen.ThumbnailWidth, "Unexpected Thumbnail Width");
            Assert.AreEqual(p1, gen.ThumbnailHeight, "Unexpected Thumbnail Height");
        }

        [Then(@"The thumnails offsets are (.*) pixels horizontally and (.*) pixels vertically")]
        public void ThenTheThumnailsOffsetsArePixelsHorizontallyAndPixelsVertically(int p0, int p1)
        {
            Assert.AreEqual(p0, gen.ThumbnailHorizontalOffset, "Unexpected Thumbnail Horizontal Offset");
            Assert.AreEqual(p1, gen.ThumbnailVerticalOffset, "Unexpected Thumbnail Vertical Offset");
        }
    }
}
