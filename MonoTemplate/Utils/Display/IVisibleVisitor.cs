using BuildAndDestroy.GameComponents.Utils;

namespace Monotemplate.Utils.Display
{
    /// <summary>
    /// Peremet d'appeler une fonction différante en fonction du type spécifique appelé // Interface Visiteur
    /// </summary>
    public interface IVisibleVisitor
    {
        public void Visit(IVisible v);

    }

}