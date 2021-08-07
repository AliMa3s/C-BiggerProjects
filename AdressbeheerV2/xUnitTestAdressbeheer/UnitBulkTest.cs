using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class UnitBulkTest {
        [Fact]
        public void Test_BulkAdres_valid() {
            DataReader data = new DataReader();
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            Processor p = new Processor(connection);
            p.BulkAdres(new List<Adres>(data.adressen.Values));
        }
        [Fact]
        public void Test_BulkGemeente_valid() {
            DataReader data = new DataReader();
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            Processor p = new Processor(connection);
            p.BulkGemeente(new List<Gemeente>(data.gemeentes.Values));
        }
        [Fact]
        public void Test_BulkStraten_valid() {
            DataReader data = new DataReader();
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            Processor p = new Processor(connection);
            p.BulkStraten(new List<Straat>(data.straten.Values));
        }
        [Fact]
        public void Test_Adreslocatie_valid() {
            DataReader data = new DataReader();
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            Processor p = new Processor(connection);
            p.BulkAdresLocatie(new List<AdresLocatie>(data.adreslocatie.Values));
        }
    }
}
