using Luxand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class FacePosition:FSDK.TFacePosition
    {
        public FacePosition() 
        {
        
        }

        public FacePosition(double angle,int w, int xc,int yc) 
        {
            this.angle = angle;
            this.w = w;
            this.xc = xc;
            this.yc = yc;
        }

        public FSDK.TFacePosition Clone() 
        {
            return new FacePosition(angle, w, xc, yc);
        }

        public static FacePosition FromFSDK(FSDK.TFacePosition obj) 
        {
            return new FacePosition(obj.angle, obj.w, obj.xc, obj.yc);
        }
    }
}
