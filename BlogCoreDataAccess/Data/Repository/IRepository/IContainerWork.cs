using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreDataAccess.Data.Repository.IRepository
{
    public interface IContainerWork : IDisposable
    {
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; set; }
        IUsuarioRepository Usuario { get; set; }
        void Save();

    }
}
