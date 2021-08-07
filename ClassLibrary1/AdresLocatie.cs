namespace ClassLibrary1 {
    public class AdresLocatie {
        private static int counter = 0;
        public int Id { get;  set; }
        public double X { get;  set; }
        public double Y { get;  set; }

        
        public AdresLocatie(int id, double x, double y) {
            
            this.Id = id;
            this.X = x;
            this.Y = y;
            //if(Id == -1) {
            //    counter++;
            //    this.Id = counter;
            //} else {
            //Id = id;
            //this.X = x;
            //this.Y = y;
            //}
            
        }

        
        public AdresLocatie(double x, double y) {
            counter++;
            this.Id = counter;
            this.X= x;
            this.Y = y;
        }
    }
}