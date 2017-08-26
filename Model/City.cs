using System;

namespace Model
{

    /// <summary>
    /// 城市
    /// </summary>
    [Serializable]
    public class City : BaseModel
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        public string ZipCode { get; set; }

        public int ProvinceId { get; set; }


        public City()
        {
        }

        public City(int id, int provinceId, string cityName, string zipCode, DateTime createDate, DateTime updateDate)
        {
            this.Id = id;
            this.ProvinceId = provinceId;
            this.CityName = cityName;
            this.ZipCode = zipCode;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
        }

    }
}
