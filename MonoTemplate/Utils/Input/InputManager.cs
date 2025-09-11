using BuildAndDestroy.GameComponents.Utils;
using Microsoft.Xna.Framework.Input;
using Monotemplate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotemplate.Utils.Input
{
    public class InputManager : ICleanable
    {
        Dictionary<string, InputAction> inputs = new Dictionary<string, InputAction>();
        public InputManager() { }

        /// <summary>
        /// Permet de créer ou remplacer un input déjà existant
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public void PutInput(string name, Keys key)
        {
            if (inputs.ContainsKey(name))
            {
                inputs[name] = new InputAction(key);
            }
            else
            {
                inputs.Add(name, new InputAction(key));
            }
        }

        public Dictionary<string, InputAction> GetInputs()
        {
            return inputs;
        }

        public void Destroy()
        {
            foreach (var item in inputs)
            {
                item.Value.Destroy();
                
            }
            inputs.Clear();
        }
    }
}
