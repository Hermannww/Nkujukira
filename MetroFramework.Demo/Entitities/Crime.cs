using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
   public class Crime
    {

       public int id                 {get;set;}
       public string date_of_crime   {get;set;}
       public String time_of_crime   {get;set;}
       public string type_of_crime   {get;set;}
       public string details_of_crime{get;set;}

       public Crime(int id,String date,String details,String type,String time ) 
       {
           this.id               = id;
           this.date_of_crime    = date;
           this.details_of_crime = details;
           this.type_of_crime    = type;
           this.time_of_crime    = time;
       }

       public Crime(int id, String date, String details)
       {
           this.id = id;
           this.date_of_crime = date;
           this.details_of_crime = details;
       }
    }
}
