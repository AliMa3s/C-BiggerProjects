namespace ClassLibrary1 {
    public class Straatnaam {
        public Straatnaam(int id, string straatnaam, int niscode) {
            this.Id = id;
            this.Naam = straatnaam;
            this.gemeente = gemeente;
            this.NISCODE = niscode;
        }

        

        public override string ToString() {
            return $"naam = {Naam}, ID = {Id}\n" + gemeente;
        }
        public int Id { get;  set; }
        public string Naam { get;  set; }
        public Gemeente gemeente { get; set; }
        public int NISCODE { get; set; }
    }
}