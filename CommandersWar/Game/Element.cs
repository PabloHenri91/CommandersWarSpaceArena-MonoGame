using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Hydra;

namespace CommandersWar.Game
{
    public class Element
    {
        internal Type element;
        internal Type strength;
        internal Type weakness;
        internal Color color;

        public Element(Type element, Type strength, Type weakness)
        {
            this.element = element;
            this.strength = strength;
            this.weakness = weakness;

            Color elementColor = GameColors.darkness;

            switch (element)
            {
                case Type.fire:
                    elementColor = GameColors.fire;
                    break;
                case Type.ice:
                    elementColor = GameColors.ice;
                    break;
                case Type.wind:
                    elementColor = GameColors.wind;
                    break;
                case Type.earth:
                    elementColor = GameColors.earth;
                    break;
                case Type.thunder:
                    elementColor = GameColors.thunder;
                    break;
                case Type.water:
                    elementColor = GameColors.water;
                    break;
                case Type.light:
                    elementColor = GameColors.light;
                    break;
                case Type.darkness:
                    elementColor = GameColors.darkness;
                    break;
            }

            color = elementColor;
        }

        internal static Dictionary<Type, Element> types = new Dictionary<Type, Element>
        {
            {Type.fire, new Element(Type.fire, Type.ice, Type.water)},
            {Type.ice, new Element(Type.ice, Type.wind, Type.fire)},
            {Type.wind, new Element(Type.wind, Type.earth, Type.ice)},
            {Type.earth, new Element(Type.earth, Type.thunder, Type.wind)},
            {Type.thunder, new Element(Type.thunder, Type.water, Type.earth)},
            {Type.water, new Element(Type.water, Type.fire, Type.thunder)},
            {Type.light, new Element(Type.light, Type.light, Type.darkness)},
            {Type.darkness, new Element(Type.darkness, Type.darkness, Type.light)}
        };

        public enum Type
        {
            fire,
            ice,
            wind,
            earth,
            thunder,
            water,
            light,
            darkness
        }
    }
}
