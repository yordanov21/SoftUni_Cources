using System;

namespace _10._Rage_Expenses2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetTrash = lostGame / 2;
            int mouseTrash = lostGame / 3;
            int keyboardtrash = lostGame / 6;
            int displayTrash = lostGame / 12;

            double headsetPriceTrash = headsetTrash * headsetPrice;
            double mousePriceTrash = mouseTrash * mousePrice;
            double keyboardPriceTrash = keyboardtrash * keyboardPrice;
            double displayPriceTrash = displayTrash * displayPrice;
            double allTrashPrice = headsetPriceTrash + mousePriceTrash + keyboardPriceTrash + displayPriceTrash;
            Console.WriteLine($"Rage expenses: {allTrashPrice:f2} lv.");
        }
    }
}
