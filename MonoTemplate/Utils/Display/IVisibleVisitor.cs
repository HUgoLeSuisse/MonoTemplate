using BuildAndDestroy.GameComponents.Utils;
using MonoTemplate.Utils.Display.UI.Element;

namespace Monotemplate.Utils.Display
{
    /// <summary>
    /// Peremet d'appeler une fonction différante en fonction du type spécifique appelé // Interface Visiteur
    /// </summary>
    public interface IVisibleVisitor
    {
        public void Visit(IVisible v);
        public void Visit(Pannel v);
        public void Visit(Label v);
        public void Visit(Button v);

    }

}