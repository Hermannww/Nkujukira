using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Entitities
                                     {
   public class Crime
                                     {

       public int id                 {get;set;}
       public string date_of_crime   {get;set;}
       public String time_of_crime   {get;set;}
       public string type_of_crime   {get;set;}
       public String crime_committed { get; set; }

       public String location { get; set; }
       public string details_of_crime{get;set;}
       public int perpetrator_id     { get; set; }
       public String created_at { get; set; }

       public Crime(int id,String date,String details,String type,String crime,String time,String location,int perpetrator_id,String created_at) 
                                     {
           this.id               = id;
           this.date_of_crime    = date;
           this.details_of_crime = details;
           this.type_of_crime    = type;
           this.crime_committed = crime;
           this.time_of_crime    = time;
           this.location = location;
           this.perpetrator_id   = perpetrator_id;
           this.created_at = created_at;
       }

       public Crime(String date,String details, String type,String crime,String time,String location,int perpetrator_id)
                                     {
           this.date_of_crime    = date;
           this.details_of_crime = details;
           this.type_of_crime    = type;
           this.crime_committed = crime;
           this.time_of_crime    = time;
           this.location = location;
           this.perpetrator_id   = perpetrator_id;
       }
    }
}
