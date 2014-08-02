using DirectShowLib;
using Emgu.CV.UI;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class CameraManager
    {

        private static List<Camera> all_cameras_list = new List<Camera>();
        private static int NUM_OF_IMAGEBOXES_AVAILABLE = 4;

        public static Camera[] GetAllCamerasConnectedToSystem()
        {
            all_cameras_list.Clear();

            //-> Find systems cameras with DirectShow.Net dll 
            DsDevice[] system_cameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            int device_id = 0;

            foreach (var camera in system_cameras)
            {
                if (device_id <= NUM_OF_IMAGEBOXES_AVAILABLE)
                {
                    Camera new_camera = new Camera(device_id, camera.Name, GetCameraImageBox(0));
                    all_cameras_list.Add(new_camera);
                }

                device_id++;
            }

            //ADD A NETWORK CAMERA
            String url = null;
            String camera_name="Network Camera";
            Camera network_camera = new Camera(url,device_id, camera_name , GetCameraImageBox(0));
            all_cameras_list.Add(network_camera);

            //RETURN ARRAY
            return all_cameras_list.ToArray();
        }

        private static ImageBox GetCameraImageBox(int camera_id)
        {
            switch (camera_id)
            {
                case 0:
                    return (ImageBox)Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.live_stream_image_box1);
                case 1:
                    return (ImageBox)Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.live_stream_image_box2);
                case 2:
                    return (ImageBox)Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.live_stream_image_box3);
                case 3:
                    return (ImageBox)Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.live_stream_image_box4);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
