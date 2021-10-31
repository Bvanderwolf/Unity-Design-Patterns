using BWolf.Patterns.Decorator.EmbeddedPaterns.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Pooling
{
    /// <summary>
    /// Provides a pooling functions for spells and their upgrades.
    /// </summary>
    public static class SpellPool
    {
        /// <summary>
        /// The bags of spells.
        /// </summary>
        private static readonly Dictionary<SpellType, ConcurrentBag<Spell>> _spellPool
            = new Dictionary<SpellType, ConcurrentBag<Spell>>();

        /// <summary>
        /// The bags of spell upgrades.
        /// </summary>
        private static readonly Dictionary<SpellUpgradeType, ConcurrentBag<SpellUpgrade>> _upgradePool
            = new Dictionary<SpellUpgradeType, ConcurrentBag<SpellUpgrade>>();

        /// <summary>
        /// Retrieves a spell from the pool.
        /// </summary>
        /// <param name="spellType">The spell type.</param>
        /// <returns>The pooled spell.</returns>
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

        /// <summary>
        /// Retrieves a spell upgrade from the pool.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        /// <param name="upgradeType">The upgrade type.</param>
        /// <returns>The spell upgrade instance.</returns>
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

        /// <summary>
        /// Returns a spell to the pool.
        /// </summary>
        /// <param name="spell">The spell to return.</param>
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

        /// <summary>
        /// Returns a spell upgrade to the pool.
        /// </summary>
        /// <param name="upgrade">The spell upgrade.</param>
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
