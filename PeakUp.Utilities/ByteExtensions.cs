namespace PeakUp.Utilities
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Parse byte[] to string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ConvertString(this byte[] bytes)
        {
            string sbinary = "";
            for (int i = 0; i < bytes.Length; i++)
                sbinary += bytes[i].ToString("X2");
            return sbinary;
        }
    }
}
