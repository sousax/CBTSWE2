using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace TP_01.Models
{
    public class Book
    {
        private string name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }
        
        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        //Getters
        public string getName() => this.name;
        public Author[] getAuthors() => this.authors;
        public double getPrice() => this.price;
        public int getQty() => this.qty;

        //Setters
        public void setPrice(double price) => this.price = price;       
        public void setQty(int qty) => this.qty = qty;

        public string getAuthorNames()
        {
            return string.Join(",", this.authors.Select(a => a.name));
        }

        public override string ToString()
        {
            return $"Book[name={this.name}, authors={{ {getAuthorNames()} }}, price={this.price}, qty={this.qty}]";
        }
    }
}
