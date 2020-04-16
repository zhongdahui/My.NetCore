using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace My.NetCore.Helpers
{
    public class BarCodeHelper
    {
        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="message"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static MemoryStream CreateBarCode(string data, int width, int height)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.UPCA, data, Color.Black, Color.White, width, height);

            MemoryStream stream = new MemoryStream();

            try
            {
                img.Save(stream, ImageFormat.Png);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                img.Dispose();
            }
        }
    }
}
