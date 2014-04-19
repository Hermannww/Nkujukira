using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Entities;
using System.Threading.Tasks;
using MetroFramework.Demo;

namespace Nkujukira.Threads
{


    class CleanUpThread : ThreadSuperClass
    {

        public CleanUpThread()
        {
            running = true;
        }

        public override void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    //DO SOME CLEAN UP

                    //CHANGE THE DICTIONARY INTO AN ARRAY
                    KeyValuePair<int, Face>[] hashmap = MainWindow.DETECTED_FACES_DATASTORE.ToArray();
                    int k = 0;
                    Face[] faces_array = new Face[hashmap.Length];
                    foreach (var key_value_pair in hashmap)
                    {
                        faces_array[k] = key_value_pair.Value;
                        k++;
                    }


                    //FOR EACH FACE 
                    //CHECK IF IT INTERSECTS WITH ANY OTHER FACE AND THEN REMOVE IT
                    //ELSE GO TO NEXT FACE

                    //WE MAKE THIS PARALLEL BECOZ EACH ITERATION DOESNT DEPEND ON THE NEXT
                    Parallel.For(0, faces_array.Length, i =>
                    {
                        for (int j = 0; j < faces_array.Length; j++)
                        {
                            if (i == j)
                            {
                                continue;
                            }
                            if (faces_array[i].GetRectangle().IntersectsWith(faces_array[j].GetRectangle()))
                            {
                                RemoveFace(faces_array[i]);
                            }
                        }
                    });
                }
            }
        }

        //REMOVE FACE FROM THE DATA STORE
        private void RemoveFace(Face face)
        {
            //REMOVE FACE FROM DATA STORE
            bool sucess = MainWindow.DETECTED_FACES_DATASTORE.TryRemove(face.GetId(), out face);
            //ADD THE ID TO LIST FOR RECYCLING
            if (sucess)
            {
                Face.face_ids_for_recycling.Add(face.GetId());
            }
        }

        public override bool RequestStop()
        {
            running = false;
            return true;
        }
    }


}


