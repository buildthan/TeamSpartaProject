using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items { get; private set; }

    public Inventory()
    {
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Your Inventory:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Name}: {item.Description}");
        }
    }
}