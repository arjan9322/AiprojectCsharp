using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject.Goals
{
    class GetRepair : Goal // find and follow route to closest repair
    {
        private Vehicle parent;

        public GetRepair(Vehicle _parent)
        {
            parent = _parent;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
