using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuckMan {
    class StepConverter {
        private int[,] Map;

        public StepConverter(int[,] map) {
            this.Map = map;
        }

        public Position DoStep(Position currentPosition, int course) {
            Position nextPosition = new Position() {
                X = currentPosition.X,
                Y = currentPosition.Y
            };
            switch (course) {
                case 0:
                    if (currentPosition.Y >= 35)
                        nextPosition.Y -= 30;
                    break;
                case 1:
                    if (currentPosition.X <= 335)
                        nextPosition.X += 30;
                    break;
                case 2:
                    if (currentPosition.Y <= 335)
                        nextPosition.Y += 30;
                    break;
                case 3:
                    if (currentPosition.X >= 35)
                        nextPosition.X -= 30;
                    break;
            }

            if (this.Map[nextPosition.ColNumber, nextPosition.RowNumber] == 1)
                return currentPosition; 

            return nextPosition;
        }

        public void DoOnePxStep(ref Position currentPosition, Position nextPosition) {
            if (currentPosition.X < nextPosition.X)
                currentPosition.X++;
            if (currentPosition.X > nextPosition.X)
                currentPosition.X--;
            if (currentPosition.Y < nextPosition.Y)
                currentPosition.Y++;
            if (currentPosition.Y > nextPosition.Y)
                currentPosition.Y--;
        }

        public void SetPositions() {
            return;
        }

        public Position SetPacmanPosition() {
            return FindElementPosition(3).FirstOrDefault();
        }

        public List<Position> SetEnemyPosition() {
            List<Position> position = FindElementPosition(4);
            foreach (var currentPosition in position) {
                Map[currentPosition.ColNumber, currentPosition.RowNumber] = 0;
            }
            return position;
        }

        public List<Position> FindElementPosition(int elementValue) {
            var positions = new List<Position>();
            for (int i = 0; i < 13; i++) {
                for (int j = 0; j < 13; j++) {
                    if (Map[i, j] == elementValue) 
                        positions.Add(new Position(){ColNumber = i, RowNumber = j});
                }
            }
            return positions;
        }
    }
}
