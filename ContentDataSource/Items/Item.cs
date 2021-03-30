using CarGameScripts.Items.Interface;

namespace CarGameScripts.Items
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public ItemInfo Info { get; set; }
    }
}