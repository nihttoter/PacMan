using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PuckMan {
    class Position {
        //TODO Сделать валидацию
        private int _x;
        public int X {
            get {
                return _x;
            }
            set {
                _x = value;
                _colNumber = value/30;
            }
        }

        private int _y;
        public int Y {
            get {
                return _y;
            }
            set {
                _y = value;
                _rowNumber = value / 30;
            }
        }

        private int _rowNumber;
        public int RowNumber {
            get {
                return _rowNumber;
            }
            set {
                _rowNumber = value;
                _y = value*30 + 5;
            }
        }

        private int _colNumber;
        public int ColNumber {
            get {
                return _colNumber;
            }
            set {
                _colNumber = value;
                _x = value*30 + 5;
            }
        }
    }
}
