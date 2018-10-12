using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Artillery;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class WaveGenerator : MonoBehaviour
    {
        private const float OffsetOffScreen = 0.5f;
        private const float RandomnessOffScreen = 1f;
        private int _amountEnemies;
        private int _amountTimeToInvoke;
        private Vector2 _nbDirectionShooting;
        private readonly List<SpaceShipEnemies> _enemies = new List<SpaceShipEnemies>();
        
        public void StartWave(int level, Action nextLevel)
        {
            _amountEnemies = Mathf.CeilToInt(Mathf.Pow(level, 1.3f));
            _amountTimeToInvoke = 30;
            _nbDirectionShooting = new Vector2(4, 12);
            StartCoroutine(CreateEnemies(level, nextLevel));
        }

        public int AmountEnemiesRemaining =>
            Mathf.Clamp(_amountEnemies - _enemies.Count(e => !e.IsAlive), 0, int.MaxValue);

        private IEnumerator CreateEnemies(int level, Action nextLevel)
        {
            var sleepTime = _amountTimeToInvoke / _amountEnemies;
            var bound = Camera.main.OrthographicBounds();
            
            for (var i = 0; i < _amountEnemies; i++)
            {
                var enemy = Game.EnemiesPool.GetItem().GetComponent<SpaceShipEnemies>();
                var gun = enemy.GetComponent<SphericalGunSystem>();
                gun.AmountDirection = (int) Random.Range(_nbDirectionShooting.x, _nbDirectionShooting.y);

                enemy.Speed = Random.Range(0.8f, 2.3f);
                enemy.Life = Mathf.CeilToInt(Mathf.Pow(level, 1.8f)) + 2;
                enemy.transform.position = new Vector2(
                    bound.center.x + Random.Range(-bound.extents.x + OffsetOffScreen, bound.extents.x - OffsetOffScreen),
                    bound.center.y + bound.extents.y + OffsetOffScreen + Random.Range(0, RandomnessOffScreen)
                );
                
                _enemies.Add(enemy);
               
                if (i + 1 < _amountEnemies)
                    yield return new WaitForSeconds(sleepTime);
            }
            
            while (!_enemies.TrueForAll(e => !e.IsAlive))
                yield return null;

            _enemies.ForEach(e => e.TrowAway());
            _enemies.Clear();
            
            nextLevel();
        }
    }
}