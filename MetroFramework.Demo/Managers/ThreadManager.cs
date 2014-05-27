using MetroFramework.Demo.Factories;
using Nkujukira.Threads;
using System;

namespace MetroFramework.Demo.Managers
{
    public class ThreadManager
    {
        private static CameraOutputGrabberThread cam_output;
        private static VideoFromFileThread       video_from_file_grabber;
        private static FaceDetectingThread       face_detector;
        private static DisplayUpdaterThread      display_updater;
        private static FaceTrackingThread        face_tracker;
        private static AlertGenerationThread     alert_thread;
        private static FaceDrawingThread         face_drawer;
        private static FootageSavingThread       footage_saver;


        public static bool StartIntroThreads(bool review_mode)
        {
            if (review_mode)
            {
                StartNewThread(ThreadFactory.VIDEO_THREAD);
            }
            else
            {
                StartNewThread(ThreadFactory.CAMERA_THREAD);
            }

            StartNewThread(ThreadFactory.DISPLAY_UPDATER);
            StartNewThread(ThreadFactory.FACE_DETECTOR);
            return false;
        }

        public static bool StartNewThread(String thread_id)
        {
            switch (thread_id)
            {
                case ThreadFactory.ALERT_THREAD:
                    if (alert_thread == null)
                    {
                        alert_thread = (AlertGenerationThread)ThreadFactory.CreateThread(ThreadFactory.ALERT_THREAD);
                    }
                    break;
                case ThreadFactory.CAMERA_THREAD:
                    if (cam_output == null)
                    {
                        cam_output = (CameraOutputGrabberThread)ThreadFactory.CreateThread(ThreadFactory.CAMERA_THREAD);
                    }
                    break;

                case ThreadFactory.DISPLAY_UPDATER:
                    if (display_updater == null)
                    {
                        display_updater = (DisplayUpdaterThread)ThreadFactory.CreateThread(ThreadFactory.DISPLAY_UPDATER);
                    }
                    break;

                case ThreadFactory.FACE_DETECTOR:
                    if (face_detector == null)
                    {
                        face_detector = (FaceDetectingThread)ThreadFactory.CreateThread(ThreadFactory.FACE_DETECTOR);
                    }
                    break;

                case ThreadFactory.FACE_DRAWER:
                    if (face_drawer == null)
                    {
                        face_drawer = (FaceDrawingThread)ThreadFactory.CreateThread(ThreadFactory.FACE_DRAWER);
                    }
                    break;
                case ThreadFactory.FACE_TRACKER:
                    if (face_tracker == null)
                    {
                        face_tracker = (FaceTrackingThread)ThreadFactory.CreateThread(ThreadFactory.FACE_DRAWER);
                    }
                    break;
                case ThreadFactory.FOOTAGE_SAVER:
                    if (footage_saver == null)
                    {
                        footage_saver = (FootageSavingThread)ThreadFactory.CreateThread(ThreadFactory.FOOTAGE_SAVER);
                    }
                    break;

                case ThreadFactory.VIDEO_THREAD:
                    if (video_from_file_grabber == null)
                    {
                        video_from_file_grabber = (VideoFromFileThread)ThreadFactory.CreateThread(ThreadFactory.VIDEO_THREAD);
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

                case ThreadFactory.FACE_DETECTOR:
                    return face_detector;

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

                case ThreadFactory.FACE_DETECTOR:
                    if (face_detector != null) { face_detector.Pause(); }
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

                case ThreadFactory.FACE_DETECTOR:
                    if (face_detector != null) { face_detector.Resume(); }
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

                case ThreadFactory.FACE_DETECTOR:
                    if (face_detector != null) { face_detector.RequestStop(); }
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

                case ThreadFactory.FACE_DETECTOR:
                    face_detector = null;
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
