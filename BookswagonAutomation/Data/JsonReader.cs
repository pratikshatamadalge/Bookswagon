using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookswagonAutomation.Data
{
    public class JsonReader
    {
        public string email = "";
        public string password = "";
        public string json = "";
        public string search = "";
        public string receipentName = "";
        public string address = "";
        public string state = "";
        public string city = "";
        public string pincode = "";
        public string mobileno = "";
        public string giftmessage = "";
        

        public JsonReader()
        {
            using (StreamReader r = new StreamReader("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\Data\\Data.json"))
            {
                json = r.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Array::::" + array["email"]);
            email = array["email"];
            password = array["password"];
            search = array["search"];
            receipentName = array["receipentName"];
            address = array["address"];
            state = array["state"];
            city = array["city"];
            pincode = array["pincode"];
            mobileno = array["mobileno"];
            giftmessage = array["giftmessage"];
        }
    }
}
