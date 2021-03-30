using UnityEngine;

namespace CarGameScripts.Configs
{
    [CreateAssetMenu(fileName = "Item", menuName = "Car/Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int ID;
        public string Title;
    }
}