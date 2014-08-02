using Emgu.CV;
using MediaInfoNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Entitities
{
    public class VideoFile
    {
        public int id { get; set; }
        public String file_name { get; set; }
        public Capture video_capture { get; set; }
        public String video_length_string { get; set; }
        public double video_length_in_millisecs { get; set; }

        public VideoFile() 
        {
            this.id                  = -1;
            this.file_name           = "";
            this.video_length_string = "00:00";
        }

        public VideoFile(int id, string file_name) 
        {
            this.id                  = id;
            this.file_name           = file_name;
            this.video_capture       = new Capture(file_name);

            //GET PROPERTIES OF THE VIDEO FILE
            MediaFile video_properties = new MediaFile(file_name);
            video_length_in_millisecs = video_properties.General.DurationMillis;
            video_length_string = video_properties.General.DurationString;
        }
    }
}
