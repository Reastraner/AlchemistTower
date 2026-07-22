namespace AlchemistTower
{
    internal class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();

        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст");
                return;
            }
            foreach (Item item in items)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
            }
        }
        public bool HasItem(string itemName)
        {
            foreach (Item item in items)
            {
                if (itemName == item.Name) return true;
            }

            return false;
        }
    }
}
