using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace YongHongSoft.YueChi
{
  public  static class XmlHelper
    {
        /// <summary>
        ///     XML序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object Load(Type type, string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("没有找到文件",path);
            try
            {
                FileStream fileStream = File.OpenRead(path);
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                object obj = xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
                
            }
        }
        public static bool Save(object obj, string path)
        {
            FileStream sw = File.OpenWrite(path);
            try
            {
                Type type = obj.GetType();

                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(sw, obj);
                sw.Flush();
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                sw.Close();
                return false;
            }
        }
    }
}
