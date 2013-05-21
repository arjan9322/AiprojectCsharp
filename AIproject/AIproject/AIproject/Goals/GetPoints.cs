using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject.Goals
{
    class GetPoints : Goal // find and follow route to closest points
    {
        private Vehicle parent;

        public GetPoints(Vehicle _parent)
        {
            parent = _parent;
        }
        public override void Update()
        {
            
        }
    }
}
