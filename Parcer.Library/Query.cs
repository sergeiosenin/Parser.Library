using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcer.Library
{
    public class Query
    {
        public string BrandID { get; set; } //марка авто
        public string ModelID { get; set; } //модель авто
        public string GenerationID { get; set; }    //поколение авто
        public string Year_from { get; set; }   //год выпуска с
        public string Year_to { get; set; } //год выпуска по
        public string Price_from { get; set; }  //цена с
        public string Price_to { get; set; }    //цена по
        public string Transmission { get; set; }    //тип КПП
        public string Body_id { get; set; } //тип кузова
        public string Engine_type { get; set; } //тип двигателя
        public string Engine_volume_min { get; set; }   //объем двигателя с
        public string Engine_volume_max { get; set; }   //объем двиагателя по
        public string Driving_id { get; set; }  //привод
        public string Mileage_min { get; set; } //пробег от
        public string Mileage_max { get; set; } //пробег до
        public string Region_id { get; set; }   //область
        public string City_id { get; set; } //город
        public string Interior_material { get; set; }   //материал салона
        public string Interior_color { get; set; }  //цвет салона
        public string Exchange { get; set; }    //обмен
        public string Search_time { get; set; } //поиск за время
        public bool IsMultiPage { get; set; }
        public int PageNumber { get; set; }
        public string WebLink
        {
            get
            {
                return IsMultiPage ?
                    @"https://cars.av.by/search/page/" + PageNumber.ToString() + "?brand_id%5B0%5D="
                + BrandID + "&model_id%5B0%5D=" + ModelID + "&generation_id%5B0%5D=" + GenerationID
                + "&year_from=" + Year_from + "&year_to=" + Year_to
                + "&currency=USD"
                + "&price_from=" + Price_from + "&price_to=" + Price_to
                + "&transmission=" + Transmission
                + "&body_id=" + Body_id
                + "&engine_type=" + Engine_type
                + "&engine_volume_min=" + Engine_volume_min + "&engine_volume_max=" + Engine_volume_max
                + "&driving_id=" + Driving_id
                + "&mileage_min=" + Mileage_min + "&mileage_max=" + Mileage_max
                + "&region_id=" + Region_id + "&city_id="+ City_id
                + "&interior_material=" + Interior_material
                + "&interior_color=" + Interior_color 
                + "&exchange=" + Exchange
                + "&search_time=" + Search_time
                :
                    @"https://cars.av.by/search?brand_id%5B0%5D="
                + BrandID + "&model_id%5B0%5D=" + ModelID + "&generation_id%5B0%5D=" + GenerationID
                + "&year_from=" + Year_from + "&year_to=" + Year_to
                + "&currency=USD"
                + "&price_from=" + Price_from + "&price_to=" + Price_to
                + "&transmission=" + Transmission
                + "&body_id=" + Body_id
                + "&engine_type=" + Engine_type
                + "&engine_volume_min=" + Engine_volume_min + "&engine_volume_max=" + Engine_volume_max
                + "&driving_id=" + Driving_id
                + "&mileage_min=" + Mileage_min + "&mileage_max=" + Mileage_max
                + "&region_id=" + Region_id + "&city_id=" + City_id
                + "&interior_material=" + Interior_material
                + "&interior_color=" + Interior_color 
                + "&exchange=" + Exchange
                + "&search_time=" + Search_time;
            }
        }

        public Query()
        {
            BrandID = "";
            ModelID = "";
            GenerationID = "";
            Year_from = "";
            Year_to = "";
            Price_from = "";
            Price_to = "";
            Transmission = "";
            Body_id = "";
            Engine_type = "";
            Engine_volume_min = "";
            Engine_volume_max = "";
            Driving_id = "";
            Mileage_min = "";
            Mileage_max = "";
            Region_id = "";
            City_id = "";
            Interior_material = "";
            Interior_color = "";
            Exchange = "";
            Search_time = "";
        }

    }
}
