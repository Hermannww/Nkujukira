using MetroFramework.Demo.Singletons;
using Nkujukira.Threads;
using System;

namespace MetroFramework.Demo.Factories
{
    class ThreadFactory
    {
        public const String ALERT_THREAD    = "alert";
        public const String CAMERA_THREAD   = "camera_output";
        public const String DISPLAY_UPDATER = "display_updater";
        public const String FACE_DETECTOR   = "face_detector";
        public const String FACE_DRAWER     = "face_drawer";
        public const String FACE_TRACKER    = "face_tracker";
        public const String FOOTAGE_SAVER   = "footage_saver";
        public const String VIDEO_THREAD    = "video_from_file";
        public static String[] ALL_THREADS  = { ALERT_THREAD, CAMERA_THREAD, DISPLAY_UPDATER, FACE_DETECTOR, FACE_DRAWER, FACE_TRACKER, FOOTAGE_SAVER, VIDEO_THREAD };


        public static AbstractThread CreateThread(String thread_id)
        {
            switch (thread_id)
            {
                case ALERT_THREAD:
                    return CreateNewAlertGenerationThread();

                case CAMERA_THREAD:
                    return CreateNewCameraOutputGrabberThread();

                case DISPLAY_UPDATER:
                    return CreateDisplayUpdaterThread();

                case FACE_DETECTOR:
                    return CreateNewFaceDetectingThread();

                case FACE_DRAWER:
                    break;
                case FACE_TRACKER:
                    break;
                case FOOTAGE_SAVER:
                    return CreateFootageSaverThread();

                case VIDEO_THREAD:
                    return CreateVideoFileGrabberThread();
            }
            return null;
        }
        
        
        //STARTS A NEW ALERT GENERATION THREAD
        private static AbstractThread CreateNewAlertGenerationThread()
        {
            AlertGenerationThread alert_thread = new AlertGenerationThread(null);
            alert_thread.StartWorking();
            return alert_thread;
        }


        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE CAMERA IN THE BACKGROUND
        private static AbstractThread CreateNewCameraOutputGrabberThread()
        {

            CameraOutputGrabberThread cam_output = new CameraOutputGrabberThread(MainWindow.live_stream_imageBox);
            cam_output.StartWorking();
            return cam_output;
        }

        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE VIDEO FILE IN THE BACKGROUND
        private static AbstractThread CreateVideoFileGrabberThread()
        {
            VideoFromFileThread video_from_file_grabber = new VideoFromFileThread(Singleton.CURRENT_FILE_NAME);
            video_from_file_grabber.StartWorking();
            return video_from_file_grabber;
        }

        //STARTS THREAD TO DETECT FACES IN FRAME OFF THE MAIN THREAD
        private static AbstractThread CreateNewFaceDetectingThread()
        {
            FaceDetectingThread face_detector = new FaceDetectingThread(Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Width,Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Height);
            face_detector.StartWorking();
            return face_detector;
        }

        //STARTS A NEW FOOTAGE SAVING THREAD
        private static AbstractThread CreateFootageSaverThread()
        {
            FootageSavingThread footage_saver = new FootageSavingThread(VideoFromFileThread.video_capture);
            footage_saver.StartWorking();
            return footage_saver;
        }

        //STARTS A THREAD TO CONTINUOUSLY UPDATE THE VIDEO DISPLAY
        private static DisplayUpdaterThread CreateDisplayUpdaterThread()
        {

            DisplayUpdaterThread video_updater = new DisplayUpdaterThread();
            video_updater.StartWorking();
            return video_updater;
        }
    }
}
