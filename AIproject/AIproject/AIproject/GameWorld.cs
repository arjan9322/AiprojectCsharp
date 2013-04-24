﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace AIproject
{
    class GameWorld
    {
        private static GameWorld instance;
        public List<BaseGameEntity> gameobjects;
        
        private GameWorld()
        {
            gameobjects = new List<BaseGameEntity>();
            //*TEST* 1 vehicle
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {

            Vehicle vehicle = new Vehicle(new Vector2(rnd.Next(20, 80), rnd.Next(20, 80)));
            vehicle.steeringBehaviour.SeekOn();
            vehicle.steeringBehaviour.SetTarget(new Vector2(400f, 300f));
            vehicle.Mass = 2;
            vehicle.MaxForce = 200;
            vehicle.MaxSpeed = 15;
            gameobjects.Add(vehicle);
            }

        }

        public static GameWorld GetInstance()
        {
            if (instance == null)
                instance = new GameWorld();
            return instance;
        }

        public void Update(float time_elapsed)
        {
            foreach (BaseGameEntity entity in gameobjects)
            {
                entity.Update(time_elapsed);
            }
        }

        public void Render()
        {
            foreach (BaseGameEntity entity in gameobjects)
            {
                entity.Render();
            }
        }

       
        public void AddGameEntity(BaseGameEntity entity)
        {
            gameobjects.Add(entity);
        }
    }
}
