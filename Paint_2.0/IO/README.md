# IO.cs
## Отвечает за сохранение/загрузку результатов работы программы в файлы графического формата.

Поддерживаемые форматы изображений:<br />
Загрузка: .svg<br />
Сохранение: .svg, .jpeg, .png

## Описание открытых методов
### Все методы находятся в public static class IO
### Описание открытых методов
#### 1. public static string MakeFileFilter()

Возвращает строку фильтра файлов по их расширению для экземпляра класса SaveFileDialog.<br />
Фильтр включает в себя поддерживаемые форматы изображения.

#### 2. public static int Save(FigureContainer container, string filePath, int width, int height)

Сохраняет изображение в файл по указанному пути.

Параметры:<br />
1) FigureContainer container - Контейнер фигур изображения;<br />
2) string filePath - Путь сохранения файла изображения;<br />
3) int width - Ширина изображения;<br />
4) int height - Высота изображения.

Код возврата:<br />
0 - Успешное выполнение функции

#### 3. public static FigureContainer SVGToCanvas(string filePath)

Перевод .svg-файла в контейнер фигур (чтение из .svg)<br />
Возвращает экземпляр класса FigureContainer.<br />
Работает с ограниченным набором тегов формата svg.

Возвращает сформированный контейнер

### Описание закрытых методов
#### 1. private static ImageCodecInfo? GetEncoderInfo(string mimeType)
Получает информацию кодировщика заданного формата изображения.

#### 2. private static int CanvasToSVG(FigureContainer container, string filePath)
Формирование .svg-файла Из контейнера фигур

Параметры:<br />
1) FigureContainer container - Контейнер фигур изображения;<br />
2) string filePath - Путь сохранения файла изображения.

Код возврата:<br />
0 - Успешное выполнение;<br />
1 - Ошибка

#### 3. private static string ColorToRGBA(Color color)
Преобразование объекта класса Color в строку для формирования разметки фигуры

#### 4. private static XmlElement CreateCircleElement(XmlDocument doc, Circle circle)
Формирование xml-разметки фигуры "Circle".

#### 5. private static XmlElement CreateLineElement(XmlDocument doc, Line line)
Формирование xml-разметки фигуры "Line".

#### 6. private static XmlElement CreateSquareElement(XmlDocument doc, Square square)
Формирование xml-разметки фигуры "polygon".

#### 7. private static void SVGToBitmapFormat(string svgPath, string outputPath, int width, int height)
Конвертация .svg-файла в указанный растровый формат изображения

Параметры:<br />
1) string svgPath - Путь к .svg-файлу;<br />
2) string outputPath - Путь для сохранения изображения в растровом формате;<br />
3) int width - Ширина изображения;<br />
4) int height - Высота изображения.

#### 8. private static Circle CreateCircleFromXmlNode(XmlNode node)
Формирование объекта класса Circle из xml-разметки

#### 9. private static Color ParseColor(string colorString)
Формирование объекта класса Color из строки формата "rgba(...)".<br />
В случае исключения возвращает Color.Black

#### 10. private static Line CreateLineFromXmlNode(XmlNode node)
Формирование объекта класса Line из xml-разметки

#### 11. private static Square? CreateSquareFromXmlNode(XmlNode node)
Формирование объекта класса Square из xml-разметки
