using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class GameObjectHelper
    {
        public static GameObject[] FindByTagInOrder(string tag)
        {
            return GameObject.FindGameObjectsWithTag(tag).OrderBy(x => x.name).ToArray();
        }
//
//        public static GameObject[] FindInOrder(this string tag)
//        {
//            return FindByTagInOrder(tag);
//        }
    }
}
