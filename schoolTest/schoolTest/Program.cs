using System;
using System.Collections.Generic;


namespace schoolTest {
	public class PhoneDirectory {
		private Dictionary<string, string> nameToTelefoon;
		private Dictionary<string, string> telefoonToName;

		public PhoneDirectory() {
			this.nameToTelefoon = new Dictionary<string, string>();
			this.telefoonToName = new Dictionary<string, string>();

        }
		public void Add(string name, string phoneNum) {
			this.nameToTelefoon[name] = phoneNum;
        }
		public string GetPhoneNumberByName(string name) {
			string result = null;
			if(name != null && this.nameToTelefoon.ContainsKey(name)) {
				result = nameToTelefoon[name];
				telefoonToName[name] = name;

            }
			return result;
        }
		public string GetNameByPhoneNumber(string phoneNum) {
			string result = null;
			foreach(string name in nameToTelefoon.Keys) {
				string number = nameToTelefoon[name];
				if (number == phoneNum) {
					result = name;
					break;
                }
            }
			return null;
        }
	}
    class Program {
        static void Main(string[] args) {
			PhoneDirectory pd = new PhoneDirectory();

			pd.Add("Jan", "1234");
			pd.Add("Piet", "3456");
			pd.Add("Mieke", "5678");

			if (pd.GetPhoneNumberByName("Jan") == "1234" && pd.GetNameByPhoneNumber("1234") == "Jan") {
				Console.WriteLine("Jan is ok");
			} else {
				Console.WriteLine("Jan is niet ok");
			}

			if (pd.GetPhoneNumberByName("Piet") == "3456" && pd.GetNameByPhoneNumber("3456") == "Piet") {
				Console.WriteLine("Piet is ok");
			} else {
				Console.WriteLine("Piet is niet ok");
			}

			if (pd.GetPhoneNumberByName("Mieke") == "5678" && pd.GetNameByPhoneNumber("5678") == "Mieke") {
				Console.WriteLine("Mieke is ok");
			} else {
				Console.WriteLine("Mieke is niet ok");
			}

			if (pd.GetPhoneNumberByName("Corneel") == null) {
				Console.WriteLine("onbekende naam is ok");
			} else {
				Console.WriteLine("onbekende naam is niet ok");
			}

			if (pd.GetNameByPhoneNumber("8888") == null) {
				Console.WriteLine("onbekend nummer is ok");
			} else {
				Console.WriteLine("onbekend nummer is niet ok");
			}

			if (pd.GetPhoneNumberByName(null) == null) {
				Console.WriteLine("'null' als naam is ok");
			} else {
				Console.WriteLine("'null' als naam is niet ok");
			}

			if (pd.GetNameByPhoneNumber(null) == null) {
				Console.WriteLine("'null' als nummer is ok");
			} else {
				Console.WriteLine("'null' als nummer is niet ok");
			}
		} 
    }
}
