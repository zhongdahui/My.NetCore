using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace My.NetCore.Framework.Helpers
{
    public class QRCodeHelper
    {
        /// <summary>
        /// 普通二维码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static MemoryStream GetQRCode(string data, int pixel = 5)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);
            Bitmap qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, true);

            MemoryStream stream = new MemoryStream();

            try
            {
                qrImage.Save(stream, ImageFormat.Png);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qrImage.Dispose();
            }
        }

        /// <summary>
        /// 带logo的二维码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="logoPath"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static MemoryStream GetLogoQRCode(string data, string logoPath, int pixel = 5)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);
            Bitmap icon = new Bitmap(logoPath);
            Bitmap qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, icon, 15, 6, true);
            #region 参数介绍
            //GetGraphic方法参数介绍
            //pixelsPerModule //生成二维码图片的像素大小 ，我这里设置的是5
            //darkColor       //暗色   一般设置为Color.Black 黑色
            //lightColor      //亮色   一般设置为Color.White  白色
            //icon             //二维码 水印图标 例如：Bitmap icon = new Bitmap(context.Server.MapPath("~/images/zs.png")); 默认为NULL ，加上这个二维码中间会显示一个图标
            //iconSizePercent  //水印图标的大小比例 ，可根据自己的喜好设置
            //iconBorderWidth  // 水印图标的边框
            //drawQuietZones   //静止区，位于二维码某一边的空白边界,用来阻止读者获取与正在浏览的二维码无关的信息 即是否绘画二维码的空白边框区域 默认为true
            #endregion
            MemoryStream stream = new MemoryStream();

            try
            {
                qrImage.Save(stream, ImageFormat.Png);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qrImage.Dispose();
            }
        }
    }
}
