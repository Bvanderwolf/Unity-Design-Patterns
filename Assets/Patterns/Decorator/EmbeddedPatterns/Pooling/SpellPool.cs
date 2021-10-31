using BWolf.Patterns.Decorator.EmbeddedPaterns.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Pooling
{
    public static class SpellPool
    {
        private static readonly Dictionary<SpellType, ConcurrentBag<Spell>> _spellPool
            = new Dictionary<SpellType, ConcurrentBag<Spell>>();

        private static readonly Dictionary<SpellUpgradeType, ConcurrentBag<SpellUpgrade>> _upgradePool
            = new Dictionary<SpellUpgradeType, ConcurrentBag<SpellUpgrade>>();

        public static Spell Retrieve(SpellType spellType)
        {
            if (!_spellPool.ContainsKey(spellType))
                _spellPool.Add(spellType, new ConcurrentBag<Spell>());

            Spell spell;
            if (_spellPool[spellType].TryTake(out spell))
            {
                spell.SetBaseValues();
            }
            else
            {
                spell = SpellFactory.CreateNew(spellType);
            }

            return spell;
        }

        public static SpellUpgrade Retrieve(Spell spell, SpellUpgradeType upgradeType)
        {
            if (!_upgradePool.ContainsKey(upgradeType))
                _upgradePool.Add(upgradeType, new ConcurrentBag<SpellUpgrade>());

            SpellUpgrade upgrade;
            if (_upgradePool[upgradeType].TryTake(out upgrade))
            {
                upgrade.SetBaseValues();
            }
            else
            {
                upgrade = SpellUpgradeFactory.CreateNew(spell, upgradeType);
            }

            return upgrade;
        }

        public static void Return(this Spell spell)
        {
            SpellType spellType;
            try
            {
                spellType = SpellConfig.typeMap[spell.GetType()];
            }
            catch
            {
                throw new InvalidOperationException("Spell has not yet been added to the configuration its type map.");
            }

            if (!_spellPool.ContainsKey(spellType))
                _spellPool.Add(spellType, new ConcurrentBag<Spell>());

            spell.Reset();

            _spellPool[spellType].Add(spell);
        }

        public static void Return(this SpellUpgrade upgrade)
        {
            SpellUpgradeType upgradeType;
            try
            {
                upgradeType = SpellUpgradeConfig.typeMap[upgrade.GetType()];
            }
            catch
            {
                throw new InvalidOperationException("Spell has not yet been added to the configuration its type map.");
            }

            if (!_upgradePool.ContainsKey(upgradeType))
                _upgradePool.Add(upgradeType, new ConcurrentBag<SpellUpgrade>());

            upgrade.Reset();

            _upgradePool[upgradeType].Add(upgrade);
        }
    }
}
