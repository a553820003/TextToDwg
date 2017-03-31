using System;

namespace YongHongSoft.YueChi
{
   public static class TextTypeValidation
    {
        public static bool IsDouble(string text)
        {
            double x;

            try
            {
                x = double.Parse(text.Trim());

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsInt(string text)
        {
            int x;

            try
            {
                x = Int32.Parse(text.Trim());
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsEmpty(string text)
        {
            text = text.Trim();
            return string.IsNullOrEmpty(text);
        }
    }
}
