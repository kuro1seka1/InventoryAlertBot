using InventoryAlertBot;
using InventoryAlertBot.resources.DBContext;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace InventoryAlertBot
{
    class Programm
    {


        static async Task Main(string[] args)
        {

            WatchDogDB watchDog = new WatchDogDB();

            watchDog.WatchDog();

           
        }  
            

        

    }
}


