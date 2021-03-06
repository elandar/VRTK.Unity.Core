﻿namespace VRTK.Core.Rule
{
    using UnityEngine;
    using VRTK.Core.Extension;

    /// <summary>
    /// Negates the acceptance of an object based on the acceptance of another <see cref="IRule"/>.
    /// </summary>
    public class NegationRule : MonoBehaviour, IRule
    {
        /// <summary>
        /// The <see cref="IRule"/> to negate.
        /// </summary>
        [Tooltip("The IRule to negate.")]
        public RuleContainer rule;

        /// <inheritdoc />
        public bool Accepts(object target)
        {
            return !rule.Accepts(target);
        }
    }
}