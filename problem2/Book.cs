using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    class Book
    {
        public string Auther;
        public int Pages;
        public List<string> Chapters = new List<string>();
        int BookMark;
        int Price;
        public Book(string Auther,int Pages,int BookMark,int Price)
        {
            this.Auther = Auther;
            this.Pages = Pages;
            this.BookMark = BookMark;
            this.Price = Price;
        }
        public void AddChapters(string chapName)
        {
            Chapters.Add(chapName);
        }
        public string GetChap(int chapNo)
        {if (chapNo < Chapters.Count)
            {
                string chapName = Chapters[chapNo - 1];
                return chapName;
            }
            return null;
        }
        public int GetBookPrice()
        {
            return Price;
        }
        public void SetBookPrice(int newPrice)
        {
            Price = newPrice;
        }
        public void SetBookMark(int newBookMark)
        {
            BookMark = newBookMark;
        }
        public int GetBookMark()
        {
            return BookMark;
        }
    }

}
