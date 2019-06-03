using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;

namespace Parcer.Library
{
    public static class ParcerAsync
    {
        /// <summary>
        /// Выполняет авторизацию на сайте и возвращает пполученные при авторизации Cookies (Асинхронный метод)
        /// </summary>
        /// <param name="login">Логин для авторизации</param>
        /// <param name="password">Пароль для авторизации</param>
        /// <returns></returns>
        public static async Task<CookieContainer> EnterSite(string login, string password)
        {
            return await Task.Run(() => Parcer.EnterSite(login, password));
        }

        /// <summary>
        /// Возвращает количество страниц, отображаемых на сайте после выполнения запроса (Асинхронный метод)
        /// </summary>
        /// <param name="query">Запрос, посылаемый на сайт</param>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <returns></returns>
        public static async Task<int> GetCountPage(Query query, CookieContainer cookie)
        {
            return await Task.Run(() => Parcer.GetCountPage(query, cookie));
        }

        /// <summary>
        /// Возвращает список объектов типа Car, полученных со страницы сайта (Асинхронный метод)
        /// </summary>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <param name="query">Запрос, посылаемый на сайт</param>
        /// <returns></returns>
        public static async Task<List<Car>> GetCarsFromPage(CookieContainer cookie, Query query)
        {
            return await Task.Run(() => Parcer.GetCarsFromPage(cookie, query));
        }

        /// <summary>
        /// Возвращает спсок автомобилей со всех страниц (Асинхронный метод)
        /// </summary>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <param name="query">Запрос, посылаемый на сайт</param>
        /// <returns></returns>
        public static async Task<List<Car>> GetAllCars(CookieContainer cookie, Query query)
        {
            return await Task.Run(() => Parcer.GetAllCars(cookie, query));
        }

        /// <summary>
        /// Возвращает все марки автомобилей, полученных с сайта (Асинхронный метод)
        /// </summary>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <returns></returns>
        public static async Task<List<Brand>> GetBrands(CookieContainer cookie)
        {
            return await Task.Run(() => Parcer.GetBrands(cookie));
        }

        /// <summary>
        /// Возвращает все модели автомобилей заданной марки (Асинхронный метод)
        /// </summary>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <param name="brand">Объект класса Brand (марка автомобиля)</param>
        /// <returns></returns>
        public static async Task<List<Model>> GetModels(CookieContainer cookie, Brand brand)
        {
            return await Task.Run(() => Parcer.GetModels(cookie, brand));
        }

        /// <summary>
        /// Возвращает все поколения автомобилей заданной марки и модели (Асинхронный метод)
        /// </summary>
        /// <param name="cookie">Cookie, полученные при авторизации</param>
        /// <param name="brand">Объект класса Brand (марка автомобиля)</param>
        /// <param name="model">Объект класса Model (модель автомобиля)</param>
        /// <returns></returns>
        public static async Task<List<Generation>> GetGenerations(CookieContainer cookie, Brand brand, Model model)
        {
            return await Task.Run(() => Parcer.GetGenerations(cookie, brand, model));
        }
    }
}
