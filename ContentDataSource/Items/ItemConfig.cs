using UnityEngine;

namespace CarGameScripts.ContentDataSource.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Car/Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int ID;
        public string Title;
    }
}