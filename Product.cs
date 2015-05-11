using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    class Product
    {
        static int ID = 0;

        public int ProductID;
        public string Name;
        public float Price;
        public bool Active;
        public bool CanBeBoughtOnCredit;

        public Product(string name, float price, bool active = true, bool canBeBoughtOnCredit = false)
        {
            this.ProductID = ++ID;
            this.Name = Validation.Required(name);
            this.Price = price;
            this.Active = active;
            this.CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public Product(string input, char delimeter)
        {
            var data = input.Split(delimeter);

            ID = Convert.ToInt32(data[0]);

            this.ProductID = Convert.ToInt32(data[0]);
            this.Name = Validation.Required(CleanName(data[1]));
            this.Price = (Convert.ToSingle(data[2]) / 100);
            this.Active = Convert.ToBoolean(Convert.ToInt32(data[3]));
            this.CanBeBoughtOnCredit = false;
        }

        private string CleanName(string name)
        {
            name = name.Trim('"');
            name = Regex.Replace(name, "<.*?>", "");
            name = name.Trim();

            return name;
        }

        public override string ToString()
        {
            return String.Format("{0}\tkr. {1,5:f2}\t{2}", this.ProductID, this.Price, this.Name);
        }

        public static string ToHeader()
        {
            return "ID\tPrice\t\tName";
        }

        public static List<Product> ReadFile()
        {
            List<Product> list = new List<Product>();

            StreamReader stream = new StreamReader(File.OpenRead("../../products.csv"), Encoding.Default);

            stream.ReadLine();

            while(!stream.EndOfStream) {
                list.Add(new Product(stream.ReadLine(), ';'));
            }

            return list;
        }
    }
}
