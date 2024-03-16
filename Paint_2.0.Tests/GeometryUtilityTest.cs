using Paint_2._0.Utilities;

namespace Paint_2._0.Tests
{
    [TestClass]
    public class GeometryUtilityTest
    {
        /// <summary>
        /// ���������� ���� ����� ����� ��������� ab � bc
        /// </summary>
        /// <param name="a">����� ������� ab</param>
        /// <param name="b">����� ����������� �������� ab � bc</param>
        /// <param name="c">����� ������� bc</param>
        /// <returns>���� ����� ���������</returns>
        [TestMethod]
        public void GeometryUtility_GetAngle_90()
        {
            Point2 a = new Point2(2, 2);
            Point2 b = new Point2(2, 1);
            Point2 c = new Point2(1, 1);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = float.Pi/2;

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_AcuteAngle() //������ ����
        {
            Point2 a = new Point2(1, 5);
            Point2 b = new Point2(4, 1);
            Point2 c = new Point2(1, 1);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = (float)Math.Acos(0.6);

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_ObtuseAngle() //����� ����
        {
            Point2 a = new Point2(0, 4);
            Point2 b = new Point2(3, 0);
            Point2 c = new Point2(8, 0);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = (float) Math.Acos(-0.6);

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_180() 
        {
            Point2 a = new Point2(1, 1);
            Point2 b = new Point2(2, 2);
            Point2 c = new Point2(3, 3);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = (float)Math.PI;

            Assert.AreEqual(expected, totalAngle);
        }
        /// <summary>
        /// ���������, ��������� �� ����� ������ �������, ������������ ������� ������.
        /// ��� �������� ������������ ��������� �������: ����� ���� ����� ����� ������ � ����� �������� 
        /// ��������� �������� ����� ����� -2Pi ��� 2Pi, ���� ����� ������ �������� � 
        /// ������ � 0, ���� ����� ����� �� ��������� ��������.
        /// </summary>
        /// <param name="point">�����</param>
        /// <param name="polygon">������� ��������</param>
        /// <returns>true, ���� ����� ������ ��������</returns>
        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_PointInsideSquare()
        {
            Point2 point = new Point2(2, 2);
            List<Point2> polygon = new List<Point2> 
            {
                new Point2(1, 1), new Point2(3, 3)
            };
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.AreEqual(true, tmp); 

        }

        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_PointOnSquare()
        {
            Point2 point = new Point2(3, 2);
            List<Point2> polygon = new List<Point2> 
            {
                new Point2(1, 1), new Point2(3, 3)
            };
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.AreEqual(true, tmp);

        }
        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_Outside()
        {
            Point2 point = new Point2(20, 20);
            List<Point2> polygon = new List<Point2> 
            {
                new Point2(1, 1), new Point2(3, 3)
            };
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.AreEqual(false, tmp);

        }
    }
}