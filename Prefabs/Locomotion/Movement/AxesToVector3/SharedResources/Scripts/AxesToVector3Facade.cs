﻿namespace VRTK.Core.Prefabs.Locomotion.Movement.AxesToVector3
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using VRTK.Core.Action;
    using VRTK.Core.Data.Attribute;

    /// <summary>
    /// The public interface for the AxisSlide prefab.
    /// </summary>
    public class AxesToVector3Facade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the multiplied <see cref="Vector3"/> value.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<Vector3>
        {
        }

        #region Axis Settings
        /// <summary>
        /// The <see cref="FloatAction"/> to get the lateral (left/right direction) data from.
        /// </summary>
        [Header("Axis Settings"), Tooltip("The FloatAction to get the lateral (left/right direction) data from."), SerializeField]
        protected FloatAction lateralAxis;
        /// <summary>
        /// The <see cref="FloatAction"/> to get the longitudinal (forward/backward direction) data from.
        /// </summary>
        [Tooltip("The FloatAction to get the longitudinal (forward/backward direction) data from."), SerializeField]
        protected FloatAction longitudinalAxis;
        /// <summary>
        /// The multiplier to apply to the lateral axis.
        /// </summary>
        [Tooltip("The multiplier to apply to the lateral axis."), SerializeField]
        protected float lateralSpeedMultiplier = 1f;
        /// <summary>
        /// The multiplier to apply to the longitudinal axis.
        /// </summary>
        [Tooltip("The multiplier to apply to the longitudinal axis."), SerializeField]
        protected float longitudinalSpeedMultiplier = 1f;
        #endregion

        #region Reference Settings
        /// <summary>
        /// The source of the forward direction to move towards.
        /// </summary>
        [Header("Reference Settings"), Tooltip("The source of the forward direction to move towards.")]
        public GameObject sourceOfForwardDirection;
        #endregion

        #region Events
        /// <summary>
        /// Emitted when the axes are converted into a <see cref="Vector3"/>.
        /// </summary>
        [Header("Events"), Tooltip("Emitted when the axes are converted into a Vector3.")]
        public UnityEvent Processed = new UnityEvent();
        #endregion

        #region Internal Settings
        /// <summary>
        /// The linked Internal Setup.
        /// </summary>
        [Header("Internal Settings"), Tooltip("The linked Internal Setup."), InternalSetting]
        public AxesToVector3InternalSetup internalSetup;
        #endregion

        /// <summary>
        /// The <see cref="FloatAction"/> to get the lateral (left/right direction) data from.
        /// </summary>
        public FloatAction LateralAxis
        {
            get
            {
                return lateralAxis;
            }
            set
            {
                lateralAxis = value;
                internalSetup.SetAxisSources();
            }
        }

        /// <summary>
        /// The <see cref="FloatAction"/> to get the longitudinal (forward/backward direction) data from.
        /// </summary>
        public FloatAction LongitudinalAxis
        {
            get
            {
                return longitudinalAxis;
            }
            set
            {
                longitudinalAxis = value;
                internalSetup.SetAxisSources();
            }
        }

        /// <summary>
        /// The multiplier to apply to the lateral axis.
        /// </summary>
        public float LateralSpeedMultiplier
        {
            get
            {
                return lateralSpeedMultiplier;
            }
            set
            {
                lateralSpeedMultiplier = value;
                internalSetup.SetMultipliers();
            }
        }

        /// <summary>
        /// The multiplier to apply to the longitudinal axis.
        /// </summary>
        public float LongitudinalSpeedMultiplier
        {
            get
            {
                return longitudinalSpeedMultiplier;
            }
            set
            {
                longitudinalSpeedMultiplier = value;
                internalSetup.SetMultipliers();
            }
        }

        protected virtual void OnValidate()
        {
            if (!isActiveAndEnabled || !Application.isPlaying)
            {
                return;
            }

            internalSetup.SetAxisSources();
            internalSetup.SetMultipliers();
        }
    }
}