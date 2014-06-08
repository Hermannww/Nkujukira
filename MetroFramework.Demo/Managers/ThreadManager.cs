using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Threads;

using System;

namespace MetroFramework.Demo.Managers
{
    public class ThreadManager
    {
        private static CameraOutputGrabberThread cam_output;
        private static VideoFromFileThread       video_from_file_grabber;
        private static FaceDetectingThread       review_face_detector;
        private static LiveStreamFaceDetectingThread live_face_detector;
        private static DisplayUpdaterThread      display_updater;
        private static FaceTrackingThread        face_tracker;
        private static AlertGenerationThread     alert_thread;
        private static FaceDrawingThread         face_drawer;
        private static FootageSavingThread       footage_saver;


        public static bool StartIntroThreads(bool review_mode)
        {
            if (review_mode)
            {
                StartNewThread(ThreadFactory.VIDEO_THREAD,review_mode);
                StartNewThread(ThreadFactory.REVIEW_FACE_DETECTOR, review_mode);
            }
            else
            {
                StartNewThread(ThreadFactory.CAMERA_THREAD,review_mode);
                StartNewThread(ThreadFactory.LIVE_FACE_DETECTOR, review_mode);
            }

            StartNewThread(ThreadFactory.DISPLAY_UPDATER,review_mode);
           
            return false;
        }

        public static bool StartNewThread(String thread_id,bool review_mode)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread == null)
                    {
                        alert_thread = (AlertGenerationThread)ThreadFactory.CreateThread(ThreadFactory.ALERT_THREAD,review_mode);
                    }
                    break;
                case ThreadFactory.CAMERA_THREAD:
                    if (cam_output == null)
                    {
                        cam_output = (CameraOutputGrabberThread)ThreadFactory.CreateThread(ThreadFactory.CAMERA_THREAD, review_mode);
                    }
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    if (display_updater == null)
                    {
                        display_updater = (DisplayUpdaterThread)ThreadFactory.CreateThread(ThreadFactory.DISPLAY_UPDATER, review_mode);
                    }
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    if (review_face_detector == null)
                    {
                        review_face_detector = (FaceDetectingThread)ThreadFactory.CreateThread(ThreadFactory.REVIEW_FACE_DETECTOR, review_mode);
                    }
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    if (live_face_detector == null)
                    {
                        live_face_detector = (LiveStreamFaceDetectingThread)ThreadFactory.CreateThread(ThreadFactory.LIVE_FACE_DETECTOR, review_mode);
                    }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    if (face_drawer == null)
                    {
                        face_drawer = (FaceDrawingThread)ThreadFactory.CreateThread(ThreadFactory.FACE_DRAWER, review_mode);
                    }
                    break;
                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker == null)
                    {
                        face_tracker = (FaceTrackingThread)ThreadFactory.CreateThread(ThreadFactory.FACE_DRAWER, review_mode);
                    }
                    break;
                case ThreadFactory.FOOTAGE_SAVER:
                    if (footage_saver == null)
                    {
                        footage_saver = (FootageSavingThread)ThreadFactory.CreateThread(ThreadFactory.FOOTAGE_SAVER, review_mode);
                    }
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    if (video_from_file_grabber == null)
                    {
                        video_from_file_grabber = (VideoFromFileThread)ThreadFactory.CreateThread(ThreadFactory.VIDEO_THREAD, review_mode);
                    }
                    break;
            }
            return true;
          
        }



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

                case ThreadFactory.FACE_TRACKER:
                    return face_tracker;

                case ThreadFactory.FOOTAGE_SAVER:
                    return footage_saver;

                case ThreadFactory.VIDEO_THREAD:
                    return video_from_file_grabber;
            }
            return null;
        }

        public static bool PauseThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread != null) { alert_thread.Pause(); }
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
                    if (face_tracker != null) { face_tracker.Pause(); }
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

        public static bool PauseAllThreads()
        {
            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                PauseThread(thread);
            }
            return false;
        }

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
                    if (live_face_detector!= null) { live_face_detector.Resume(); }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    break;

                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker != null) { face_tracker.Resume(); }
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

        public static bool ResumeAllThreads()
        {
            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                ResumeThread(thread);
            }
            return true;
        }

        public static bool StopThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread != null) { alert_thread.RequestStop(); }
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

                case ThreadFactory.FACE_DRAWER:      
                    break;

                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker != null) { face_tracker.RequestStop(); }
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

        public static bool StopAllThreads()
        {

            foreach (var thread in ThreadFactory.ALL_THREADS)
            {
                StopThread(thread);
            }
            return true;
        }

        public static bool ReleaseThreadResources(String thread_id) 
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    alert_thread = null;
                    break;

                case ThreadFactory.CAMERA_THREAD:
                    cam_output = null;
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    display_updater = null;
                    break;

                case ThreadFactory.REVIEW_FACE_DETECTOR:
                    review_face_detector = null;
                    break;

                case ThreadFactory.LIVE_FACE_DETECTOR:
                    live_face_detector = null;
                    break;

                case ThreadFactory.FACE_DRAWER:
                    face_drawer = null;
                    break;

                case ThreadFactory.FACE_TRACKER:
                    face_tracker = null;
                    break;

                case ThreadFactory.FOOTAGE_SAVER:
                    footage_saver = null;
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    video_from_file_grabber = null;
                    break;
            }
            return true;
        }

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
