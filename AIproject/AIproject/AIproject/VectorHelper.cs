using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    static class VectorHelper
    {
        public static Vector2 ToLimit(Vector2 vector, float limit)
        {
            if (vector.Length() > limit)
            {
                float factor = vector.Length() / limit;
                vector = vector / factor;
            }
            return vector;
        }
    }
}
