using System;
using System.IO;
using System.Net;
using System.Text;
using System.Json;
using System.Linq;


namespace RestJSONConsoleApp
{
    public class StateData
    {
        public string StateName { get; set; }
        public string StateAbbr { get; set; }
        public string LargestCity { get; set; }
        public string Capital { get; set; }
    }

    public class Program
    {
        public static StateData GetDataByStateAbbr(StateData[] sd, string abbr)
        {
            return sd.Where(s => s.StateAbbr.ToLower() == abbr.ToLower()).FirstOrDefault();
        }

        public static StateData GetDataByStateName(StateData[] sd, string name)
        {
            return sd.Where(s => s.StateName.ToLower() == name.ToLower()).FirstOrDefault();
        }

        static void Main(string[] args)
        {
            string url = "http://services.groupkt.com/state/get/USA/all";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream respstream = res.GetResponseStream();
            StreamReader sr = new StreamReader(respstream, Encoding.UTF8);

            string allstatedata = sr.ReadToEnd();

            var restresponseresult = JsonValue.Parse(allstatedata);
            var messagesresult = restresponseresult["RestResponse"];
            var results = messagesresult["result"];

            StateData[] stateArray = new StateData[results.Count];
            int i = 0;

            StateData[] stateArray2 = new StateData[results.Count];

            foreach (JsonValue j in results)
            {
                stateArray[i] = new StateData() { StateName = j["name"], StateAbbr = j["abbr"], LargestCity = j["largest_city"], Capital = j["capital"] };
                i = i + 1;
            }

            string userEntry;

            do
            {
                Console.WriteLine("Enter State Name or State Abbreviation or EXIT: ");
                userEntry = Console.ReadLine();

                if (userEntry.Length == 2)
                {
                    var r = GetDataByStateAbbr(stateArray, userEntry);

                    if (r == null)
                    {
                        Console.WriteLine("Invalid State Abbreviation!!! \n");
                    }
                    else
                    {
                        Console.WriteLine("Largest City is: {0}", r.LargestCity.ToString());
                        Console.WriteLine("Capital is: {0} \n", r.Capital.ToString());
                    }
                }
                else
                {
                    var r = GetDataByStateName(stateArray, userEntry);

                    if (r == null)
                    {
                        Console.WriteLine("Invalid State Name!!! \n");
                    }
                    else
                    {
                        Console.WriteLine("Largest City is: {0}", r.LargestCity.ToString());
                        Console.WriteLine("Capital is: {0} \n", r.Capital.ToString());
                    }
                }
            } while (userEntry.ToLower() != "exit");

        }
    }
}
