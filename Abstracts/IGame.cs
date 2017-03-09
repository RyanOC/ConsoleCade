using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracts
{
    public interface IGame
    {
        string Name { get; }
        string Description { get; }
        void Load();
        void UnLoad();
    }
}
