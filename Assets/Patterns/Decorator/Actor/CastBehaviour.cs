using System.Collections;
using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Functions as a helper class for an <see cref="ActorBehaviour"/> to cast spells.
    /// </summary>
    public class CastBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The actor to cast spells for.
        /// </summary>
        private ActorBehaviour _actor;

        /// <summary>
        /// Initializes the behavior with the actor it helps.
        /// </summary>
        private void Awake() => _actor = GetComponent<ActorBehaviour>();

        /// <summary>
        /// Casts a spell towards a target actor.
        /// </summary>
        /// <param name="spell">The spell to cast.</param>
        /// <param name="target">The target actor.</param>
        public void Cast(Spell spell, ActorBehaviour target)
        {
            if (spell.castTime != 0)
                StartCoroutine(CastWithCastTime(spell, target));
            else
                spell.Cast(_actor, target);
        }

        /// <summary>
        /// Casts a spell after the spell its cast time has expired.
        /// </summary>
        /// <param name="spell">The spell to cast.</param>
        /// <param name="target">The target actor.</param>
        private IEnumerator CastWithCastTime(Spell spell, ActorBehaviour target)
        {
            yield return new WaitForSeconds(spell.castTime);

            spell.Cast(_actor, target);
        }
    }
}
