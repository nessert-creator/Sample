using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CourseManager.Models.ValidatableObjects
{
    public static class EncryptExtensions
    {
        /// <summary>
        ///     MD5 加密字符串
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5Encoding(this string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            var sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString().ToUpper();
        }

        #region 加密Key
        private const string QueryStringKey = "@#$%!&*%"; //URL传输参数加密Key这个key可以自己设置支持8位这个东西很重要的
        #endregion

        #region 加密算法
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string EncryptQueryString(this string queryString)
        {
            return Encrypt(queryString, QueryStringKey);
        }
        #endregion

        #region 解密算法
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string DecryptQueryString(this string queryString)
        {
            try
            {
                return Decrypt(queryString, QueryStringKey);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //把字符串放到byte数组中

            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            des.Key = Encoding.ASCII.GetBytes(sKey); //建立加密对象的密钥和偏移量
            des.IV = Encoding.ASCII.GetBytes(sKey); //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            MemoryStream ms = new MemoryStream(); //使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = Encoding.ASCII.GetBytes(sKey); //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}