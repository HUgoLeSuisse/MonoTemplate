using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monotemplate.Utils.Display;
using System;
using System.Collections.Generic;

namespace MonoTemplate.Utils.Display.UI.Element
{
    /// <summary>
    /// Element contenant d'autres elements
    /// </summary>
    public class Pannel : Element
    {
        private List<Element> childrens = new List<Element>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">Rectangle relatif à la Position du parent</param>
        /// <param name="color">Couleur de l'element(par defaut blanc)</param>
        /// <param name="texture">TextureBG de l'element (par defaut 1x1 blanc)</param>
        public Pannel(Rectangle rect, Color? color, Texture2D image) : base(rect, color, image)
        {
        }

        /// <summary>
        /// Obtient un tableau avec tous les enfants du panneau
        /// </summary>
        /// <returns></returns>
        public Element[] GetChilds()
        {
            return childrens.ToArray();
        }

        /// <summary>
        /// Permet d'ajouter un enfant
        /// </summary>
        /// <param name="child"></param>
        public void Add(Element child)
        {
            childrens.Add(child);
            child.Parent = this;
        }

        /// <summary>
        /// Permet à VisibleVistor de fonctionner
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IVisibleVisitor v)
        {
            v.Visit(this);
        }

        public void Remove(Element uI_Element)
        {
            childrens.Remove(uI_Element);
        }

        public override void Destroy()
        {
            base.Destroy();
            var childrensArray = childrens.ToArray();
            foreach (var item in childrensArray)
            {
                item.Destroy();
            }
            childrens.Clear();
        }
    }
}
