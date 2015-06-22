using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuckMan {
    class MapDrawer {
        private PaintEventArgs e;
        public int[,] BarriersMap;

        public MapDrawer(PaintEventArgs args, int[,] map) {
            this.e = args;
            BarriersMap = map;
        }

        public void DrawMap() {
            //Рисуем бекграунд
            var backgroundBrush = new SolidBrush(Color.AntiqueWhite);
            var rect = new Rectangle(0, 0, 400, 400);
            e.Graphics.FillRectangle(backgroundBrush, rect);
            //!Рисуем бекграунд

            //Граница поля
            Point[] mainBorderPoints = { new Point(3, 3), new Point(397, 3), new Point(397, 397), new Point(3, 397), new Point(3, 1) };
            var mainBorderPen = new Pen(Color.Black, 5);
            e.Graphics.DrawLines(mainBorderPen, mainBorderPoints);
            //!Граница поля

            //Рисуем границы клеток
            var fildBorderPen = new Pen(Color.Black, 2);
            for (int i = 5; i < 396; i += 30)
                e.Graphics.DrawLine(fildBorderPen, new Point(i, 5), new Point(i, 395));
            for (int j = 5; j < 396; j += 30)
                e.Graphics.DrawLine(fildBorderPen, new Point(5, j), new Point(395, j));
            //!Рисуем границы клеток
        }

        public void DrawBarriers() {
            var barrierBrush = new SolidBrush(Color.Brown);
            for (int rowNumber = 0; rowNumber < 13; rowNumber++) {
                for (int colNumber = 0; colNumber < 13; colNumber++) {
                    if (BarriersMap[colNumber, rowNumber] == 1) {
                        var barrierRectangle = new Rectangle(colNumber * 30 + 6, rowNumber * 30 + 6, 28, 28);
                        e.Graphics.FillRectangle(barrierBrush, barrierRectangle);
                    }
                }
            }
        }

        public void DrawPacman(int x, int y, int course) {
            var pacmanBrush = new SolidBrush(Color.DarkOrange);
            var pacmanRectangle = new Rectangle(x, y, 28, 28);

            var pacmansMouthBrush = new SolidBrush(Color.AntiqueWhite);

            e.Graphics.FillEllipse(pacmanBrush, pacmanRectangle);

            Point point1 = new Point();
            Point point2 = new Point();
            Point point3 = new Point();

            switch (course) {
                case 0:
                    point1 = new Point(x + 7, y);
                    point2 = new Point(x + 14, y + 14);
                    point3 = new Point(x + 21, y);
                    break;
                case 1:
                    point1 = new Point(x + 28, y + 5);
                    point2 = new Point(x + 14, y + 14);
                    point3 = new Point(x + 28, y + 23);
                    break;
                case 2:
                    point1 = new Point(x + 7, y + 28);
                    point2 = new Point(x + 14, y + 14);
                    point3 = new Point(x + 21, y + 28);
                    break;
                case 3:
                    point1 = new Point(x, y + 7);
                    point2 = new Point(x + 14, y + 14);
                    point3 = new Point(x, y + 21);
                    break;
            }

            Point[] curvePoints = { point1, point2, point3 };

            e.Graphics.FillPolygon(pacmansMouthBrush, curvePoints);
        }

        public void DrawFood() {
            var foodBrush = new SolidBrush(Color.Olive);
            for (int rowNumber = 0; rowNumber < 13; rowNumber++) {
                for (int colNumber = 0; colNumber < 13; colNumber++) {
                    if (BarriersMap[colNumber, rowNumber] == 0) {
                        var foodRectangle = new Rectangle(colNumber * 30 + 16, rowNumber * 30 + 16, 8, 8);
                        e.Graphics.FillEllipse(foodBrush, foodRectangle);
                    }
                }
            }
        }

        public void DrawEnemy(int x, int y) {
            var EnemyBrush = new SolidBrush(Color.Red);

            Point point1 = new Point(x + 14, y);
            Point point2 = new Point(x + 28, y + 14);
            Point point3 = new Point(x + 14, y + 28);
            Point point4 = new Point(x, y + 14);

            Point[] EnemyPoints = { point1, point2, point3, point4 };

            e.Graphics.FillPolygon(EnemyBrush, EnemyPoints);
        }
    }
}
