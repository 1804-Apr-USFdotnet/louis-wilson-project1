using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;


namespace RestaurantReviews.Library
{
    public class RestaurantXMLHandler
    {
        XmlSerializer xmlSerial;
        string filePath = ConfigurationManager.AppSettings["xmlFile"];


        public RestaurantList ReadListFromXML()
        {
            RestaurantList newList = new RestaurantList();
            var path = filePath + "//restaurants.xml";

            /*
            var writer = new XmlSerializer(typeof(RestaurantList));
            var blankFile = new System.IO.StreamWriter(path);
            writer.Serialize(blankFile, newList);
            blankFile.Close();
            */

            XmlSerializer reader = new XmlSerializer(typeof(RestaurantList));
            var file = new System.IO.StreamReader(path);

            
            newList = (RestaurantList)reader.Deserialize(file);
            file.Close();

            return newList;
        }

        public void WriteListToXML(RestaurantList listToWrite)
        {
            
            var path = filePath + "//restaurants.xml";
            System.IO.FileStream createdFile = System.IO.File.Create(path);

            xmlSerial = new XmlSerializer(typeof(RestaurantList));

            xmlSerial.Serialize(createdFile, listToWrite);
            createdFile.Close();

        }
    }


}
