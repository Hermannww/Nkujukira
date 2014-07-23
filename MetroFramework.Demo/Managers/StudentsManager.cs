using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Interfaces;
using Nkujukira.Demo.Factories;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Singletons;

namespace Nkujukira.Demo.Managers
{
    public class StudentsManager : Manager
    {
        private static String PATH_TO_IMAGES   = Singleton.IMAGES_DIRECTORY + TABLE_NAME + @"\";
        private const int ID                   = 0;
        private const int FIRST_NAME           = 1;
        private const int LAST_NAME            = 3;
        private const int MIDDLE_NAME          = 2;
        private const int STUDENT_NUMBER       = 4;
        private const int REGISTRATION_NUMBER  = 5;
        private const int D_O_B                = 6;
        private const int COURSE               = 7;
        private const int GENDER               = 8;
        private const string TABLE_NAME        = "STUDENTS";

        public static bool CreateTable()
        {
            try
            {
                String create_sql              = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + 
                                                " (ID INT AUTO_INCREMENT PRIMARY KEY,"+
                                                "FIRSTNAME VARCHAR(30),"+
                                                "MIDDLENAME VARCHAR(30),"+
                                                "LASTNAME VARCHAR(30)"+
                                                ",STUDENT_NO VARCHAR(30),"+
                                                "REG_NO VARCHAR(10),"+
                                                "DATE_OF_BIRTH VARCHAR(30),"+
                                                "COURSE VARCHAR(30),"+
                                                "GENDER VARCHAR(30),"+
                                                "CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = create_sql;
                sql_command.Prepare();
                database.Update(sql_command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                database.CloseConnection();
            }
        }

        public static bool DropTable()
        {
            try
            {
                String drop_sql                = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = drop_sql;
                sql_command.Prepare();
                database.Update(sql_command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                database.CloseConnection();
            }

        }

        public static bool PopulateTable()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Student[] GetAllStudents()
        {
            List<Student> students             = new List<Student>();
            try
            {
                //select sql
                String select_sql              = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                    = database.Select(sql_command);



                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student
                    int id                     = data_reader.GetInt32(ID);
                    String first_name          = data_reader.GetString(FIRST_NAME);
                    String last_name           = data_reader.GetString(LAST_NAME);
                    String middle_name         = data_reader.GetString(MIDDLE_NAME);
                    String student_number      = data_reader.GetString(STUDENT_NUMBER);
                    String reg_number          = data_reader.GetString(REGISTRATION_NUMBER);
                    String course              = data_reader.GetString(COURSE);
                    String dob                 = data_reader.GetString(D_O_B);
                    String gender              = data_reader.GetString(GENDER);
                    Image<Bgr, byte>[] photos = GetStudentPhotos(id);

                    Student student            = new Student(id, first_name, middle_name, last_name, student_number, reg_number, course, dob, gender, photos);

                    //add student to list
                    students.Add(student);
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            finally
            {
                data_reader.Close();
            }
            //return array of results
            return students.ToArray();
        }

        public static Image<Bgr, byte>[] GetStudentPhotos(int id)
        {
            String path                        = PATH_TO_IMAGES + id + @"\";
            Image<Bgr, byte>[] images         = FileManager.GetAllImagesInDirectory(path);
            return images;
        }

        public static Student GetStudent(int id)
        {
            List<Student> students             = new List<Student>();
            try
            {
                //select sql
                String select_sql              = "SELECT * FROM " + TABLE_NAME + " WHERE REG_NO=@id OR STUDENT_NO=@id OR ID=@id";

                //sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = select_sql;
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.Prepare();

                //get results in enum object
                data_reader                    = database.Select(sql_command);



                //loop thru em
                if (data_reader.Read())
                {
                    //create new student
                    int std_id                 = data_reader.GetInt32(ID);
                    String first_name          = data_reader.GetString(FIRST_NAME);
                    String last_name           = data_reader.GetString(LAST_NAME);
                    String middle_name         = data_reader.GetString(MIDDLE_NAME);
                    String student_number      = data_reader.GetString(STUDENT_NUMBER);
                    String reg_number          = data_reader.GetString(REGISTRATION_NUMBER);
                    String course              = data_reader.GetString(COURSE);
                    String dob                 = data_reader.GetString(D_O_B);
                    String gender              = data_reader.GetString(GENDER);
                    Image<Bgr, byte>[] photos = GetStudentPhotos(std_id);

                    Student student            = new Student(std_id, first_name, middle_name, last_name, student_number, reg_number, course, dob, gender, photos);

                    //add student to list
                    students.Add(student);
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                data_reader.Close();
            }

            //return array of results
            return students.ToArray()[0];

        }

        public static bool Save(Student student)
        {
            try
            {
                //insert sql
                String insert_sql              = "INSERT INTO " + TABLE_NAME + " (firstname,middlename,lastname,student_no,reg_no,course,date_of_birth,gender) VALUES(@firstname,@middlename,@lastname,@studentno,@regno,@course,@dob,@gender)";

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = insert_sql;

                sql_command.Parameters.AddWithValue("@firstname", student.firstName);
                sql_command.Parameters.AddWithValue("@middlename", student.middleName);
                sql_command.Parameters.AddWithValue("@lastname", student.lastName);
                sql_command.Parameters.AddWithValue("@studentno", student.studentNo);
                sql_command.Parameters.AddWithValue("@regno", student.regNo);
                sql_command.Parameters.AddWithValue("@course", student.course);
                sql_command.Parameters.AddWithValue("@dob", student.DOB);
                sql_command.Parameters.AddWithValue("@gender", student.gender);

                sql_command.Prepare();

                //insert into db
                database.Insert(sql_command);

                student.id                     = Convert.ToInt32(sql_command.LastInsertedId);

                //create students folder based on the students id
                string photo_path              = PATH_TO_IMAGES + student.id + @"\";

                //create folder for the perpetrator images
                FileManager.CreateFolderIfMissing(photo_path);

                //save each image
                for (int i                     = 0; i < student.photos.Length; i++)
                {
                    //save using the perps name plus a unique number 
                    FileManager.SaveImage(photo_path + student.id + " " + i + ".png", student.photos[i]);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                database.CloseConnection();
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                //insert sql
                String delete_sql              = "DELETE FROM " + TABLE_NAME + " WHERE REGNO=@id OR STUDENTNO=@id OR ID=@id";

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = delete_sql;

                sql_command.Parameters.AddWithValue("@id", id);

                sql_command.Prepare();


                //get results in enum object
                database.Delete(sql_command);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool Update(Student student)
        {
            try
            {
                String update_sql              = "UPDATE " + TABLE_NAME + " SET FIRSTNAME=@firstname ,MIDDLENAME=@middlename,LASTNAME=@lastname ,STUDENT_NO=@student_no ,REG_NO=@reg_no ,DATE_OF_BIRTH=@dob ,COURSE=@course ,GENDER=@gender,PHOTOS_PATH=@path WHERE ID=@id";
                String path                    = "";

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = update_sql;

                sql_command.Parameters.AddWithValue("@id", student.id);
                sql_command.Parameters.AddWithValue("@firstname", student.firstName);
                sql_command.Parameters.AddWithValue("@middlename", student.middleName);
                sql_command.Parameters.AddWithValue("@lastname", student.lastName);
                sql_command.Parameters.AddWithValue("@student_no", student.studentNo);
                sql_command.Parameters.AddWithValue("@reg_no", student.regNo);
                sql_command.Parameters.AddWithValue("@dob", student.DOB);
                sql_command.Parameters.AddWithValue("@path", path);
                sql_command.Parameters.AddWithValue("@course", student.course);

                sql_command.Parameters.AddWithValue("@gender", student.gender);

                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


}
