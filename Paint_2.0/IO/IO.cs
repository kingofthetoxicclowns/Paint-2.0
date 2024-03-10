using System.Drawing.Imaging;
using Svg;

namespace Paint_2._0.IO
{
    public static class IO
    {

        public static List<string> FileFormats { get; set; } =
            ["svg", "img", "jpeg", "png"];

        /// <summary>
        /// Создаёт строку фильтра файлов по их расширению для экземпляра класса SaveFileDialog.
        /// </summary>
        public static string MakeFileFilter()
        {
            string filterString = "";
            for (int i = 0; i < FileFormats.Count; i++)
                filterString += $"{FileFormats[i]}|*.{FileFormats[i].ToLower()}|";
            
            return filterString[..^1];
        }

        // Получает информацию кодировщика заданного формата изображения.
        private static ImageCodecInfo? GetEncoderInfo(String mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo? encoder = Array.Find(encoders, encoder => encoder.MimeType == mimeType);

            return encoder;
        }

        // Сохраняет накаляканное в файл.
        public static int Save(Bitmap bm, string fileName, int width, int height)
        {
            Bitmap btm = bm.Clone(new Rectangle(0, 0, width, height), bm.PixelFormat);
            btm.Save(fileName, ImageFormat.Jpeg);

            return 0;
        }

        // Из контейнера фигур формирует SVG-файл.
        public static int CanvasToSVG()
        {
            return 0;
        }

        // Из SVG-файла переводит в указанный растровый формат.
        public static void SVGToBitmapFormat(string svgPath, string outputPath, string bitmapFormat)
        {
            Bitmap bitmap;
            SvgDocument svgDoc;
            ImageCodecInfo? myImageCodecInfo;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            long ImageQuality;

            svgDoc = SvgDocument.Open(svgPath);
            bitmap = svgDoc.Draw();

            myImageCodecInfo = GetEncoderInfo(mimeType: $"image/{bitmapFormat}");
            if (myImageCodecInfo is null || !FileFormats.Contains(bitmapFormat))
                throw new Exception("Указанный формат изображения не поддерживается.");

            ImageQuality = 100L;

            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(Encoder.Quality, ImageQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            bitmap.Save(outputPath, myImageCodecInfo, myEncoderParameters);
        }

        // Из SVG-файла формирует контейнер фигур.
        public static int SVGToCanvas()
        {
            return 0;
        }
    }
}
