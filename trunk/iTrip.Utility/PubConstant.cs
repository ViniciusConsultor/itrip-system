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
        //Ӧ���û���Ϣ
        public static string APP_SESSION_USER_OBJECT = "APP_SESSION_USER_OBJECT";
        public static string USER_SESSION_FLIGHT_ORDER_OBJECT = "USER_SESSION_FLIGHT_ORDER_OBJECT";
        public static string USER_SESSION_HOTEL_ORDER_OBJECT = "USER_SESSION_HOTEL_ORDER_OBJECT";
        public static string SITE_NAVIGATE_MENU_OBJECT = "SITE_NAVIGATE_MENU_OBJECT";
        public static string CURRENT_NAVIGATE_MENU_ITEM = "CURRENT_NAVIGATE_MENU_ITEM";
        //��ȡ��Դ����
        public static int GetField(string tableName,string fieldName)
        {
            string prefix = "FIELD.";
            return GetAppSetting(prefix + tableName + "." + fieldName);
        }
    }
}
