using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class CurrencySingletonView : SingletonView<CurrencySingletonView>
    {
        private const string WoodKey = nameof(WoodKey);
        private const string DiamondKey = nameof(DiamondKey);

        private readonly Dictionary<string, int> _currencyDictionary = new Dictionary<string, int>();
        
        [SerializeField] private TMP_Text _currentCountWood;
        [SerializeField] private TMP_Text _currentCountDiamond;
        
        private int Wood
        {
            get => _currencyDictionary[WoodKey];
            set => _currencyDictionary[WoodKey] =  value;
        }
        
        private int Diamonds
        {
            get => _currencyDictionary[DiamondKey];
            set => _currencyDictionary[DiamondKey] = value;
        }

        private void Start()
        {
            _currencyDictionary.Add(WoodKey, DataStorage.Wood.Read());
            _currencyDictionary.Add(DiamondKey, DataStorage.Diamonds.Read());
            
            RefreshText();
        }

        protected override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
            
            DataStorage.Wood.Write(Wood);
            DataStorage.Diamonds.Write(Diamonds);
        }
        
        public void AddWood(int value)
        {
            Wood += value;
            
            RefreshText();
        }

        public void AddDiamonds(int value)
        {
            Diamonds += value;
            
            RefreshText();
        }

        public void Reset()
        {
            Wood = 0;
            Diamonds = 0;
            
            RefreshText();
        }

        private void RefreshText()
        {
            _currentCountWood.text = Wood.ToString();
            _currentCountDiamond.text = Diamonds.ToString();
        }
    }
}