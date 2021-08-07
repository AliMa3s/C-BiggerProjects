using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class UnitStraatTest {
        [Fact]
        public void Test_ctr_Straat_valid() {
            int id = 123;
            string straat = "stellastraat";

            Straat adr = new Straat(123, "stellastraat");


            Assert.Equal(adr.Id, id);
            Assert.Equal(adr.Naam, straat);

        }
    }
}
