using InventoryAlertBot.resources.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAlertBot
{
     class WatchDogDB
    {
        public void WatchDog()
        {

            InvDbContext contextForWatch = new InvDbContext();
            var invent = contextForWatch.Inventories.ToList();
            var filial = contextForWatch.Filials.ToList();
            var cabinet = contextForWatch.Cabinets.ToList();

            const string TELEGRAM_TOKEN = "bot6287353815:AAEgpKusKnIXPm4VjgaNm7DJXkBohTnXxV4";
            const string CHAT_ID = "-1001971411415";

            DateTime now = DateTime.Now;

            for (int i = 0; i < invent.Count; i++)
            {
                var dateinvent = invent.Select(x => x.Datenextpov).ToList();
                if (dateinvent[i] == null)
                {
                    continue;
                }
                else
                {
                    DateTime date = (DateTime)dateinvent[i];
                    TimeSpan interval = date.Subtract(now);
                    
                    if (invent.Select(x => x.Datenextpov).ToList() == null)
                    {
                        continue;
                    }
                    else if (interval.TotalDays < 30)
                    {
                        String Message = "";
                        var name = invent.Select(x => x.Inventname).ToList();
                        var filials = invent.Select(y=>y.Filial.Filialname).ToList();
                        var cabinets = invent.Select(z=>z.Cabinet.Cabinetname).ToList();
                        string nameToURL = name[i];
                        string filialToURL = filials[i];
                        string cabinetToURL = cabinets[i];
                        string MessageToUrl =  $"Прибор \"{nameToURL}\"на филиале \"{filialToURL}\" в кабинете \"{cabinetToURL}\" скоро подлежит поверке дата следующей поверки {date:d}\n" + Message;
                        HttpClient client = new HttpClient();
                        string url = $"https://api.telegram.org/bot{TELEGRAM_TOKEN}/sendMessage?chat_id={CHAT_ID}&text={MessageToUrl}\r\n";
                        var response = client.Response(url);
                        Console.WriteLine(response.Result);
                    }


                }
                    
             }

        }
            

        
     }
}
