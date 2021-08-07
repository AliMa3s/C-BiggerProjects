using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class Adreslocatie {
        [Fact]
        public void Test_ctr_Adreslocatie_valid() {
            int id = 123;
            double x = 4654.1;
            double y = 54464.2;
            AdresLocatie adr = new AdresLocatie(123, 4654.1, 54464.2);


            Assert.Equal(adr.Id, id);
            Assert.Equal(adr.X, x);
            Assert.Equal(adr.Y, y);
        }
    }
}
