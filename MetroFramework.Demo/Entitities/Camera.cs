using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Camera:Entity
    {
        public int id { get; set; }
        public String name { get; set; }
        public String location { get; set; }
        public String recording_since { get; set; }
        public String filepath_to_footage { get; set; }

        public Camera() 
        {
            id = 1;
            name = "Camera 1";
            location = "Main Entrance, School Of Computing, Block B";
            recording_since = "8:00 A.M";
            filepath_to_footage = "";
        }
    }
}
