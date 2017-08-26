using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 实体公共字段基类
    /// </summary>
    [Serializable]
    public abstract class BaseModel : PageInfo
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        #endregion

    }
}
