﻿using alogithms_Anhdhv.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_Anhdhv.Controllers
{
    internal class Controller
    {
        public List<Product> Products = new List<Product>();
        public List<Category> Categories = new List<Category>();
        public List<Menu> Menus = new List<Menu>();

        // create product list
        public void CreateListProduct()
        {
            Products = new List<Product>
        {
            new Product("CPU", 750, 10, 1),
            new Product("RAM", 50, 2, 2),
            new Product("HDD", 70, 1, 2),
            new Product("Main", 400, 3, 1),
            new Product("Keyboard", 30, 8, 4),
            new Product("Mouse", 25, 50, 4),
            new Product("VGA", 60, 35, 3),
            new Product("Monitor", 120, 28, 2),
            new Product("Case", 120, 28, 5)
        };
        }

        //Create category list
        public void CreateListCategory()
        {
            Categories = new List<Category>
        {
            new Category(1, "Computer"),
            new Category(2, "Memory"),
            new Category(3, "Card"),
            new Category(4, "Accessory")
        };
        }
        //Create menu 
        public void CreateMenu()
        {
            Menus = new List<Menu>
        {
            new Menu(1, "Thể thao", 0),
            new Menu(2, "Xã hội", 0),
            new Menu(3, "Thể thao trong nước", 1),
            new Menu(4, "Giao thông", 2),
            new Menu(5, "Môi trường", 2),
            new Menu(6, "Thể thao quốc tế", 1),
            new Menu(7, "Môi trường đô thị", 5),
            new Menu(8, "Giao thông ùn tắc", 4)
        };
        }

        /* Find product by product name
         * @param List<Product> products - lisst product,string nameProduct- name of product
         * return Product - product found */
        public Product findProduct(List<Product> products, string nameProduct)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name == nameProduct)
                    return products[i];
            }
            return null;
        }

        /* Find product by categoryid
         * @param List<Product> products - product list,int categoryId- id of category to find
         * return List<Product> - list product have categoryid to find */
        public List<Product> findProductByCategory(List<Product> products, int categoryId)
        {
            List<Product> productList = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].CategoryId == categoryId)
                {
                    productList.Add(products[i]);
                }
            }
            return productList;
        }

        /* Find product have price <= value
         * @param List<Product> products - list product,int price - price to find 
         * return List<Product> - list of product have price <= price entered */
        public List<Product> findProductByPrice(List<Product> products, int price)
        {
            List<Product> productList = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Price <= price)
                {
                    productList.Add(products[i]);
                }
            }
            return productList;
        }

        /* sort product by price with bubble sort
         * @param List<Product> products - list product want to sort
         * return List<Product> -list product after sort */
        public static List<Product> sortByPrice(List<Product> products)
        {
            int count = products.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (products[j].Price > products[j + 1].Price)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
            return products;
        }

        /* sort product by name with insertion sort
         * @param List<Product> products - list of product want to sort
         * return List<Product> - list of product after sort*/
        public static List<Product> sortByName(List<Product> products)
        {

            int count = products.Count;
            for (int i = 1; i < products.Count; i++)
            {
                Product key = products[i];
                int j = i - 1;
                while (j >= 0 && products[j].Name.Length < key.Name.Length)
                {
                    products[j + 1] = products[j];
                    j = j - 1;
                }
                products[j + 1] = key;
            }
            return products;
        }

        /* sort product by category name 
         * @param List<Product> products - list product want to find
         * return List<Product> - list product get all condition */

        public static List<Product> sortByCategoryName(List<Product> products, List<Category> categories)
        {
            Dictionary<int, string> categoryMap = new Dictionary<int, string>();
            foreach (var category in categories)
            {
                categoryMap[category.Id] = category.Name;
            }
            for (int i = 1; i < products.Count; i++)
            {
                Product key = products[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(categoryMap[products[j].CategoryId], categoryMap[key.CategoryId]) > 0)
                {
                    products[j + 1] = products[j];
                    j = j - 1;
                }
                products[j + 1] = key;
            }

            return products;
        }

        /* map product to category name by categoryID
         * @param List<Product> productsList<Product> products - list product, List<Category> categories -list category
         * return Dictionary<Product,string> - return list product have category name */
        public static Dictionary<Product, string> mapProductByCategory(List<Product> products, List<Category> categories)
        {
            Dictionary<Product, string> map = new Dictionary<Product, string>();
            foreach (Product product in products)
            {
                Category category = categories.SingleOrDefault(c => c.Id == product.CategoryId);
                map[product] = category.Name;
            }
            return map;
        }

        /* Find product have min price
         * @param List<Product> products - list product want to find
         * return Product - product have min price */
        public static Product findByMinPrice(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return null;
            }

            Product minPriceProduct = products[0];
            for (int i = 1; i < products.Count; i++)
            {
                if (products[i].Price < minPriceProduct.Price)
                {
                    minPriceProduct = products[i];
                }
            }
            return minPriceProduct;
        }

        /* Calculate the salary after n periods 
         * @param double salary - initial salary, int n - number of periods
         * return double - salary after n periods */
        const double interestRate = 0.1d;
        public static double calSalary(double salary, int n)
        {
            for (int i = 0; i < n; i++)
            {
                salary += salary * interestRate;
            }
            return salary;
        }

        /* Calculate the salary after n periods using recursion 
         * @param double salary - initial salary, int n - number of periods
         * return double - salary after n periods */
        public static double calSalaryRecursion(double salary, int n)
        {
            if (n == 1)
            {
                return salary + salary * interestRate;
            }
            else
            {
                return calSalaryRecursion(salary + salary * interestRate, n - 1);
            }
        }

        /* Calculate the number of months required to double the money  interest rate
         * @param double money - initial amount of money, double rate - monthly interest rate in percentage
         * return int - number of months required to double the money */
        public static int calMonth(double money, double rate)
        {
            double target = money * 2;
            double currentAmount = money;
            int months = 0;

            while (currentAmount < target)
            {
                currentAmount += currentAmount * (rate / 100);
                months++;
            }
            return months;
        }

        /* Calculate the number of months required to double the money using recursion
         * @param double money - initial amount of money
         * @param double rate - monthly interest rate in percentage
         * @param double currentAmount - current amount of money
         * @param int months - current number of months
         * return int - number of months required to double the money */
        public static int calMonthRecursion(double money, double rate, double currentAmount, int months)
        {
            if (currentAmount >= money * 2)
            {
                return months;
            }
            else
            {
                return calMonthRecursion(money, rate, currentAmount + currentAmount * (rate / 100), months + 1);
            }
        }

        /* Calculate the number of months required to double the money using recursion 
         * @param double money - initial amount of money, double rate - monthly interest rate in percentage
         * return int - number of months required to double the money */
        public static int calMonthRecursion(double money, double rate)
        {
            return calMonthRecursion(money, rate, money, 0);
        }
        /* Print the hierarchical menu structure
         * @param List<Menu> menus - list of all menus 
         * Return null*/
        public static void PrintMenu(List<Menu> menus)
        {
            var menuDict = new Dictionary<int, List<Menu>>();
            foreach (var menu in menus)
            {
                if (!menuDict.ContainsKey(menu.ParentId))
                {
                    menuDict[menu.ParentId] = new List<Menu>();
                }
                menuDict[menu.ParentId].Add(menu);
            }
            PrintMenuDFS(menuDict, 0, 0);
        }

        /* Print the hierarchical menu structure using depth-first search (DFS)
         * @param Dictionary<int, List<Menu>> menuDict - dictionary mapping parent ID to list of menus, int parentId - ID of the parent menu
         * @param int level - current level of depth 
         * Return null*/
        private static void PrintMenuDFS(Dictionary<int, List<Menu>> menuDict, int parentId, int level)
        {
            if (menuDict.ContainsKey(parentId))
            {
                foreach (var menu in menuDict[parentId])
                {
                    Console.WriteLine(new string('-', level * 2) + menu.Title);
                    PrintMenuDFS(menuDict, menu.Id, level + 1);
                }
            }
        }
    }
}
