using System;

namespace Model
{

    /// <summary>
    /// 省份
    /// </summary>
    [Serializable]
    public class Province : BaseModel
    {
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        public Province()
        {

        }

        public Province(int id, string provinceName, DateTime createDate, DateTime updateDate)
        {
            this.Id = id;
            this.ProvinceName = provinceName;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
        }

    }
}
