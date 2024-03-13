using System.Drawing.Imaging;
using Paint_2._0.Entities;
using Svg;
using System.Xml;
using System.Text;
using System.Globalization;

namespace Paint_2._0.IO
{
    public static class IO
    {

        public static List<string> FileFormats { get; set; } = new List<string>()
            { "svg", "img", "jpg", "png" };

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
        public static int CanvasToSVG(FigureContainer container, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement svgElement = doc.CreateElement("svg");
            svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("version", "1.1");
            doc.AppendChild(svgElement);

            foreach (var figure in container.Figures)
            {
                XmlElement figureElement = null;

                if (figure is Circle circle)
                {
                    figureElement = CreateCircleElement(doc, circle);
                }
                else if (figure is Line line)
                {
                    figureElement = CreateLineElement(doc, line);
                }
                else if (figure is Square square)
                {
                    figureElement = CreateSquareElement(doc, square);
                }

                if (figureElement != null)
                {
                    svgElement.AppendChild(figureElement);
                }
                else return 1;
            }

            doc.Save(filePath);
            return 0;
        }
        private static XmlElement CreateCircleElement(XmlDocument doc, Circle circle)
        {
            XmlElement circleElement = doc.CreateElement("circle");
            circleElement.SetAttribute("cx", circle.Center.X.ToString());
            circleElement.SetAttribute("cy", circle.Center.Y.ToString());
            circleElement.SetAttribute("r", circle.Radius.ToString("0.0", CultureInfo.InvariantCulture));
            circleElement.SetAttribute("stroke", circle.StrokeColor.Name.ToString());
            circleElement.SetAttribute("stroke-width", circle.StrokeThickness.ToString());
            if (circle.FillColor != null)
            {
                circleElement.SetAttribute("fill", circle.FillColor.ToString());
            }
            else
            {
                circleElement.SetAttribute("fill", "none");
            }
            return circleElement;
        }

        private static XmlElement CreateLineElement(XmlDocument doc, Line line)
        {
            XmlElement lineElement = doc.CreateElement("line");
            lineElement.SetAttribute("x1", line.Points[0].X.ToString());
            lineElement.SetAttribute("y1", line.Points[0].Y.ToString());
            lineElement.SetAttribute("x2", line.Points[1].X.ToString());
            lineElement.SetAttribute("y2", line.Points[1].Y.ToString());
            lineElement.SetAttribute("stroke", line.StrokeColor.Name.ToString());
            lineElement.SetAttribute("stroke-width", line.StrokeThickness.ToString());
            return lineElement;
        }

        private static XmlElement CreateSquareElement(XmlDocument doc, Square square)
        {
            XmlElement polygonElement = doc.CreateElement("polygon");
            StringBuilder points = new StringBuilder();

            foreach (var point in square.Points)
            {
                points.Append($"{point.X},{point.Y} ");
            }

            polygonElement.SetAttribute("points", points.ToString().Trim());
            polygonElement.SetAttribute("stroke", square.StrokeColor.Name.ToString());
            polygonElement.SetAttribute("stroke-width", square.StrokeThickness.ToString());
            if (square.FillColor != null)
            {
                polygonElement.SetAttribute("fill", square.FillColor.Value.Name.ToString());
            }
            else
            {
                polygonElement.SetAttribute("fill", "none");
            }
            return polygonElement;
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
            myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ImageQuality);
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
