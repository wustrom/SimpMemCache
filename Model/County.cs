using System;

namespace Model
{

    /// <summary>
    /// 区县
    /// </summary>
    [Serializable]
    public class County : BaseModel
    {
        /// <summary>
        /// 区县名称
        /// </summary>
        public string CountyName { get; set; }

        public int CityId { get; set; }
    }
}
