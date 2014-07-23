using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Accord.Vision.Tracking;
using AForge.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using Luxand;
using Nkujukira.Demo.Entitities;


namespace Nkujukira.Entities
{
    public class Face:Entity
    {
        //Face Template;
        public byte[] face_template             { get; set; }

        public FacePosition face_position { get; set; }

        //Facial Features;
        public FSDK.TPoint[] facial_features    { get; set; }

        public FSDK.CImage image                { get; set; }

        public FSDK.CImage face_image           { get; set; }

        public bool is_perpetrator              { get; set; }

        public int id                           { get; set; }

        public Face() 
        {
        
        }

        public Face(byte[] face_template, FSDK.TFacePosition face_pos, FSDK.TPoint[] facial_features, FSDK.CImage face_image) 
        {
            this.face_template   = face_template;
            this.face_position   = FacePosition.FromFSDK(face_pos);
            this.facial_features = facial_features;
            this.image           = face_image;
            this.face_image      = face_image;
        }

        public Face Clone() 
        {
            return new Face(face_template, face_position, facial_features, image);
        }

    }
}
