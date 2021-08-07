using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class UnitGemeenteTest {
        [Fact]
        public void Test_ctr_Gemeente_valid() {
            int niscode = 123;
            string gemeente = "Gent";

            Gemeente adr = new Gemeente("Gent", 123);


            Assert.Equal(adr.Naam, gemeente);
            Assert.Equal(adr.NIScode, niscode);

        }
    }
}
