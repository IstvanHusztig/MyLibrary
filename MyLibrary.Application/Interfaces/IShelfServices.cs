using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Interfaces
{
    public interface IShelfServices
    {
        Shelf GetShelfById(int shelfId);
        List<Shelf> GetShelfs();
    }
}
