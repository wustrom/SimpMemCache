using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Configuration;

namespace ConsoleApp
{
    using DotNet.Common.EnyimCache;
    using Model;

    class Program
    {
        static void Main(string[] args)
        {
            ICacheWriterService writer = CacheBuilder.GetWriterService();//writer 使用memcached默认过期时间
            ICacheReaderService reader = CacheBuilder.GetReaderService();//reader

            #region 字符串

            string strKey = "hello";

            bool isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, "hello world"); //添加
            Console.WriteLine("Add key {0}, value:hello world", strKey);

            bool isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            string result = reader.Get(strKey) as string;//查询
            Console.WriteLine("Get key {0}:{1}", strKey, result);

            bool isModify = writer.Modify(strKey, "Hello Memcached!");//修改
            Console.WriteLine("Modify key {0}, value:Hello Memcached. The result is:{1}", strKey, isModify);

            result = reader.Get<string>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, result);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            result = reader.Get(strKey) as string;
            Console.WriteLine("Get key {0}:{1}", strKey, result);

            result = reader.Get<string>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, result);
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.Read();

            #endregion

            #region 数组

            strKey = "binarr";
            byte[] arr = BitConverter.GetBytes(123);//字节数组
            Console.WriteLine("Byte arr length:{0}", arr.Length);
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, arr); //添加
            Console.WriteLine("Add key {0}, value:hello world", strKey);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            byte[] queryArr = reader.Get(strKey) as byte[];//查询
            Console.WriteLine("Get key {0},byte arr length:{1}", strKey, queryArr.Length);

            arr = reader.Get<byte[]>(strKey);
            Console.WriteLine("Get key {0},byte arr length:{1}", strKey, queryArr.Length);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<byte[]>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.Read();

            #endregion

            #region 数字

            strKey = "number";
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, 123456); //添加
            Console.WriteLine("Add key {0}, value:123456", strKey);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            int num = (int)reader.Get(strKey);//查询
            Console.WriteLine("Get key {0}:{1}", strKey, num);

            num = reader.Get<int>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, num);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<int>(strKey));//default(int) 默认为0
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();

            #endregion

            #region 时间

            DateTime dtNow = DateTime.Now;
            strKey = "datetime";
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, dtNow); //添加
            Console.WriteLine("Add key {0}, value:{1}", strKey, dtNow);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            DateTime dt = (DateTime)reader.Get(strKey);//查询
            Console.WriteLine("Get key {0}:{1}", strKey, dt);

            dt = reader.Get<DateTime>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, dt);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<DateTime>(strKey));//default(datetime)
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();

            #endregion

            #region 类

            dtNow = DateTime.Now;
            Province province = new Province(13579, "江苏", dtNow, dtNow);

            strKey = string.Format("{0}_{1}", province.GetType().Name, province.Id);//省
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, province); //添加
            Console.WriteLine("Add key {0}, value:{1}", strKey, dtNow);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Province queryProvince = (Province)reader.Get(strKey);//查询
            Console.WriteLine("Get key {0}:{1}", strKey, queryProvince.ProvinceName);

            queryProvince = reader.Get<Province>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, queryProvince.ProvinceName);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<Province>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();

            #endregion

            #region 集合(列表)

            dtNow = DateTime.Now;
            IList<City> listCities = new List<City>();
            City city = new City(135, province.Id, "南京", "210000", dtNow, dtNow);
            listCities.Add(city);
            city = new City(246, province.Id, "苏州", "215000", dtNow, dtNow);
            listCities.Add(city);

            strKey = string.Format("List_{0}_{1}_{2}", province.GetType().Name, province.Id, city.GetType().Name);//省份对应城市
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, listCities); //添加
            Console.WriteLine("Add key {0}, value:", strKey);
            foreach (var item in listCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Id, item.CityName);
            }

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            IList<City> queryCities = reader.Get(strKey) as IList<City>;//查询
            Console.WriteLine("Get key {0}:", strKey);
            foreach (var item in queryCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Id, item.CityName);
            }

            queryCities = reader.Get<IList<City>>(strKey);
            Console.WriteLine("Generic get key {0}:", strKey);
            foreach (var item in queryCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Id, item.CityName);
            }

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<IList<City>>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();

            #endregion

            #region 集合(字典)

            dtNow = DateTime.Now;
            IDictionary<int, City> dictCities = new Dictionary<int, City>();
            city = new City(123, province.Id, "镇江", "212000", dtNow, dtNow);
            dictCities.Add(city.Id, city);
            city = new City(321, province.Id, "扬州", "225000", dtNow, dtNow);
            dictCities.Add(city.Id, city);

            strKey = string.Format("Dictionary_{0}_{1}_{2}", province.GetType().Name, province.Id, city.GetType().Name);//省份对应城市
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, dictCities); //添加
            Console.WriteLine("Add key {0}, value:", strKey);
            foreach (var item in dictCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Key, item.Value.CityName);
            }

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            IDictionary<int, City> queryDictCities = reader.Get(strKey) as IDictionary<int, City>;//查询
            Console.WriteLine("Get key {0}:", strKey);
            foreach (var item in queryDictCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Key, item.Value.CityName);
            }

            queryDictCities = reader.Get<IDictionary<int, City>>(strKey);
            Console.WriteLine("Generic get key {0}:", strKey);
            foreach (var item in queryDictCities)
            {
                Console.WriteLine("CityId:{0} CityName:{1}", item.Key, item.Value.CityName);
            }

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<IDictionary<int, City>>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();

            #endregion

            #region datatable

            DataTable dataTable = new DataTable("test datatable");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            DataRow dr = dataTable.NewRow();
            dr["Id"] = 1;
            dr["Name"] = "test";
            dataTable.Rows.Add(dr);

            strKey = "datatable";
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, dataTable); //添加
            Console.WriteLine("Add key {0}, value:{1}", strKey, dataTable.TableName);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            DataTable queryTable = (DataTable)reader.Get(strKey);//查询
            Console.WriteLine("Get key {0}:{1}", strKey, queryTable.TableName);

            queryTable = reader.Get<DataTable>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, queryTable.TableName);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<DataTable>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();


            #endregion

            #region dataset

            DataSet ds = new DataSet("test dataset");
            ds.Tables.Add(dataTable);

            strKey = "dataset";
            isOK = writer.Remove(strKey); //移除
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            writer.Add(strKey, ds); //添加
            Console.WriteLine("Add key {0}, value:{1}", strKey, dataTable.TableName);

            isExists = reader.isExists(strKey);//是否存在
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            DataSet queryDataSet = (DataSet)reader.Get(strKey);//查询
            Console.WriteLine("Get key {0}:{1}", strKey, queryDataSet.DataSetName);

            queryDataSet = reader.Get<DataSet>(strKey);
            Console.WriteLine("Generic get key {0}:{1}", strKey, queryDataSet.DataSetName);

            isOK = writer.Remove(strKey);
            Console.WriteLine("Removed key {0}:{1}", strKey, isOK);

            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);

            Console.WriteLine("Get key {0}:{1}", strKey, reader.Get(strKey));

            Console.WriteLine("Generic get key {0}:{1}", strKey, reader.Get<DataSet>(strKey));
            Console.WriteLine();
            Console.WriteLine("===========================================");

            Console.Read();


            #endregion

            #region 显式指定过期时间

            Console.WriteLine("Start test expiration time...");
            int minutes = 1;//过期时间 1分钟 Math.Abs(int.Parse(ConfigurationManager.AppSettings["ExpirationTime"])); 可配置
            writer = CacheBuilder.GetWriterService(minutes);//writer 使用memcached默认过期时间
            strKey = "expirationtime";
            dtNow = DateTime.Now;
            writer.Add<DateTime>(strKey, dtNow);//添加
            //Thread.Sleep(10);
            DateTime current = reader.Get<DateTime>(strKey);
            Console.WriteLine("Get key {0}:{1}", strKey, current);
            Thread.Sleep(minutes * 1000 * 60 + 1);
            Console.WriteLine("After {0} minutes,current time:{1}...", minutes, DateTime.Now);
            isExists = reader.isExists(strKey);
            Console.WriteLine("Key {0} exists:{1}", strKey, isExists);
            if (isExists == false)
            {
                Console.WriteLine("As you see,it's not exists now.");
            }

            #endregion

            Console.Read();
        }
    }
}
