using System.Drawing.Imaging;
using Paint_2._0.Entities;
using Paint_2._0.Utilities;
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
        private static string ColorToRGBA(System.Drawing.Color color)
        {
            return string.Format($"rgba({color.R.ToString()},{color.G.ToString()},{color.B.ToString()},{color.A.ToString()}");
        }
        private static XmlElement CreateCircleElement(XmlDocument doc, Circle circle)
        {
            XmlElement circleElement = doc.CreateElement("circle");
            circleElement.SetAttribute("cx", circle.Center.X.ToString());
            circleElement.SetAttribute("cy", circle.Center.Y.ToString());
            circleElement.SetAttribute("r", circle.Radius.ToString("0.0", CultureInfo.InvariantCulture));
            circleElement.SetAttribute("stroke", ColorToRGBA(circle.StrokeColor));
            circleElement.SetAttribute("stroke-width", circle.StrokeThickness.ToString());
            if (circle.FillColor != null)
            {
                circleElement.SetAttribute("fill", ColorToRGBA(circle.FillColor.Value));
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
            lineElement.SetAttribute("stroke", ColorToRGBA(line.StrokeColor));
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
            polygonElement.SetAttribute("stroke", ColorToRGBA(square.StrokeColor));
            polygonElement.SetAttribute("stroke-width", square.StrokeThickness.ToString());
            if (square.FillColor != null)
            {
                polygonElement.SetAttribute("fill", ColorToRGBA(square.FillColor.Value));
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
        #region SVG to FigureContainer
        public static FigureContainer SVGToCanvas(string filePath)
        {
            FigureContainer container = new FigureContainer();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList figureNodes = doc.SelectNodes("//*[local-name()='svg']/*");

            foreach (XmlNode figureNode in figureNodes)
            {
                IFigure? figure = null;

                switch (figureNode.Name)
                {
                    case "circle":
                        figure = CreateCircleFromXmlNode(figureNode);
                        break;
                    case "line":
                        figure = CreateLineFromXmlNode(figureNode);
                        break;
                    case "polygon":
                        figure = CreateSquareFromXmlNode(figureNode);
                        break;
                }
                if (figure != null)
                {
                    container.Add(figure);
                }
            }

            return container;
        }
        private static Circle CreateCircleFromXmlNode(XmlNode node)
        {
            float cx = float.Parse(node.Attributes["cx"].Value);
            float cy = float.Parse(node.Attributes["cy"].Value);
            float r = float.Parse(node.Attributes["r"].Value, CultureInfo.InvariantCulture);

            Color strokeColor = Color.Black; // Цвет обводки по умолчанию
            if (node.Attributes["stroke"] != null)
            {
                strokeColor = ParseColor(node.Attributes["stroke"].Value);
            }

            int strokeThickness = 1; // Толщина обводки по умолчанию
            if (node.Attributes["stroke-width"] != null)
            {
                strokeThickness = int.Parse(node.Attributes["stroke-width"].Value);
            }

            Color? fillColor = null;
            if (node.Attributes["fill"] != null & node.Attributes["fill"].Value != "none")
            {
                fillColor = ParseColor(node.Attributes["fill"].Value);
            }


            Circle circle = new Circle();
            circle.Create(new Point2(cx, cy), new Point2(cx + r, cy), strokeColor);
            circle.StrokeThicknessChange(strokeThickness);
            if (fillColor != null)
            {
                circle.Fill(fillColor.Value);
            }
            return circle;
        }
        private static Color ParseColor(string colorString)
        {
            try
            {
                return ColorTranslator.FromHtml(colorString);
            }
            catch (Exception)
            {
                return Color.Black;
            }
        }
        private static Line CreateLineFromXmlNode(XmlNode node)
        {
            float x1 = float.Parse(node.Attributes["x1"].Value);
            float y1 = float.Parse(node.Attributes["y1"].Value);
            float x2 = float.Parse(node.Attributes["x2"].Value);
            float y2 = float.Parse(node.Attributes["y2"].Value);

            Color strokeColor = Color.Black; // Цвет обводки по умолчанию
            if (node.Attributes["stroke"] != null)
            {
                strokeColor = ParseColor(node.Attributes["stroke"].Value);
            }

            int strokeThickness = 1; // Толщина обводки по умолчанию
            if (node.Attributes["stroke-width"] != null)
            {
                strokeThickness = int.Parse(node.Attributes["stroke-width"].Value);
            }


            Line line = new Line();
            line.Create(new Point2(x1, y1), new Point2(x2, y2), strokeColor);
            line.StrokeThicknessChange(strokeThickness);
            return line;
        }
        private static Square? CreateSquareFromXmlNode(XmlNode node)
        {
            string pointsStr = node.Attributes["points"].Value;
            string[] pointCoords = pointsStr.Split(' ');
            // Обрабатываем только четырёхугольники
            if (pointCoords.Length != 4)
            {
                return null;
            }

            List<Point2> points = new List<Point2>();
            foreach (string pointCoord in pointCoords)
            {
                string[] xy = pointCoord.Split(',');
                float x = float.Parse(xy[0]);
                float y = float.Parse(xy[1]);
                points.Add(new Point2(x, y));
            }

            // Проверка на квадрат
            if (!IsSquare(points))
            {
                return null;
            }

            Color strokeColor = Color.Black; // Цвет обводки по умолчанию
            if (node.Attributes["stroke"] != null)
            {
                strokeColor = ParseColor(node.Attributes["stroke"].Value);
            }

            int strokeThickness = 1; // Толщина обводки по умолчанию
            if (node.Attributes["stroke-width"] != null)
            {
                strokeThickness = int.Parse(node.Attributes["stroke-width"].Value);
            }

            Color? fillColor = null;
            if (node.Attributes["fill"] != null & node.Attributes["fill"].Value != "none")
            {
                fillColor = ParseColor(node.Attributes["fill"].Value);
            }

            Square square = new Square();
            // Чтобы не лежали на одной прямой
            if (points[0].X != points[1].X & points[0].Y != points[1].Y)
            {
                square.Create(points[0], points[1], strokeColor);
            }
            else if (points[0].X != points[2].X & points[0].Y != points[2].Y)
            {
                square.Create(points[0], points[2], strokeColor);
            }
            else
            {
                square.Create(points[0], points[3], strokeColor);
            }
            square.StrokeThicknessChange(strokeThickness);
            if (fillColor != null)
            {
                square.Fill(fillColor.Value);
            }
            return square;
        }
        // Определить образуют ли точки квадрат
        private static bool IsSquare(List<Point2> points)
        {
            // попарные квадраты расстояния между точек
            List<float> s = new List<float>() { 0, 0, 0, 0, 0, 0 };

            // Находим расстояния между точек попарно
            s[0] = Convert.ToSingle(Math.Pow(points[0].X - points[1].X, 2) +
                                    Math.Pow(points[0].Y - points[1].Y, 2));
            s[1] = Convert.ToSingle(Math.Pow(points[0].X - points[2].X, 2) +
                                    Math.Pow(points[0].Y - points[2].Y, 2));
            s[2] = Convert.ToSingle(Math.Pow(points[0].X - points[3].X, 2) +
                                    Math.Pow(points[0].Y - points[3].Y, 2));
            s[3] = Convert.ToSingle(Math.Pow(points[1].X - points[2].X, 2) +
                                    Math.Pow(points[1].Y - points[2].Y, 2));
            s[4] = Convert.ToSingle(Math.Pow(points[1].X - points[3].X, 2) +
                                    Math.Pow(points[1].Y - points[3].Y, 2));
            s[5] = Convert.ToSingle(Math.Pow(points[2].X - points[3].X, 2) +
                                    Math.Pow(points[2].Y - points[3].Y, 2));

            float max = 0;
            int diag1 = 0;  // индекс первой диагонали
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(s[i]);
                if (s[i] > max)
                {
                    max = s[i];
                    diag1 = i;
                }
            }

            int diag2 = -1;
            for (int i = 0; i < 6; i++)
                if (i != diag1 && s[diag1] == s[i])
                    diag2 = i;

            if (diag2 < 0)
                return false;

            bool eq_flag = true;
            float side = 0;
            for (int i = 0; i < 6; i++)
                if (i != diag1 && i == diag2)
                {
                    if (side == 0)
                    {
                        side = s[i];
                        continue;
                    }
                    if (s[i] != side)
                        eq_flag = false;
                }

            if (!eq_flag)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
