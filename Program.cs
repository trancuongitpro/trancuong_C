using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

//https://dantri.com.vn
//https://vnexpress.net
namespace VuTruLink
{
    internal class Program
    {
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH")]
        public static void Main(string[] args)
        {
            
            while (true)
            {
                ViewArticle view = new ViewArticle();
                Console.WriteLine("--------News-------");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. VnExpress.");
                Console.WriteLine("2. DanTri.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("-------------------");
                Console.WriteLine("Enter your choice (1-3): ");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        view.VnExpressView();
                        break;
                    case 2:
                        view.DanTriView();
                        break;
                    case 3:
                        Console.WriteLine("Bye bye.");
                        break;
                }
                if (choice == 3)
                {
                    break;
                }
                Console.ReadLine();
            }
        }
    }
}