using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotemplate.Utils
{
    public interface ICleanable
    {
        /// <summary>
        /// Permet de supprimer une instance complétement
        /// </summary>
        public void Destroy();
    }
}
