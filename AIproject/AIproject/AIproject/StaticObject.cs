using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    class StaticObject : BaseGameEntity
    {

        StaticObject(float _x, float _y){
            pos = new Vector2(_x, _y);
        }

        public override void Render(){
        }

        public override void Update(float time_elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
