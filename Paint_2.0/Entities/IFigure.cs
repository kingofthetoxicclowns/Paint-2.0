﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2._0.Entities
{
    public interface IFigure
    {
        public bool IsCircle { get; set; } //проверка на круг: 0 - не круг, 1 - круг
        public List<PointF> Points { get; set; } //точки для построения фигуры

        public Color StrokeColor { get; set; } //цвет обводки

        public int StrokeThickness { get; set; } //толщина обводки

        public Color? FillColor { get; set; } //цвет заливки (может быть null)

        public void Create(PointF startPointF, PointF endPointF, Color color); //создание фигуры, даётся координата начала и координата конца фигуры с помощью типа PointF

        public void Create(PointF startPointF, Vector2 vector, Color color); // создание фигуры, даётся координата начала фигуры и вектор направления

        public void Move(Vector2 vector); // перемещает все точки фигуры на вектор направления

        public void StrokeColorChange(Color color); // установка цвета обводки

        public void Fill(Color color); //установка цвета заливки

        public void StrokeThicknessChange(int thickness); //смена толщины обводки

    }
}