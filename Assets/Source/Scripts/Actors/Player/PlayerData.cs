using NaughtyAttributes;
using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "newPlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Foldout("Movement")][SerializeField][Min(0)] private float movementSpeed;
        [Foldout("Movement")][SerializeField][Min(0)] private float rotationSpeed;
        
        [Foldout("Lifetime")][SerializeField][Min(0)] private float initialHp;

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;

        public float InitialHp => initialHp;
    }
}