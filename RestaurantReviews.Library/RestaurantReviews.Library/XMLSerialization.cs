using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using RestaurantReviews.Library.Models;


namespace RestaurantReviews.Library
{
    public class XMLSerialization
    {
        XmlSerializer xmlSerial;
        string filePath = ConfigurationManager.AppSettings["xmlFile"];


        public List<Restaurant> ReadListFromXML()
        {
            List<Restaurant> newList = new List<Restaurant>();
            var path = filePath + "//restaurants.xml";

            /*
            var writer = new XmlSerializer(typeof(List<Restaurant>));
            var blankFile = new System.IO.StreamWriter(path);
            writer.Serialize(blankFile, newList);
            blankFile.Close();
            */

            XmlSerializer reader = new XmlSerializer(typeof(List<Restaurant>));
            var file = new System.IO.StreamReader(path);

            
            newList = (List<Restaurant>)reader.Deserialize(file);
            file.Close();

            return newList;
        }

        public void WriteListToXML(List<Restaurant> listToWrite)
        {
            
            var path = filePath + "//restaurants.xml";
            System.IO.FileStream createdFile = System.IO.File.Create(path);

            xmlSerial = new XmlSerializer(typeof(List<Restaurant>));

            xmlSerial.Serialize(createdFile, listToWrite);
            createdFile.Close();

        }
    }


}
