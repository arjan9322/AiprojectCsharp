using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject
{
    class GameWorld
    {
        private static GameWorld instance;
        public List<BaseGameEntity> gameobjects;

        private GameWorld()
        {
            gameobjects = new List<BaseGameEntity>();
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
