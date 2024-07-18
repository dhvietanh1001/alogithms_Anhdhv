// See https://aka.ms/new-console-template for more information
using alogithms_Anhdhv.Controllers;
using alogithms_Anhdhv.Model;
using alogithms_Anhdhv.Queue_Stack;

public class Program
{
    public static void Main()
    {
        Controller controller = new Controller();

        controller.CreateListProduct();
        controller.CreateListCategory();
        controller.CreateMenu();

        Console.WriteLine("Danh sach san pham:");
        foreach (var product in controller.Products)
        {
            Console.WriteLine($"- {product.Name}, {product.Price}, {product.Quality}, {product.CategoryId}");
        }

        string productName = "CPU";
        Product foundProduct = controller.findProduct(controller.Products, productName);
        if (foundProduct != null)
        {
            Console.WriteLine($"\ntim duoc: '{productName}': {foundProduct.Name}, {foundProduct.Price}");
        }
        else
        {
            Console.WriteLine($"\nkhoong tim thay: '{productName}'");
        }

        List<Product> sortedProductsByName = Controller.sortByName(controller.Products);
        Console.WriteLine("\nsan pham sau khi sap xep theo ten:");
        foreach (var product in sortedProductsByName)
        {
            Console.WriteLine($"- {product.Name}, {product.Price}");
        }

        int categoryId = 2;
        List<Product> productsInCategory = controller.findProductByCategory(controller.Products, categoryId);
        Console.WriteLine($"\nDdanh sach sacn pham co categoryid= {categoryId}:");
        foreach (var product in productsInCategory)
        {
            Console.WriteLine($"- {product.Name}, {product.Price}");
        }


        Console.WriteLine("\nMenu :");
        Controller.PrintMenu(controller.Menus);

        Product minPriceProduct = Controller.findByMinPrice(controller.Products);
        if (minPriceProduct != null)
        {
            Console.WriteLine($"\nsan pham co gia thap nhat: {minPriceProduct.Name}, {minPriceProduct.Price}");
        }
        else
        {
            Console.WriteLine("\nkhong co san pham thap nhat");
        }

        double initialSalary = 1000;
        int months = 5;
        double finalSalary = Controller.calSalary(initialSalary, months);
        Console.WriteLine($"\nluong sau {months} thang: {finalSalary}");

        double money = 1000;
        double rate = 5;
        int savingMonths = Controller.calMonth(money, rate);
        Console.WriteLine($"\nso thang can gui de tien goc + tien lai: {savingMonths} thang");


        int savingMonthsRecursive = Controller.calMonthRecursion(money, rate);
        Console.WriteLine($"\nso thang can gui tiet kiem (de qauy): {savingMonthsRecursive} thang");
        Console.WriteLine("\n");

        alogithms_Anhdhv.Queue_Stack.Queue<int> queue = new alogithms_Anhdhv.Queue_Stack.Queue<int>();
        Console.WriteLine("lan luot push 1, 2 , 3 to Queue:");
        queue.Push(1);
        queue.Push(2);
        queue.Push(3);
       
        Console.WriteLine("Queue:");
        while (!queue.IsEmpty())
        {
            Console.WriteLine(queue.Get());
        }

        Console.WriteLine("lan luot push 1, 2, 3 to stack:");
        alogithms_Anhdhv.Queue_Stack.Stack<int> stack = new alogithms_Anhdhv.Queue_Stack.Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack:");
        while (!stack.IsEmpty())
        {
            Console.WriteLine(stack.Get());
        }
    }

}
