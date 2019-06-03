using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Parcer.Library;

namespace Parcer.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> car_list = new List<Car>();
            CookieContainer cookie = Library.Parcer.EnterSite("", "");
            //var cookis = ParcerAsync.EnterSite("", "");
            Brand brand_Mercedes = new Brand("683", "Mercedes");
            Model model_Eclass = new Model("5884", "E-class");
            Generation gen_W211 = new Generation("4556", "W211");
            Query query_W211 = new Query() { BrandID = brand_Mercedes.ID, ModelID = model_Eclass.ID, GenerationID = gen_W211.ID };
            //GetCarsAsync(cookie, query_W211, car_list);
            Task<List<Car>> task = Task.Run(() => Library.Parcer.GetAllCars(cookie, query_W211));
            while (!task.IsCompleted)
            {
                Console.Clear();
                Console.Write("Load car list");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    if (!task.IsCompleted)
                        Thread.Sleep(1000);
                }
            }
            Console.Clear();
            car_list = task.Result;
            int count_car = 0;
            Console.WriteLine("Output car list..............");
            foreach (var car in car_list)
            {
                Console.WriteLine("------------------- " + (++count_car).ToString() + " -------------------");
                Console.WriteLine("\t" + car.Name);
                Console.WriteLine(car.Description);
                Console.WriteLine("\t" + car.Price.ToString() + "$\t" + car.Year.ToString() + "г.в.\t" + car.City + "\t" + car.PublicationDate.ToShortDateString());
                Console.WriteLine("-------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
