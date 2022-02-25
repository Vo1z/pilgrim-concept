using NaughtyAttributes;
using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "newPlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Foldout("Movement")][SerializeField][Min(0)] private float movementSpeed = 10;
        [Foldout("Movement")][SerializeField][Min(0)] private float rotationSpeed = 1;
        [Foldout("Movement")][SerializeField][Min(0)] private float jumpForce = 10;


        [Foldout("Lifetime")][SerializeField][Min(0)] private float initialHp;

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float JumpForce => jumpForce;

        public float InitialHp => initialHp;
    }
}