using BWolf.Patterns.Decorator.EmbeddedPaterns.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents an actor that can cast spells and get damaged and/or healed.
    /// </summary>
    [RequireComponent(typeof(CastBehaviour))]
    public class ActorBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The spells the actor can cast.
        /// </summary>
        private List<SpellType> _learnedSpells = new List<SpellType>
        {
            SpellType.FIRE_BALL,
            SpellType.FIRE_BALL_EXPLOSION,
            SpellType.HEAL,
            SpellType.POISON,
            SpellType.RUPTURE,
        };

        /// <summary>
        /// The upgrades the actor has for its spells.
        /// </summary>
        private Dictionary<SpellType, List<SpellUpgradeType>> _upgrades = new Dictionary<SpellType, List<SpellUpgradeType>>();

        /// <summary>
        /// The cast dispatcher used to outsource spell casts.
        /// </summary>
        private CastBehaviour _castDispatcher;

        /// <summary>
        /// Initializes spells with upgrades and casts heal spell on itself.
        /// </summary>
        private void Awake() => _castDispatcher = GetComponent<CastBehaviour>();

        /// <summary>
        /// Makes the actor cast a spell.
        /// </summary>
        /// <param name="index">The index of the spell in the array of spells the actor has.</param>
        /// <param name="target">The target of the spell.</param>
        public void CastSpell(SpellType spellType, ActorBehaviour target)
        {
            if (!_learnedSpells.Contains(spellType))
                throw new InvalidOperationException("Spell is not learned by the actor yet.");

            Spell spell = SpellFactory.Create(spellType, GetUpgrades(spellType));

            _castDispatcher.Cast(spell, target);
        }

        /// <summary>
        /// Upgrades a spell the actor has.
        /// </summary>
        /// <param name="type">The type of spell to upgrade.</param>
        /// <param name="upgrade">The upgrade for the spell.</param>
        public void UpgradeSpell(SpellType type, SpellUpgradeType upgrade)
        {
            if (!_learnedSpells.Contains(type))
                throw new ArgumentException($"The actor does not have the {type} spell.");

            if (!_upgrades.ContainsKey(type))
                _upgrades.Add(type, new List<SpellUpgradeType>());

            _upgrades[type].Add(upgrade);
        }

        /// <summary>
        /// Damages the actor.
        /// </summary>
        /// <param name="amount">The amount to damage.</param>
        public void Damage(int amount) { }

        /// <summary>
        /// Heals the actor.
        /// </summary>
        /// <param name="amount">The amount to heal.</param>
        public void Heal(int amount) { }

        /// <summary>
        /// Adds a damage status (e.g. poison) to the actor.
        /// </summary>
        /// <param name="duration">The duration of the status.</param>
        /// <param name="frequency">The frequency at which to damage the actor.</param>
        /// <param name="amount">The amount of damage to do on each hit.</param>
        public void AddDamageStatus(float duration, float frequency, float amount) { }

        /// <summary>
        /// Adds a heal status.
        /// </summary>
        /// <param name="duration">The duration of the status.</param>
        /// <param name="frequency">The frequency at which to heal the actor.</param>
        /// <param name="amount">The amount of healing to do on each hit.</param>
        public void AddHealStatus(float duration, float frequency, float amount) { }

        /// <summary>
        /// Returns the upgrades for a spell the actor has.
        /// </summary>
        /// <param name="type">The spell to get the upgrades for.</param>
        /// <returns>The list of upgrades for the spell.</returns>
        private List<SpellUpgradeType> GetUpgrades(SpellType type)
        {
            if (!_learnedSpells.Contains(type))
                throw new ArgumentException($"The actor does not have the {type} spell.");

            if (!_upgrades.ContainsKey(type))
                _upgrades.Add(type, new List<SpellUpgradeType>());

            return _upgrades[type];
        }
    }
}

