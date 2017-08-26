using System;

namespace Model
{
    /// <summary>
    /// 分页基类
    /// </summary>
    [Serializable]
    public abstract class PageInfo
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }


        private int beginRecordNumber;
        /// <summary>
        /// 开始记录
        /// </summary>
        public int BeginRecordNumber
        {
            get
            {
                beginRecordNumber = (CurrentPage - 1) * RecordCount + 1;
                return beginRecordNumber;
            }
        }

        private int endRecordNumber;
        /// <summary>
        /// 结束记录
        /// </summary>
        public int EndRecordNumber
        {
            get
            {
                endRecordNumber = CurrentPage * RecordCount;
                return endRecordNumber;
            }
        }

        public int RecordNumber { get; set; }
    }
}
