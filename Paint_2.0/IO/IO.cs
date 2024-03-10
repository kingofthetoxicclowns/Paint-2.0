using System.Drawing.Imaging;

namespace Paint_2._0.IO
{
    public static class IO
    {

        public static List<string> fileFormats { get; set; } = new List<string>()
            { "svg", "img", "jpg", "png" };

        /// <summary>
        /// Создаёт строку фильтра файлов по их расширению для экземпляра класса SaveFileDialog.
        /// </summary>
        public static string MakeFileFilter()
        {
            string filterString = "";
            for (int i = 0; i < fileFormats.Count; i++)
                filterString += fileFormats[i] + "|*." + fileFormats[i].ToLower() + "|";
            
            return filterString.Substring(0, filterString.Length - 1);
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
        public static int SVGToBitmapFormat()
        {
            return 0;
        }

        // Из SVG-файла формирует контейнер фигур.
        public static int SVGToCanvas()
        {
            return 0;
        }
    }
}
