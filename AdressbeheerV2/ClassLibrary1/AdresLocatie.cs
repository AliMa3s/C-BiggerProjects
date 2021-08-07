using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class AdresLocatie {
        private static int _id = 1;
        public int Id { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public AdresLocatie(int id, double x, double y) {
            Id = id;
            X = x;
            Y = y;
        }
        public AdresLocatie(double x, double y) {
            X = x;
            Y = y;
        }

        public int CreateID() {
            return _id++;
        }
        public override bool Equals(object obj) {
            return obj is AdresLocatie locatie &&
                   Id == locatie.Id &&
                   X == locatie.X &&
                   Y == locatie.Y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, X, Y);
        }
    }
}
