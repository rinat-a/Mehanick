using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class LostControl
    {
        public LostControl(int _count, string _name)
        {
            count = _count;
            name = _name;
        }
        public int count;
        public string name;
    }
}

