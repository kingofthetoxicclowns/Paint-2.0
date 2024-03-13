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

        /// <summary>
        /// Поддерживаемые форматы изображения.
        /// </summary>
        public static List<string> FileFormats { get; set; } = 
                ["svg", "jpeg", "png"];

        /// <summary>
        /// Создаёт строку фильтра файлов по их расширению для экземпляра класса SaveFileDialog.<br/>
        /// Фильтр включает в себя поддерживаемые форматы изображения.
        /// </summary>
        public static string MakeFileFilter()
        {
            string filterString = "";
            for (int i = 0; i < FileFormats.Count; i++)
                filterString += $"{FileFormats[i]}|*.{FileFormats[i].ToLower()}|";
            
            return filterString[..^1];
        }

        /// <summary>
        /// Получает информацию кодировщика заданного формата изображения.
        /// </summary>
        private static ImageCodecInfo? GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo? encoder = Array.Find(encoders, encoder => encoder.MimeType == mimeType);

            return encoder;
        }

        /// <summary>
        /// Сохраняет изображение в файл по указанному пути.
        /// </summary>
        /// <param name="container">Контейнер фигур изображения.</param>
        /// <param name="filePath">Путь сохранения файла изображения.</param>
        /// <param name="width">Ширина изображения.</param>
        /// <param name="height">Высота изображения.</param>
        public static int Save(FigureContainer container, string filePath, int width, int height)
        {
            string fileFormat = filePath.Split('.')[^1];

            if (fileFormat == "svg")
            {
                CanvasToSVG(container, filePath);
                return 0;
            }

            string svgFilePath = filePath[..^(fileFormat.Length)];
            svgFilePath = string.Concat([svgFilePath, "svg"]);

            CanvasToSVG(container, svgFilePath);
            SVGToBitmapFormat(svgFilePath, filePath, width, height);

            return 0;
        }

        /// <summary>
        /// Из контейнера фигур формирует SVG-файл.
        /// </summary>
        /// <param name="container">Контейнер фигур.</param>
        /// <param name="filePath">Путь сохранения SVG-файла.</param>
        public static int CanvasToSVG(FigureContainer container, string filePath)
        {
            XmlDocument doc = new();
            XmlElement svgElement = doc.CreateElement("svg");
            svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("version", "1.1");
            doc.AppendChild(svgElement);

            foreach (var figure in container.Figures)
            {
                XmlElement? figureElement = null;

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
            StringBuilder points = new();

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

        /// <summary>
        /// Перевод SVG-файла в указанный растровый формат.
        /// </summary>
        public static void SVGToBitmapFormat(string svgPath, string outputPath, int width, int height)
        {
            Bitmap bitmap;
            SvgDocument svgDoc;
            ImageCodecInfo? myImageCodecInfo;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            long ImageQuality;

            svgDoc = SvgDocument.Open(svgPath);

            bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                svgDoc.Draw(graphics);
            }

            string bitmapFormat = outputPath.Split('.')[^1];

            myImageCodecInfo = GetEncoderInfo(mimeType: $"image/{bitmapFormat}");
            if (myImageCodecInfo is null || !FileFormats.Contains(bitmapFormat))
                throw new Exception("Указанный формат изображения не поддерживается.");

            ImageQuality = 100L;

            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ImageQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            bitmap.Save(outputPath, myImageCodecInfo, myEncoderParameters);
        }

        /// <summary>
        /// Перевод SVG-файла в контейнер фигур.
        /// </summary>
        public static int SVGToCanvas()
        {
            return 0;
        }
    }
}
