using System.Collections;
using Game.Artillery;
using UnityEngine;

namespace Game
{
    public class WaveGenerator : MonoBehaviour
    {
        private const float OffsetOffScreen = 2f;
        private const float RandomnessOffScreen = 5f;
        private int _amountEnemies;
        private int _amountTimeToInvoke;
        private Vector2 _nbDirectionShooting;
        
        public void StartWave(int level)
        {
            _amountEnemies = 200;
            _amountTimeToInvoke = 200;
            _nbDirectionShooting = new Vector2(3, 8);
            StartCoroutine(CreateEnemies());
        }

        private IEnumerator CreateEnemies()
        {
            var sleepTime = _amountTimeToInvoke / _amountEnemies;
            var bound = Camera.main.OrthographicBounds();
            
            for (var i = 0; i < _amountEnemies; i++)
            {
                var enemy = Game.EnemiesPool.GetItem();
                var gun = enemy.GetComponent<SphericalGunSystem>();
                gun.AmountDirection = (int) Random.Range(_nbDirectionShooting.x, _nbDirectionShooting.y);

                enemy.transform.position = new Vector2(
                    bound.center.x + Random.Range(-bound.extents.x + OffsetOffScreen, bound.extents.x - OffsetOffScreen),
                    bound.center.y + bound.extents.y + OffsetOffScreen + Random.Range(0, RandomnessOffScreen)
                );
                
                yield return new WaitForSeconds(sleepTime);
            }
        }
    }
}