using CarGameScripts.Items;
using CarGameScripts.Items.Interface;

namespace CarGameScripts.ContentDataSource.Items
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public ItemInfo Info { get; set; }
    }
}