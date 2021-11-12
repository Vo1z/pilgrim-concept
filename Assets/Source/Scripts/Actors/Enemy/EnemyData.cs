using NaughtyAttributes;
using UnityEngine;
namespace Ingame.Enemy
{
    [CreateAssetMenu(menuName ="Data/EnemyData", fileName ="newEnemyData")]
    public class EnemyData : ScriptableObject
    {
        [Foldout("Movement")] [SerializeField] [Min(0)] private float movementSpeed=1;
        [Foldout("Movement")] [SerializeField] [Min(0)] private float roatationSpeed=1;
        [Foldout("Movement")] [SerializeField] [Min(0)] private float gravity=1;

        [Foldout("Sustain")] [SerializeField] [Min(0)] private float initalHp=1;

        [Foldout("Damage")] [SerializeField] [Min(0)] private float damageDeal=1;

        public float MovementSpeed => movementSpeed;
        public float RoatationSpeed => roatationSpeed;
        public float Gravity => gravity;

        public float InitalHp => initalHp;

        public float DamageDeal => damageDeal;

    }
}
