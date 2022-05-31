﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.View;

namespace MyGame.Model
{
    public class GameModel
    {
        public int Hard;
        public Entity CurrentGunner;
        public int GunnerNewPosition;
        public bool PreparingToGetSupplies;
        public bool GunnerWaitOrders;
        public bool IsWaitingForArtilleryFire;
        public int NumOfRiflemansToSupply;
        public int NumOfGunnersToSupply;
        public int LowerSuppliesPosition;
        public int UpperSuppliesPosition;
        public int SpawnSizeConst;
        public List<Entity> AllUnits = new List<Entity>();
        public List<Entity> PlayerUnits = new List<Entity>();
        public List<Entity> EnemyUnits = new List<Entity>();
        public Random HitRandom = new Random();
        public Artillery PlayerArtillery;
        public int PlayerMoney = 100;
        public int PlayerSecretDocuments = 1;
        public int MaxPlayerTrenches = 1;
        public int EnemyKilled;
        public int PlayerUnitsKilled;

        public GameModel(int hard)
        {
            Hard = hard;
        }

        public double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));

        }

        public void SpawnRiflemans(int numberOfUnits, int lowerPos, int upperPos)
        {
            for (var x = 0; x < numberOfUnits; x++)
            {
                var entityToAdd = new Entity(this)
                {
                    PosX = HitRandom.Next(0,35),
                    PosY = HitRandom.Next(lowerPos, upperPos),
                    //(ViewGraphics.SpriteRectangleSize + Interface.ButtonsHeight, Map.MapHeight - ViewGraphics.SpriteRectangleSize - Interface.ButtonsHeight)
                    IdleFrames = 4,
                    RunFrames = 8,
                    DeadFrames = 7,
                    CurrentLimit = 4,
                    AttackFrames = 14,
                    SpriteList = ViewGraphics.FriendlyUnitSprite,

                };
                entityToAdd.OrderedPosition = entityToAdd.PosY;
                AllUnits.Add(entityToAdd);
                PlayerUnits.Add(entityToAdd);
                entityToAdd.MoveToNextTrench();
            }
        }

        public void SpawnGunners(int numberOfUnits, int lowerPos, int upperPos)
        {
            for (var x = 0; x < numberOfUnits; x++)
            {
                var entityToAdd = new Entity(this)
                {
                    PosX = HitRandom.Next(0, 35),
                    PosY = HitRandom.Next(lowerPos, upperPos),
                    //(ViewGraphics.SpriteRectangleSize + Interface.ButtonsHeight, Map.MapHeight - ViewGraphics.SpriteRectangleSize - Interface.ButtonsHeight)
                    IdleFrames = 4,
                    RunFrames = 2,
                    DeadFrames = 8,
                    CurrentLimit = 4,
                    AttackFrames = 4,
                    SpriteList = ViewGraphics.AllyGunnerSpriteList,
                    IsGunner = true,
                    PercentOfHit = 60,
                    FireRange = 163

                };
                entityToAdd.OrderedPosition = entityToAdd.PosY;
                AllUnits.Add(entityToAdd);
                PlayerUnits.Add(entityToAdd);
                entityToAdd.MoveToNextTrench(true);
            }
        }
        public void DrawArtillery()
        {
            PlayerArtillery = new Artillery(this)
            {
                PosX = 0,
                PosY = 400,
                IdleFrames = 1,
                AttackFrames = 53,
                CurrentLimit = 1,
                SpriteList = ViewGraphics.ArtillerySpriteSheet,
                Explosive = new Explosive()
            };
        }

        public void CleanCorps(object sender, EventArgs e)
        {
            var newAllUnits = AllUnits.Where(x => x.IsReadyToClean == false).ToList();
            AllUnits.Clear();
            AllUnits = newAllUnits;

            var newPlayerUnits = PlayerUnits.Where(x => x.IsReadyToClean == false).ToList();
            PlayerUnits.Clear();
            PlayerUnits = newPlayerUnits;

            var newEnemyUnits = EnemyUnits.Where(x => x.IsReadyToClean == false).ToList();
            EnemyUnits.Clear();
            EnemyUnits = newEnemyUnits;
        }

        public void AddMoney(object sender, EventArgs e)
        {
            Interface.PlayMoneySound();
            PlayerMoney += GetNumberOfPlayerTrenches()*25;
        }

        public int GetNumberOfPlayerTrenches()
        {
            var result = Map.Trenches.LastOrDefault(trenchCord => PlayerUnits.Any(x => x.PosX == trenchCord));
            switch (result)
            {
                case 86:
                    return 1;
                case 250:
                    return 2;
                case 500:
                    return 3;
                case 750:
                    return 3;
                case 1000:
                    return 4;
                default: return 0;
            }
        }
    }
}
