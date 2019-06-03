using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using Parcer.Library;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            int page_count;
            List<Car> car_list = new List<Car>();
            CookieContainer cookies = Parcer.Library.Parcer.EnterSite("", "");
            var cookis = ParcerAsync.EnterSite("", "");
            CookieContainer cookie = Task.Run(()=> ParcerAsync.EnterSite("", ""));
            Brand brand_Mercedes = new Brand("683", "Mercedes");
            Model model_Eclass = new Model("5884", "E-class");
            Generation gen_W211 = new Generation("4556", "W211");
            Query query_W211 = new Query() { BrandID = brand_Mercedes.ID, ModelID = model_Eclass.ID, GenerationID = gen_W211.ID };
            //GetCarsAsync(cookie, query_W211, car_list);
            Task<List<Car>> task = Task.Run(() => GetAllCars(cookie, query_W211));
            //Task.WaitAll(Task.Run(() => GetAllCars(cookie, query_W211)));
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



        static async Task<List<Car>> GetCarsAsync(CookieContainer cookie, Query query)
        {
            return await Task.Run(() => Parcer.GetAllCars(cookie, query));
        }

        ///// <summary>
        ///// Выполняет авторизацию на сайте и возвращает пполученные при авторизации Cookies
        ///// </summary>
        ///// <param name="login">Логин для авторизации</param>
        ///// <param name="password">Пароль для авторизации</param>
        ///// <returns></returns>
        //public static CookieContainer EnterSite(string login, string password)
        //{
        //    HttpWebResponse result = null;
        //    if (string.IsNullOrEmpty(login))
        //        login = @"xrk55394@qiaua.com";
        //    if (string.IsNullOrEmpty(password))
        //        password = @"Admin170894";
        //    var url_login = @"https://av.by/login";
        //    string[] cookieVal = null;

        //    try
        //    {
        //        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url_login);
        //        req.Method = "POST";
        //        req.ContentType = "application/x-www-form-urlencoded";
        //        req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //        //req.KeepAlive = true;
        //        req.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
        //        req.Headers.Add("Accept-Language", "ru");
        //        req.AllowAutoRedirect = false; // Важный пункт 
        //        req.Proxy.Credentials = CredentialCache.DefaultCredentials;
        //        byte[] SomeBytes = null;
        //        string FormParams = "login=xrk55394@qiaua.com&password=Admin170894&action=login";
        //        SomeBytes = Encoding.UTF8.GetBytes(FormParams);
        //        req.ContentLength = SomeBytes.Length;
        //        Stream newStream = req.GetRequestStream();
        //        newStream.Write(SomeBytes, 0, SomeBytes.Length);
        //        newStream.Close();
        //        result = (HttpWebResponse)req.GetResponse();
        //        if (result.Headers["Set-Cookie"] != null)
        //            cookieVal = result.Headers["Set-Cookie"].Split(new char[] { ',' });
        //        var ReceiveStream = result.GetResponseStream();
        //        Encoding encode = Encoding.GetEncoding("utf-8");
        //        var sr = new StreamReader(ReceiveStream, encode);
        //        var answer = sr.ReadToEnd();
        //        result.Close();
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(exp.Message);
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }

        //    CookieContainer cookie = new CookieContainer();
        //    if (cookieVal != null)
        //    {
        //        var cook = cookieVal.FirstOrDefault();
        //        if (cook != null)
        //        {
        //            string[] cookie1 = cook.Split(new char[] { ';' });
        //            cookie.Add(new Cookie(cookie1[0].Split(new char[] { '=' })[0], cookie1[0].Split(new char[] { '=' })[1],
        //                cookie1[1].Split(new char[] { '=' })[1], cookie1.Length > 2 ? cookie1[2].Split(new char[] { '=' })[1] : null));
        //        }
        //    }
        //    return cookie;
        //}

        ///// <summary>
        ///// Возвращает количество страниц, отображаемых на сайте после выполнения запроса
        ///// </summary>
        ///// <param name="query">Запрос, посылаемый на сайт</param>
        ///// <param name="cookie">Cookie, полученные при авторизации</param>
        ///// <returns></returns>
        //public static int GetCountPage(Query query, CookieContainer cookie)
        //{
        //    HtmlDocument doc = new HtmlDocument();
        //    int count_page = 0;
        //    bool isLastCount = false;
        //    if (query == null)
        //        return 0;
        //    while (!isLastCount)
        //    {
        //        if (count_page != 0)
        //        {
        //            query.IsMultiPage = true;
        //            query.PageNumber = count_page;
        //        }
        //        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create((string)query.WebLink);
        //        req.Method = "POST";
        //        req.ContentType = "application/x-www-form-urlencoded";
        //        req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //        req.CookieContainer = cookie;

        //        HttpWebResponse result = (HttpWebResponse)req.GetResponse();
        //        using (StreamReader stream = new StreamReader(
        //             result.GetResponseStream(), Encoding.UTF8))
        //        {
        //            doc.Load(stream);
        //            var pages_number = doc.DocumentNode.SelectNodes("//li[@class='pages-numbers-item ']").LastOrDefault();
        //            if (pages_number != null)
        //            {
        //                int page_count;
        //                if (int.TryParse(pages_number.InnerText, out page_count))
        //                {
        //                    if ((page_count - count_page) < 5)
        //                        isLastCount = true;
        //                    count_page = page_count;
        //                }
        //            }
        //        }
        //        result.Close();
        //    }
        //    query.IsMultiPage = false;
        //    return count_page;
        //}

        ///// <summary>
        ///// Возвращает список объектов типа Car, полученных со страницы сайта
        ///// </summary>
        ///// <param name="cookie">Cookie, полученные при авторизации</param>
        ///// <param name="query">Запрос, посылаемый на сайт</param>
        ///// <returns></returns>
        //public static List<Car> GetCarsFromPage(CookieContainer cookie, Query query)
        //{
        //    List<Car> car_list = new List<Car>();

        //    string webLink = query.WebLink;
        //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(webLink);
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //    req.CookieContainer = cookie;

        //    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //    HtmlDocument doc = new HtmlDocument();

        //    using (StreamReader stream = new StreamReader(
        //         resp.GetResponseStream(), Encoding.UTF8))
        //        doc.Load(stream);
        //    var node_listing = doc.DocumentNode.SelectSingleNode("//div[@class='listing-wrap']");
        //    var nodes = node_listing.SelectNodes(".//div[contains(@class,'listing-item ')]");
        //    if (nodes != null && nodes.Count > 0)
        //        foreach (var node in nodes)
        //        {
        //            #region Получение изображения
        //            var imageNode = node.SelectSingleNode(".//div[@class='listing-item-image']");
        //            if (imageNode != null)
        //            {
        //                var a_img = imageNode.SelectSingleNode(".//img");
        //                string img_link = "";
        //                if (a_img != null)
        //                {
        //                    img_link = a_img.Attributes["src"].Value;
        //                }
        //            }
        //            #endregion
        //            #region Получение цены, года выпуска и города
        //            int year = 0, val;
        //            string city = "";
        //            decimal price = 0, val_dec;
        //            var listing_priceNode = node.SelectSingleNode(".//div[@class='listing-item-price']");
        //            if (listing_priceNode != null)
        //            {
        //                var yearNode = listing_priceNode.SelectSingleNode("./span");
        //                if (yearNode != null && int.TryParse(yearNode.InnerText.Trim(), out val))
        //                    year = val;

        //                var cityNode = listing_priceNode.SelectSingleNode("./p[@class='listing-item-location']");
        //                if (cityNode != null)
        //                    city = cityNode.InnerText;

        //                var priceNode = listing_priceNode.SelectSingleNode("./small");
        //                if (priceNode != null && decimal.TryParse(priceNode.InnerText.Trim(), out val_dec))
        //                    price = val_dec;
        //            }
        //            #endregion
        //            #region Получение описания и даты публикации
        //            string description = "";
        //            var descNode = node.SelectSingleNode(".//div[@class='listing-item-message-in']");
        //            if (descNode != null)
        //                description = descNode.InnerText;

        //            DateTime datePub = DateTime.MinValue;
        //            var datePubNode = node.SelectSingleNode(".//div[@class='listing-item-date']");
        //            if (datePubNode != null)
        //            {
        //                datePub = ConvertToDate(datePubNode.InnerText);
        //            }
        //            #endregion
        //            #region получение наименования, описания
        //            string title = "";
        //            var title_div = node.SelectSingleNode(".//div[@class='listing-item-title']");
        //            if (title_div != null)
        //            {

        //                var h4 = title_div.SelectSingleNode("./h4");
        //                if (h4 != null)
        //                {
        //                    var a_tag = h4.SelectSingleNode("./a");
        //                    if (a_tag != null)
        //                        title = a_tag.InnerText.Trim();
        //                }
        //            }
        //            #endregion

        //            Car car = new Car()
        //            {
        //                Name = title,
        //                City = city,
        //                Price = price,
        //                Year = year,
        //                Description = description,
        //                PublicationDate = datePub
        //            };

        //            car_list.Add(car);
        //        }
        //    return car_list;
        //}

        //public static List<Car> GetAllCars(CookieContainer cookie, Query query)
        //{
        //    List<Car> car_list = null;
        //    int count_page = GetCountPage(query, cookie);
        //    if (count_page == 0)
        //        return car_list;
        //    if (count_page == 1)
        //    {
        //        car_list = GetCarsFromPage(cookie, query);
        //        return car_list;
        //    }

        //    car_list = GetCarsFromPage(cookie, query);
        //    query.IsMultiPage = true;
        //    for (int i = 2; i <= count_page; i++)
        //    {
        //        query.PageNumber = i;
        //        car_list.AddRange(GetCarsFromPage(cookie, query));
        //    }

        //    query.IsMultiPage = false;
        //    return car_list;
        //}

        ///// <summary>
        ///// Возвращает все марки автомобилей, полученных с сайта
        ///// </summary>
        ///// <param name="cookie">Cookie, полученные при авторизации</param>
        ///// <returns></returns>
        //public static List<Brand> GetBrands(CookieContainer cookie)
        //{
        //    List<Brand> brands = new List<Brand>();
        //    HtmlDocument doc = new HtmlDocument();
        //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(@"https://av.by/");
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //    req.CookieContainer = cookie;

        //    HttpWebResponse result = (HttpWebResponse)req.GetResponse();
        //    using (StreamReader stream = new StreamReader(
        //         result.GetResponseStream(), Encoding.UTF8))
        //    {
        //        doc.Load(stream);
        //        var selectNode = doc.DocumentNode.SelectSingleNode("//select[@name='brand_id[]']");
        //        if (selectNode != null)
        //        {
        //            var nodes = selectNode.ChildNodes;
        //            if (nodes != null && nodes.Count > 0)
        //                foreach (var node in nodes)
        //                {
        //                    if (node.Attributes["value"] != null)
        //                    {
        //                        var value = node.Attributes["value"].Value;
        //                        var name = node.InnerText;
        //                        if (!string.IsNullOrEmpty(value))
        //                        {
        //                            Brand brand = new Brand(value, name);
        //                            brands.Add(brand);
        //                        }
        //                    }
        //                }
        //        }
        //    }
        //    result.Close();

        //    return brands;
        //}
        ///// <summary>
        ///// Возвращает все модели автомобилей заданной марки
        ///// </summary>
        ///// <param name="cookie">Cookie, полученные при авторизации</param>
        ///// <param name="brand">Объект класса Brand (марка автомобиля)</param>
        ///// <returns></returns>
        //public static List<Model> GetModels(CookieContainer cookie, Brand brand)
        //{
        //    List<Model> models = new List<Model>();
        //    HtmlDocument doc = new HtmlDocument();
        //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(@"https://cars.av.by/search?brand_id%5B%5D=" + brand.ID
        //        + "&model_id%5B%5D=&year_from=&year_to=&currency=USD&price_from=&price_to=");
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //    req.CookieContainer = cookie;

        //    HttpWebResponse result = (HttpWebResponse)req.GetResponse();
        //    using (StreamReader stream = new StreamReader(
        //         result.GetResponseStream(), Encoding.UTF8))
        //    {
        //        doc.Load(stream);
        //        var selectNode = doc.DocumentNode.SelectSingleNode("//select[@name='model_id&#x5B;0&#x5D;']");
        //        if (selectNode != null)
        //        {
        //            var nodes = selectNode.ChildNodes;
        //            if (nodes != null && nodes.Count > 0)
        //                foreach (var node in nodes)
        //                {
        //                    if (node.Attributes["value"] != null)
        //                    {
        //                        var value = node.Attributes["value"].Value;
        //                        var name = node.InnerText;
        //                        if (!string.IsNullOrEmpty(value))
        //                        {
        //                            Model model = new Model(value, name);
        //                            models.Add(model);
        //                        }
        //                    }
        //                }
        //        }
        //    }
        //    result.Close();
        //    brand.Models.AddRange(models);
        //    return models;
        //}

        ///// <summary>
        ///// Возвращает все поколения автомобилей заданной марки и модели
        ///// </summary>
        ///// <param name="cookie">Cookie, полученные при авторизации</param>
        ///// <param name="brand">Объект класса Brand (марка автомобиля)</param>
        ///// <param name="model">Объект класса Model (модель автомобиля)</param>
        ///// <returns></returns>
        //public static List<Generation> GetGenerations(CookieContainer cookie, Brand brand, Model model)
        //{
        //    List<Generation> generations = new List<Generation>();
        //    HtmlDocument doc = new HtmlDocument();
        //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(@"https://cars.av.by/search?brand_id%5B%5D=" + brand.ID
        //        + "&model_id%5B%5D=" + model.ID + "&year_from=&year_to=&currency=USD&price_from=&price_to=");
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
        //    req.CookieContainer = cookie;

        //    HttpWebResponse result = (HttpWebResponse)req.GetResponse();
        //    using (StreamReader stream = new StreamReader(
        //         result.GetResponseStream(), Encoding.UTF8))
        //    {
        //        doc.Load(stream);
        //        var selectNode = doc.DocumentNode.SelectSingleNode("//select[@name='generation_id&#x5B;0&#x5D;']");
        //        if (selectNode != null)
        //        {
        //            var nodes = selectNode.ChildNodes;
        //            if (nodes != null && nodes.Count > 0)
        //                foreach (var node in nodes)
        //                {
        //                    if (node.Attributes["value"] != null)
        //                    {
        //                        var value = node.Attributes["value"].Value;
        //                        var name = node.InnerText;
        //                        if (!string.IsNullOrEmpty(value))
        //                        {
        //                            Generation gen = new Generation(value, name);
        //                            generations.Add(gen);
        //                        }
        //                    }
        //                }
        //        }
        //    }
        //    result.Close();
        //    model.Generations.AddRange(generations);
        //    return generations;
        //}

        ///// <summary>
        ///// Возвращает дату создания объявления
        ///// </summary>
        ///// <param name="datestr">Строка со значением даты</param>
        ///// <returns></returns>
        //public static DateTime ConvertToDate(string datestr)
        //{
        //    if (datestr.Contains("назад"))
        //        return DateTime.Now;
        //    if (datestr.Contains("вчера"))
        //        return DateTime.Now.AddDays(-1);
        //    string dayStr = datestr.Trim().Split(' ')[0];
        //    string monthStr = datestr.Trim().Split(' ')[1];

        //    List<string> monthes = new List<string> { "янв", "фев", "мар", "апр", "май", "июн", "июл", "авг", "сен", "окт", "ноя", "дек" };
        //    int val, day = 0, month = 0;
        //    if (int.TryParse(dayStr, out val))
        //        day = val;
        //    month = monthes.IndexOf(monthStr) + 1;

        //    return (day > 0 && month > 0) ? new DateTime(DateTime.Now.Year, month, day) : DateTime.MinValue;
        //}
    }
}
