using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace iTrip.Utility
{
    
    public class PubConstant
    {  
        #region [ͨ�÷���]
	    /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.AppSettings["AccessConnectionString"];       
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString; 
            }
        }

        /// <summary>
        /// �õ�web.config������������ݿ������ַ�����
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        public static int GetAppSetting(string configName){
            string settingString = ConfigurationManager.AppSettings[configName];
            if(Utils.isInt(settingString))
            {
                return Convert.ToInt32(settingString);
            }else{
                return 0;
            }
        }
	    #endregion
      

        /********************************************************����********************************************************/
        //Ӧ��ID
        public static string APP_TYPE_ID_0 = "0";

        //��ȡ��Դ����
        public static int GetField(string tableName,string fieldName)
        {
            string prefix = "FIELD.";
            return GetAppSetting(prefix + tableName + "." + fieldName);
        }
    }
}
