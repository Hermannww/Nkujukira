using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Entitities
{
    public class Camera : Entity
    {
        public int id { get; set; }
        public String name { get; set; }
        public Capture camera_capture { get; set; }
        public ImageBox camera_imagebox { get; set; }
        public String location { get; set; }
        public String recording_since { get; set; }
        public String filepath_to_footage { get; set; }
        public String ip_address { get; set; }

        public Camera()
        {
            id = 1;
            name = "Camera 1";
            location = "Main Entrance, School Of Computing, Block B";
            recording_since = "8:00 A.M";
            filepath_to_footage = "";
        }

        public Camera(int id, String name, String location, ImageBox cam_imagebox)
        {
            this.id = id;
            this.name = name;
            this.location = location;
            this.camera_imagebox = camera_imagebox;
            
        }

        public Camera(int id, String name, ImageBox cam_imagebox)
        {
            this.id = id;
            this.name = name;
            this.camera_imagebox = cam_imagebox;
            camera_capture = new Capture("http://192.168.42.129:8080/video?x.mjpeg");
        }

        public Camera(String ip_adress,int id, String name, ImageBox cam_imagebox)
        {
            this.id = id;
            this.name = name;
            this.ip_address = ip_adress;
            this.camera_imagebox = cam_imagebox;
            camera_capture = new Capture("http://192.168.42.129:8080/video?x.mjpeg");
           
        }

        public bool InitializeCameraCapture()
        {
            try
            {
                if (ip_address != null) 
                {
                    camera_capture = new Capture("http://192.168.43.1:8080/video?x.mjpeg");
                    return true;
                }
                camera_capture = new Capture(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
