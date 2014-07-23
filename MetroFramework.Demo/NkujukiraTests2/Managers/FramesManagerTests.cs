using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using NkujukiraTests2.Singleton;
namespace Nkujukira.Tests
{
    [TestClass()]
    public class FramesManagerTests
    {
        

        [TestMethod()]
        public void FramesManagerGetNextFrameTest()
        {
           
            Image<Bgr, byte> image = FramesManager.GetNextFrame(new Capture());
            Assert.IsNotNull(image);
        }

        [TestMethod()]
        public void FramesManagerResizeImageTest()
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>(new Bitmap(100, 100));
            Size new_size = new Size(10, 10);
            image = FramesManager.ResizeColoredImage(image, new_size);
            Assert.IsNotNull(image);
        }

        [TestMethod()]
        public void FramesManagerResizeGrayImageTest()
        {
            Image<Gray, byte> image = new Image<Gray, byte>(new Bitmap(100, 100));
            image = FramesManager.ResizeGrayImage(image, new Size( 10, 10));
            Assert.IsNotNull(image);
        }

        [TestMethod()]
        public void FramesManagerPerformSeekOperationInVideoTest()
        {
            bool sucess=FramesManager.PerformSeekOperationInVideo(100, new Capture(Singleton.VIDEO_FILE_PATH));
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void FramesManagerDetectFacesInFrameTest()
        {

            Rectangle[] faces= FramesManager.DetectFacesInFrame(Singleton.FACE_PIC,Singleton.HAARCASCADE);
            
            //THE METHOD MUST DETECT A FACE IN THE PROVIDED PIC
            Assert.IsTrue(faces.Length>=1);
        }

        [TestMethod()]
        public void FramesManagerDrawShapeAroundDetectedFacesTest()
        {
            
            Rectangle[] faces = FramesManager.DetectFacesInFrame(Singleton.FACE_PIC, Singleton.HAARCASCADE);
            bool sucess;
            FramesManager.DrawShapeAroundDetectedFaces(faces[0], Singleton.FACE_PIC,out  sucess);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void FramesManagerDrawShapeOnTransparentBackGroundTest()
        {
           
            Point starting_cordinate=new Point(10,10);
            Size size=new Size(10,10);
            Rectangle rec=new Rectangle(starting_cordinate,size);
            Bitmap bitmap=FramesManager.DrawShapeOnTransparentBackGround(rec, 100, 100);
            Assert.IsNotNull(bitmap);
        }

        [TestMethod()]
        public void FramesManagerOverLayBitmapToFormNewImageTest()
        {
            Point starting_cordinate=new Point(10,10);
            Size size=new Size(10,10);
            Rectangle rec=new Rectangle(starting_cordinate,size);
            Bitmap bitmap=FramesManager.DrawShapeOnTransparentBackGround(rec, 100, 100);
            Graphics graphics=Graphics.FromImage(bitmap);
            bool sucess=FramesManager.OverLayBitmapToFormNewImage(bitmap, graphics);
            Assert.IsTrue(sucess);
        }

        //MY ATTEMPTS TO TEST THIS METHOD THREW A EMGU.CV.UTIL EXCEPTION..SOMETHING TO DO WITH INITIALIZATION 
        //OF EMGU CV SO
        [TestMethod()]
        public void FramesManagerCropSelectedFaceTest()
        {
            
            Rectangle[] faces = FramesManager.DetectFacesInFrame(Singleton.FACE_PIC, Singleton.HAARCASCADE);
            //Image<Bgr, byte> image = Singleton.FACE_PIC.Clone();
            //Image<Bgr,byte> image_result=FramesManager.CropSelectedFace(faces[0], Singleton.FACE_PIC);
            //Assert.IsNotNull(image_result);
        }

        [TestMethod()]
        public void FramesManagerResizeBitmapTest()
        {
            Bitmap image = new Bitmap(100, 100);
            image = FramesManager.ResizeBitmap(image,new Size(10,10));
            Assert.IsNotNull(image);
        }
    }
}
