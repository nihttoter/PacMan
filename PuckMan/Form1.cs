using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace PuckMan {
    public partial class Form1 : Form {

        private int[,] Map;
        private StepConverter stepConverter;
        private Position pacmanPosition = new Position();
        private int pacmanHeading = 3;
        private Position enemyPosition = new Position();
        public bool Reinit;

        public Form1() {
            InitializeComponent();

            ReinitForm();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {

            var mapDrawer = new MapDrawer(e, Map);

            mapDrawer.DrawMap();
            mapDrawer.DrawBarriers();
            mapDrawer.DrawFood();
            mapDrawer.DrawPacman(pacmanPosition.X, pacmanPosition.Y, pacmanHeading);
            mapDrawer.DrawEnemy(enemyPosition.X, enemyPosition.Y);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            int enemyCourse = (new Random()).Next(0, 4);


            var nextPacmanPosition = stepConverter.DoStep(pacmanPosition, pacmanHeading);
            var nextEnemyPosition = stepConverter.DoStep(enemyPosition, enemyCourse);

            //Плавно передвигает элементы на позиции
            while (pacmanPosition.X != nextPacmanPosition.X 
                || pacmanPosition.Y != nextPacmanPosition.Y
                || enemyPosition.X != nextEnemyPosition.X
                || enemyPosition.Y != nextEnemyPosition.Y) {
                stepConverter.DoOnePxStep(ref pacmanPosition, nextPacmanPosition);
                stepConverter.DoOnePxStep(ref enemyPosition, nextEnemyPosition);

                pictureBox1.Refresh();
                Thread.Sleep(9);
            }
            //!Плавно передвигает элементы на позиции

            //Пакмен ест
            Map[nextPacmanPosition.ColNumber, nextPacmanPosition.RowNumber] = 2;
            //!Пакмен ест

            //Проверка условий победы и поражения
            if (pacmanPosition.X == enemyPosition.X && pacmanPosition.Y == enemyPosition.Y) {
                timer1.Enabled = false;
                var endGameForm = new EndGameForm(this, false);
                endGameForm.ShowDialog();
            }
            if (stepConverter.FindElementPosition(0).FirstOrDefault() == null) {
                timer1.Enabled = false;
                var endGameForm = new EndGameForm(this, true);
                endGameForm.ShowDialog();
            }
            //!Проверка условий победы и поражения

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left) {
                pacmanHeading = 3;
            }
            if (e.KeyCode == Keys.Right) {
                pacmanHeading = 1;
            }
            if (e.KeyCode == Keys.Up) {
                pacmanHeading = 0;
            }
            if (e.KeyCode == Keys.Down) {
                pacmanHeading = 2;
            }
        }

        public void ReinitForm() {
            var str = AppDomain.CurrentDomain.BaseDirectory;
            var fr = new FileReader(str.Remove(str.Length - 10) + "Map.txt");

            Map = fr.ReadFile();

            stepConverter = new StepConverter(Map);

            pacmanPosition = stepConverter.SetPacmanPosition();
            enemyPosition = stepConverter.SetEnemyPosition().FirstOrDefault();

            pictureBox1.Invalidate();

            timer1.Enabled = true;
            return;
        }
    }
}
