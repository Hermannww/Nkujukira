using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.Interfaces;
using System.Diagnostics;
using System.IO;

namespace MetroFramework.Demo.DataStores
{
    public class TextFile:FileInterface
    {
        public bool writeToFile(String file_name,String text) {
            try {
                // create a writer and open the file
                TextWriter text_writer = new StreamWriter(file_name);

                // write a line of text to the file
                text_writer.WriteLine(text);

                // close the stream
                text_writer.Close();
                return true;
            }catch(Exception ex){
                Debug.WriteLine(ex.Message+"ERROR from WriteToFile Method in TextFile Class");
            }
            return false;
        }
        public String readFromFile(String file_name) {
            try {
                // create reader & open file
                TextReader text_reader = new StreamReader(file_name);

                // read a line of text
                String text=text_reader.ReadLine();
                
                // close the stream
                text_reader.Close();
                return text;
            }catch(Exception ex){
                Debug.WriteLine(ex.Message + "ERROR from readFromFile Method in TextFile Class");
            }
            return null;
        }
    }
}
