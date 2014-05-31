using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Interfaces;
using MetroFramework.Demo.Factories;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MetroFramework.Demo.Managers
{
    class StudentsManager:Manager
    {
        public const String IMAGES_FOLDER        = @"c:\Nkujukira\";
        private const int FIRST_NAME             = 0;
        private const int LAST_NAME              = 1;
        private const int MIDDLE_NAME            = 2;
        private const int STUDENT_NUMBER         = 3;
        private const int REGISTRATION_NUMBER    = 4;
        private const int D_O_B                  = 5;
        private const int COURSE                 = 6;
        private const int GENDER                 = 7;
        private const int PHOTOS                 = 8;
        private const string TABLE_NAME          = "STUDENT";

        public static void CreateTable()
        {
            String create_sql                    = "CREATE TABLE " + TABLE_NAME + " IF NOT EXISTS (ID INT AUTO_INCREMENT PRIMARY KEY,FIRSTNAME VARCHAR(30),MIDDLENAME VARCHAR(30),LASTNAME VARCHAR(30),STUDENT_NO VARCHAR(30),REG_NO VARCHAR(10),DATE_OF_BIRTH VARCHAR(10),COURSE VARCHAR(30),GENDER VARCHAR(10),PHOTOS_PATH VARCHAR(30) )";
            sql_command                          = new MySqlCommand();
            sql_command.Connection               = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText              = create_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public static void DropTable()
        {
            String drop_sql                      = "DROP TABLE " + TABLE_NAME + " IF EXISTS";
            sql_command                          = new MySqlCommand();
            sql_command.Connection               = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText              = drop_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public static void PopulateTable()
        {

        }

        public static Student[] GetAllStudents() 
        {
            try
            {
                //select sql
                String select_sql                = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command                      = new MySqlCommand();
                sql_command.Connection           = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText          = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                      = database.Select(sql_command);

                List<Student> students           = new List<Student>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    String first_name            = data_reader.GetString(FIRST_NAME);
                    String last_name             = data_reader.GetString(LAST_NAME);
                    String middle_name           = data_reader.GetString(MIDDLE_NAME);
                    String student_number        = data_reader.GetString(STUDENT_NUMBER);
                    String reg_number            = data_reader.GetString(REGISTRATION_NUMBER);
                    String course                = data_reader.GetString(COURSE);
                    String dob                   = data_reader.GetString(D_O_B);
                    String gender                = data_reader.GetString(GENDER);
                    Bitmap[] photos              = GetStudentPhotos(data_reader.GetString(PHOTOS));

                    Student student              = new Student(first_name, middle_name, last_name, student_number, reg_number, course, dob, gender, photos);

                    //add student to list
                    students.Add(student);
                }

                //return array of results
                return students.ToArray();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            finally 
            {
                data_reader.Close();
            }
            return null;
        }

        private static Bitmap[] GetStudentPhotos(string p)
        {
            return null;
        }

        public static Student GetStudent(int id) 
        {
            try
            {
                //select sql
                String select_sql                = "SELECT * FROM " + TABLE_NAME + " WHERE REG_NO=@id OR STUDENT_NO=@id";
               
                //sql command
                sql_command                      = new MySqlCommand();
                sql_command.Connection           = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText          = select_sql;
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.Prepare();

                //get results in enum object
                data_reader                      = database.Select(sql_command);

                List<Student> students           = new List<Student>();

                //loop thru em
                while (data_reader.Read())
                {
                    //create new student

                    String first_name            = data_reader.GetString(FIRST_NAME);
                    String last_name             = data_reader.GetString(LAST_NAME);
                    String middle_name           = data_reader.GetString(MIDDLE_NAME);
                    String student_number        = data_reader.GetString(STUDENT_NUMBER);
                    String reg_number            = data_reader.GetString(REGISTRATION_NUMBER);
                    String course                = data_reader.GetString(COURSE);
                    String dob                   = data_reader.GetString(D_O_B);
                    String gender                = data_reader.GetString(GENDER);
                    Bitmap[] photos              = GetStudentPhotos(data_reader.GetString(PHOTOS));

                    Student student              = new Student(first_name, middle_name, last_name, student_number, reg_number, course, dob, gender, photos);

                    //add student to list
                    students.Add(student);
                }

                //return array of results
                return students.ToArray()[0];
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            finally 
            {
                data_reader.Close();
            }
            
           
        }

        public static bool Save(Student student) 
        {
            string photo_path                    ="";

            //insert sql
            String insert_sql                    = "INSERT INTO " + TABLE_NAME + " (firstname,middlename,lastname,studentno,regno,course,dob,gender,photo) VALUES(@firstname,@middlename,@lastname,@studentno,@regno,@course,@dob,@gender,@photo)";
                                                              


            //Sql command
            sql_command                          = new MySqlCommand();
            sql_command.Connection               = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText              = insert_sql;

            sql_command.Parameters.AddWithValue("@firstname", student.firstName);
            sql_command.Parameters.AddWithValue("@middlename", student.middleName);
            sql_command.Parameters.AddWithValue("@lastname", student.lastName);
            sql_command.Parameters.AddWithValue("@studentno", student.studentNo);
            sql_command.Parameters.AddWithValue("@regno", student.regNo);
            sql_command.Parameters.AddWithValue("@course", student.course);
            sql_command.Parameters.AddWithValue("@dob", student.DOB);
            sql_command.Parameters.AddWithValue("@gender", student.gender);
            sql_command.Parameters.AddWithValue("@photo", photo_path);

            sql_command.Prepare();

            //insert into db
            database.Insert(sql_command);

            //save each image
            foreach (var photo in student.photos)
            {
                FileManager.SaveBitmap(photo_path, photo);
            }
            return true;
        }

        public static bool Delete(int id) 
        {
            //insert sql
            String delete_sql                    = "DELETE FROM "+TABLE_NAME+" WHERE REGNO=@id OR STUDENTNO=@id";

            //Sql command
            sql_command                          = new MySqlCommand();
            sql_command.Connection               = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText              = delete_sql;

            sql_command.Parameters.AddWithValue("@id", id);

            sql_command.Prepare();
            

            //get results in enum object
            database.Delete(sql_command);

            return true;
        }


       
    }


}
