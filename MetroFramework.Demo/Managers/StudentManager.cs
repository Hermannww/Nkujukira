using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using MetroFramework.Demo.Entitities;

namespace MetroFramework.Demo.Managers
{
    class StudentManager
    {
        public static String IMAGES_FOLDER = @"c:\Nkujukira\";
        static int MAXIMUM_IMAGES = 7;

        public static Image getImageFromFile(String fileName)
        {
            Image myImage = null;
            try
            {
                myImage = Image.FromFile(fileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " Error from getImageFromFile Method");
            }
            return myImage;
        }

        public static bool saveImageToFile(Image image, String fileLocation)
        {
            bool success = false;
            try
            {
                image.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Jpeg);
                success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " ERROR from saveImageToFile Method");
            }
            return success;
        }


        public static bool createImageFolder(String folderName)
        {
            try
            {
                if (!System.IO.Directory.Exists(IMAGES_FOLDER + folderName))
                {
                    System.IO.Directory.CreateDirectory(IMAGES_FOLDER + folderName);
                    return true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " ERROR from createImageFolder");

            }
            return false;
        }

        public static void printNumberOfPhotosInFolder(List<Student> list)
        {
            String photoFolder = null;
            try
            {
                foreach (Student student in list)
                {
                    photoFolder = student.getPhoto();
                    Image [] images=getStudentPhotos(photoFolder);
                    Debug.WriteLine("Total image in each Array "+images.Length);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " ERROR from getStudentPhotoFolder method");
            }
            
        }

        /*
         *give it the photo folder path attached to a student in the database
         *so that it can loop through that folder on the disk and return all images in it.
         */

        public static Image[] getStudentPhotos(String photoFolder)
        {
            Image[] imageList = new Image[MAXIMUM_IMAGES];
            int photoNo = 0;//image number as stored in the specified folder.eg 1.jpg,2.jpg
            int counter = 0;
            Image studentPhoto = null;

            do
            {
                photoNo++;
                studentPhoto = getImageFromFile(photoFolder + photoNo + ".JPG");
                if (studentPhoto != null)
                {
                    imageList[counter] = studentPhoto;
                    counter++;
                    Debug.WriteLine(" photo added");
                }

            } while (studentPhoto != null);

            return imageList;
        }
    }


}
