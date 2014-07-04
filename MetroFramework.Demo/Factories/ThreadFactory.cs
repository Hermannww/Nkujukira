using Emgu.CV;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Threads;
using System;

namespace MetroFramework.Demo.Factories
{
    class ThreadFactory
    {
        public const String ALERT_THREAD                                    = "alert";
        public const String CAMERA_THREAD                                   = "camera_output";
        public const String DISPLAY_UPDATER                                 = "display_updater";
        public const String REVIEW_FACE_DETECTOR                            = "review_face_detector";
        public const String LIVE_FACE_DETECTOR                              = "live_face_detector";
        public const String FACE_DRAWER                                     = "face_drawer";
        public const String FACE_TRACKER                                    = "face_tracker";
        public const String FOOTAGE_SAVER                                   = "footage_saver";
        public const String VIDEO_THREAD                                    = "video_from_file";
        public const String PERP_RECOGNIZER                                 = "perpetrator_recognizer";
        public const String PROGRESS_THREAD                                 = "face_recog_progress";

        public static String[] ALL_THREADS                                  = { 
                                                                                ALERT_THREAD,
                                                                                CAMERA_THREAD,
                                                                                DISPLAY_UPDATER, 
                                                                                REVIEW_FACE_DETECTOR,
                                                                                LIVE_FACE_DETECTOR,
                                                                                PERP_RECOGNIZER, 
                                                                                FACE_DRAWER, 
                                                                                FACE_TRACKER,
                                                                                FOOTAGE_SAVER, 
                                                                                VIDEO_THREAD,
                                                                                PERP_RECOGNIZER,
                                                                                PROGRESS_THREAD
                                                                              };

        //ALL THREADS AVAILABLE
        private static CameraOutputGrabberThread     cam_output             = null;
        private static VideoFromFileThread           video_from_file_grabber= null;
        private static FaceDetectingThread           review_face_detector   = null;
        private static LiveStreamFaceDetectingThread live_face_detector     = null;
        private static DisplayUpdaterThread          display_updater        = null;
        private static FaceTrackingThread            face_tracker           = null;
        private static AlertGenerationThread         alert_thread           = null;
        private static FaceDrawingThread             face_drawer            = null;
        private static FootageSavingThread           footage_saver          = null;
        private static PerpetratorRecognitionThread  perp_recognizer        = null;
        private static FaceRecognitionProgressThread face_recog_progress    = null;

        //STARTS THE THREADS DEPENDING ON THE STATE OF THE APP
        public static bool StartIntroThreads(bool review_mode)
        {
            if (review_mode)
            {
                CreateVideoFileGrabberThread();
                CreateReviewFaceDetectingThread();
                CreateNewAlertGenerationThread();
            }

            else
            {
                CreateNewPerpetratorRecognizerThread();
                CreateNewCameraOutputGrabberThread();
                CreateLiveStreamFaceDetectorThread();
                CreateFaceRecogProgressThread();
                //CreateFootageSaverThread();
                CreateNewAlertGenerationThread();

            }

            CreateDisplayUpdaterThread(review_mode);

            return false;
        }

        private static FaceRecognitionProgressThread CreateFaceRecogProgressThread()
        {
            if (face_recog_progress                                         == null)
            {
                face_recog_progress                                         = new FaceRecognitionProgressThread();
                face_recog_progress.StartWorking();
            }
            return face_recog_progress;
        }

        private static PerpetratorRecognitionThread CreateNewPerpetratorRecognizerThread()
        {
            if (perp_recognizer                                             == null)
            {
                perp_recognizer                                             = new PerpetratorRecognitionThread();
                perp_recognizer.StartWorking();
            }
            return perp_recognizer;
        }


        //STARTS A NEW ALERT GENERATION THREAD
        private static AlertGenerationThread CreateNewAlertGenerationThread()
        {
            if (alert_thread== null)
            {
                alert_thread                                                = new AlertGenerationThread();
                alert_thread.StartWorking();
            }
            return alert_thread;
        }


        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE CAMERA IN THE BACKGROUND
        private static CameraOutputGrabberThread CreateNewCameraOutputGrabberThread()
        {
            if (cam_output                                                  == null)
            {
                cam_output                                                  = new CameraOutputGrabberThread();
                cam_output.StartWorking();
            }
            return cam_output;
        }

        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE VIDEO FILE IN THE BACKGROUND
        private static VideoFromFileThread CreateVideoFileGrabberThread()
        {
            if (video_from_file_grabber                                     == null)
            {
                video_from_file_grabber                                     = new VideoFromFileThread(Singleton.CURRENT_FILE_NAME);
                video_from_file_grabber.StartWorking();
            }
            return video_from_file_grabber;
        }

        //STARTS THREAD TO DETECT FACES IN FRAME OFF THE MAIN THREAD
        private static FaceDetectingThread CreateReviewFaceDetectingThread()
        {
            if (review_face_detector                                        == null)
            {
                review_face_detector                                        = new FaceDetectingThread(Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Height);
                review_face_detector.StartWorking();
            }
            return review_face_detector;         
        }

        //STARTS THREAD TO DETECT FACES IN FRAME OFF THE MAIN THREAD
        private static LiveStreamFaceDetectingThread CreateLiveStreamFaceDetectorThread()
        {
            if (live_face_detector                                          == null)
            {
                live_face_detector                                          = new LiveStreamFaceDetectingThread(Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height);
                live_face_detector.StartWorking();
            }
            return live_face_detector;
        }

        //STARTS A NEW FOOTAGE SAVING THREAD
        private static FootageSavingThread CreateFootageSaverThread()
        {
            if (footage_saver                                               == null)
            {
                footage_saver                                               = new FootageSavingThread(CameraOutputGrabberThread.camera_capture);
                footage_saver.StartWorking();
            }
            return footage_saver;
        }

        //STARTS A THREAD TO CONTINUOUSLY UPDATE THE VIDEO DISPLAY
        private static DisplayUpdaterThread CreateDisplayUpdaterThread(bool review_mode)
        {
            if (display_updater                                             == null)
            {

                if (review_mode)
                {

                    display_updater                                         = new DisplayUpdaterThread((ImageBox)Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox"), review_mode);
                }
                else
                {
                    display_updater                                         = new DisplayUpdaterThread((ImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox"), review_mode);
                }

                display_updater.StartWorking();
            }
            return display_updater;
        }

      
        //RETURNS A THREAD BASED ON ITS ID
        public static AbstractThread GetThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    return alert_thread;

                case ThreadFactory.CAMERA_THREAD:
                    return cam_output;

                case ThreadFactory.DISPLAY_UPDATER:
                    return display_updater;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    return review_face_detector;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    return live_face_detector;

                case ThreadFactory.FACE_DRAWER:
                    return face_drawer;

                case ThreadFactory.PERP_RECOGNIZER:
                    return perp_recognizer;

                case ThreadFactory.PROGRESS_THREAD:
                    return face_recog_progress;

                case ThreadFactory.FACE_TRACKER:
                    return face_tracker;

                case ThreadFactory.FOOTAGE_SAVER:
                    return footage_saver;

                case ThreadFactory.VIDEO_THREAD:
                    return video_from_file_grabber;
            }
            return null;
        }

        //THIS PAUSES A THREAD GIVEN ITS ID
        public static bool PauseThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread !=null) { alert_thread.Pause(); }
                    break;
                case ThreadFactory.CAMERA_THREAD:
                    if (cam_output != null) { cam_output.Pause(); }
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    if (display_updater != null) { display_updater.Pause(); }
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    if (review_face_detector != null) { review_face_detector.Pause(); }
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    if (live_face_detector != null) { live_face_detector.Pause(); }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    break;

                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker !=null) { face_tracker.Pause(); }
                    break;

                case ThreadFactory.FOOTAGE_SAVER:
                    if (footage_saver != null) { footage_saver.Pause(); }
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    if (video_from_file_grabber != null) { video_from_file_grabber.Pause(); }
                    break;
            }
            return true;
        }

        //THIS PAUSES ALL RUNNING THREADS
        public static bool PauseAllThreads()
        {
            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                PauseThread(thread);
            }
            return false;
        }

        //THIS RESUMES A THREAD GIVEN ITS ID
        public static bool ResumeThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread != null) { alert_thread.Resume(); }
                    break;

                case ThreadFactory.CAMERA_THREAD:
                    if (cam_output != null) { cam_output.Resume(); }
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    if (display_updater != null) { display_updater.Resume(); }
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    if (review_face_detector != null) { review_face_detector.Resume(); }
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    if (live_face_detector != null) { live_face_detector.Resume(); }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    break;

                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker !=null) { face_tracker.Resume(); }
                    break;

                case ThreadFactory.FOOTAGE_SAVER:
                    if (footage_saver != null) { footage_saver.Resume(); }
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    if (video_from_file_grabber != null) { video_from_file_grabber.Resume(); }
                    break;
            }
            return true;
        }

        //THIS RESUMES ALL RUNNING THREADS
        public static bool ResumeAllThreads()
        {
            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                ResumeThread(thread);
            }
            return true;
        }

        //THIS STOPS A RUNNING THREAD GIVEN ITS iD
        public static bool StopThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread !=null) { alert_thread.RequestStop(); }
                    break;
                case ThreadFactory.CAMERA_THREAD:
                    if (cam_output != null) { cam_output.RequestStop(); }
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    if (display_updater != null) { display_updater.RequestStop(); }
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    if (review_face_detector != null) { review_face_detector.RequestStop(); }
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    if (live_face_detector != null) { live_face_detector.RequestStop(); }
                    break;

                case ThreadFactory.PERP_RECOGNIZER:
                    if (perp_recognizer != null) { perp_recognizer.RequestStop(); }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    break;

                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker !=null) { face_tracker.RequestStop(); }
                    break;

                case ThreadFactory.FOOTAGE_SAVER:
                    if (footage_saver != null) { footage_saver.RequestStop(); }
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    if (video_from_file_grabber != null) { video_from_file_grabber.RequestStop(); }
                    break;
            }
            return true;
        }

        //THIS STOPS ALL RUNNING THREADS
        public static bool StopAllThreads()
        {

            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                StopThread(thread);
            }
            return true;
        }

        //THIS RELEASES ALL RESOURCES CONSUMED BY A THREAD GIVEN ITS ID
        public static bool ReleaseThreadResources(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    alert_thread                                            = null;
                    break;

                case ThreadFactory.CAMERA_THREAD:
                    cam_output                                              = null;
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    display_updater                                         = null;
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    review_face_detector                                    = null;
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    live_face_detector                                      = null;
                    break;

                case ThreadFactory.PERP_RECOGNIZER:
                    perp_recognizer                                         = null;
                    break;

                case ThreadFactory.FACE_DRAWER:
                    face_drawer                                             = null;
                    break;

                case ThreadFactory.FACE_TRACKER:
                    face_tracker                                            = null;
                    break;

                case ThreadFactory.FOOTAGE_SAVER:
                    footage_saver                                           = null;
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    video_from_file_grabber                                 = null;
                    break;
            }
            return true;
        }

        //RELEASES ALL RESOURCES CONSUMED BY A THREAD
        public static bool ReleaseAllThreadResources()
        {
            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                ReleaseThreadResources(thread);
            }
            return true;
        }

    }
}
