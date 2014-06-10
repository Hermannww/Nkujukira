using Emgu.CV;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Threads;
using System;

namespace MetroFramework.Demo.Factories
{
    class ThreadFactory
    {
        public const String ALERT_THREAD = "alert";
        public const String CAMERA_THREAD = "camera_output";
        public const String DISPLAY_UPDATER = "display_updater";
        public const String REVIEW_FACE_DETECTOR = "review_face_detector";
        public const String LIVE_FACE_DETECTOR = "live_face_detector";
        public const String FACE_DRAWER = "face_drawer";
        public const String FACE_TRACKER = "face_tracker";
        public const String FOOTAGE_SAVER = "footage_saver";
        public const String VIDEO_THREAD = "video_from_file";
        public static String[] ALL_THREADS = { ALERT_THREAD, CAMERA_THREAD, DISPLAY_UPDATER, REVIEW_FACE_DETECTOR, LIVE_FACE_DETECTOR, FACE_DRAWER, FACE_TRACKER, FOOTAGE_SAVER, VIDEO_THREAD };


        public static AbstractThread CreateThread(String thread_id, bool review_mode)
        {
            switch (thread_id)
            {
                case ALERT_THREAD:
                    return CreateNewAlertGenerationThread();

                case CAMERA_THREAD:
                    return CreateNewCameraOutputGrabberThread();

                case DISPLAY_UPDATER:
                    return CreateDisplayUpdaterThread(review_mode);

                case REVIEW_FACE_DETECTOR:
                    return CreateReviewFaceDetectingThread();

                case LIVE_FACE_DETECTOR:
                    return CreateLiveFaceDetectingThread();

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

            CameraOutputGrabberThread cam_output = new CameraOutputGrabberThread();
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
        private static AbstractThread CreateReviewFaceDetectingThread()
        {
            FaceDetectingThread face_detector = new FaceDetectingThread(Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Height);
            face_detector.StartWorking();
            return face_detector;
        }

        //STARTS THREAD TO DETECT FACES IN FRAME OFF THE MAIN THREAD
        private static AbstractThread CreateLiveFaceDetectingThread()
        {
            LiveStreamFaceDetectingThread face_detector = new LiveStreamFaceDetectingThread(Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height);
            face_detector.StartWorking();
            return face_detector;
        }

        //STARTS A NEW FOOTAGE SAVING THREAD
        private static AbstractThread CreateFootageSaverThread()
        {
            FootageSavingThread footage_saver = new FootageSavingThread(CameraOutputGrabberThread.camera_capture);
            footage_saver.StartWorking();
            return footage_saver;
        }

        //STARTS A THREAD TO CONTINUOUSLY UPDATE THE VIDEO DISPLAY
        private static DisplayUpdaterThread CreateDisplayUpdaterThread(bool review_mode)
        {

            DisplayUpdaterThread video_updater;

            if (review_mode)
            {

                video_updater = new DisplayUpdaterThread((ImageBox)Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox"), review_mode);
            }
            else
            {
                video_updater = new DisplayUpdaterThread((ImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox"), review_mode);
            }

            video_updater.StartWorking();
            return video_updater;
        }
    }
}
