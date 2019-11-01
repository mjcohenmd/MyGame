using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ParticleSystemMultiplier : MonoBehaviour
    {
        // a simple script to scale the size, speed and lifetime of a particle system

        public float multiplier = 1;


        private void Start()
        {
            var systems = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem system in systems)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                system.startSize *= multiplier;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                system.startSpeed *= multiplier;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                system.startLifetime *= Mathf.Lerp(multiplier, 1, 0.5f);
#pragma warning restore CS0618 // Type or member is obsolete
                system.Clear();
                system.Play();
            }
        }
    }
}
