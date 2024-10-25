﻿using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform EnchantLayout;
        private IEnchantUIFactory _factory;
        
        private readonly List<Enchant> _enchants = new();

        [Inject]
        public void Construct(IEnchantUIFactory factory) => 
            _factory = factory;

        public void AddEnchant(EnchantTypeId typeId)
        {
            if(EnchantAlreadyHeld(typeId))
                return;
            
            var enchant = _factory.CreateEnchant(EnchantLayout, typeId);
            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId typeId)
        {
            var enchant = _enchants.Find(x => x.Id == typeId);

            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool EnchantAlreadyHeld(EnchantTypeId typeId) => 
            _enchants.Find(x => x.Id == typeId) != null;
    }
}
