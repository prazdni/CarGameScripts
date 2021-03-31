using System.Collections.Generic;
using CarGameScripts.Configs;
using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.Feature;
using CarGameScripts.Items.Interface;

namespace CarGameScripts.Items
{
    public class ItemsRepository : BaseController, IRepository<int, IItem>
    {
        public IReadOnlyDictionary<int, IItem> Collection => _itemsMapByID;
        private Dictionary<int, IItem> _itemsMapByID = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _itemsMapByID, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            _itemsMapByID.Clear();
            _itemsMapByID = null;
        }

        private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType, List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    continue;
                }
                
                upgradeHandlersMapByType.Add(config.ID, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                ID = config.ID,
                Info = new ItemInfo {Title = config.Title}
            };
        }
    }
}