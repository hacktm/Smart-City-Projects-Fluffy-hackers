using System.Drawing;
using System.Windows.Forms;

namespace ConvertVectorIntoImage
{
    internal class GraphicCreator : Control
    {
        private Graphics _graphics;
        protected override void OnCreateControl()
        {
            _graphics = CreateGraphics();
            base.OnCreateControl();
        }

        internal void SaVedemDacasaCreate()
        {
            var i = 0;
        }
    }
}
