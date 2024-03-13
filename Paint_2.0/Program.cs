using Paint_2._0.Entities;

namespace Paint_2._0
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Пример считывания из SVG и сохранения в SVG
            string filePath = "input.svg";
            FigureContainer fc = IO.IO.SVGToCanvas(filePath);
            IO.IO.CanvasToSVG(fc, "output.svg");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}