using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGame.Controller;
using MyGame.View;

namespace MyGame.Model
{
    public class EnemyAI
    {
        public enum Strategy
        {
            PrepareToAttack,
            Attack,
            Defend,
            Rush,
            WaitOrders
        }

        public GameModel GameModel;
        public ButtonController ButtonController;
        private Timer EnemyOrdersLogicTimer;
        private Timer EnemySuppliesTimer;
        private readonly Random rnd = new Random();
        private readonly int Complexity;
        private int NeededSupplies;
        private int MaxAllyTrench = 86;
        public Strategy CurrentStrategy;

        public EnemyAI(GameModel gameModel,ButtonController buttonController, int complexity)
        {
            Complexity = complexity;
            GameModel = gameModel;
            ButtonController = buttonController;
        }
        public void StartWar()
        {

            EnemySuppliesTimer = new Timer();
            EnemySuppliesTimer.Interval = 15000;
            EnemySuppliesTimer.Tick += EnemySuppliesTimerOnTick;
            EnemySuppliesTimer.Start();
            EnemyOrdersLogicTimer = new Timer();
            EnemyOrdersLogicTimer.Interval = 5000;
            EnemyOrdersLogicTimer.Tick += GetOrders;
            EnemyOrdersLogicTimer.Start();
            CurrentStrategy = Strategy.Rush;
            GameModel.SpawnRiflemans(5,Interface.ButtonsHeight + ViewGraphics.SpriteRectangleSize, Map.MapHeight - ViewGraphics.SpriteRectangleSize);
            SpawnEnemies(8 * Complexity);
        }

        private void EnemySuppliesTimerOnTick(object sender, EventArgs e)
        {
            SpawnEnemies(NeededSupplies);
        }

        private void GetOrders(object sender, EventArgs e)
        {
            switch (CurrentStrategy)
            {
                
                case Strategy.WaitOrders:
                    CurrentStrategy = GetStrategy();
                    break;
                case Strategy.PrepareToAttack:
                    PrepareToAttack();
                    break;
                case Strategy.Attack:
                    Attack();
                    CurrentStrategy = Strategy.WaitOrders;
                    break;
                case Strategy.Defend:
                    NeededSupplies = Complexity * 6;
                    AllSuppliesToMainTrench();
                    CurrentStrategy = Strategy.WaitOrders;
                    break;
                case Strategy.Rush:
                    Attack();
                    CurrentStrategy = Strategy.Attack;
                    break;
            
            }
        }

        private Strategy GetStrategy()
        {
            var enemyTrench = 1000;
            if (GameModel.EnemyUnits.Count > 5) 
                enemyTrench = GameModel.EnemyUnits.Where(x => Map.Trenches.Any(i => x.PosX <= i)).Min(x => x.PosX);
            var trenchNumber = 0;
            for (var i = 0; i < Map.Trenches.Length; i++)
            {
                if (Map.Trenches[i] == enemyTrench)
                    trenchNumber = i;
            }

            var allyTrench = Map.Trenches[trenchNumber];
            if (allyTrench > MaxAllyTrench)
            {
                MaxAllyTrench = allyTrench;
                SpawnEnemies(6*Complexity);
                GameModel.PlayerSecretDocuments += 1;
            }

            if (enemyTrench == 0)
            {
                return Strategy.Defend;
            }

            var playerUnitsInTrench = GameModel.PlayerUnits.Count(unit => unit.PosX == allyTrench);
            var enemyUnitsInTrench = GameModel.EnemyUnits.Count(unit => unit.PosX == enemyTrench);

            if (enemyUnitsInTrench < 10)
                return Strategy.Defend;

            if (playerUnitsInTrench <= 5)
            {
                return Strategy.Rush;
            }

            if(playerUnitsInTrench - enemyUnitsInTrench < 5)
            {
                return Strategy.Attack;
            }

            return playerUnitsInTrench - enemyUnitsInTrench < 10 ? Strategy.PrepareToAttack : Strategy.Defend;
        }
    

        private void PrepareToAttack()
        {
            AllSuppliesToMainTrench();
            NeededSupplies = Complexity*10;
        }

        private void Attack()
        {
            foreach (var unit in GameModel.EnemyUnits)
            {
                unit.MoveToNextTrench();
            }
            NeededSupplies = Complexity*4;
        }

        private void AllSuppliesToMainTrench()
        {
            var maxTrenchCord = 1000;
            if (GameModel.EnemyUnits.Count > 0) 
                maxTrenchCord = GameModel.EnemyUnits.Where(x => Map.Trenches.Any(i => x.PosX <= i) && x.IsAlive == 1).Min(x => x.PosX);
            foreach (var unit in GameModel.EnemyUnits)
            {
                unit.MoveToAllyTrench(maxTrenchCord);
            }
        }
        private void SpawnEnemies(int numberOfEnemies)
        {
            for (var i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemyUnit();
            }
        }

        private void SpawnEnemyUnit()
        {
            var entityToAdd = new Entity(GameModel)
            {
                PosX = Map.MapWidth - ViewGraphics.SpriteRectangleSize,
                PosY = rnd.Next(ViewGraphics.SpriteRectangleSize + Interface.ButtonsHeight, Map.MapHeight - ViewGraphics.SpriteRectangleSize - Interface.ButtonsHeight),
                IdleFrames = 4,
                RunFrames = 8,
                DeadFrames = 7,
                CurrentLimit = 4,
                AttackFrames = 14,
                IsEnemy = true,
                SpriteList = ViewGraphics.EnemyUnitSprite,

            };
            entityToAdd.OrderedPosition = entityToAdd.PosY;
            GameModel.AllUnits.Add(entityToAdd);
            GameModel.EnemyUnits.Add(entityToAdd);
            entityToAdd.MoveToNextTrench();
        }
    }
}
