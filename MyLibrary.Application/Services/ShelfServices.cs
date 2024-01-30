using MyLibrary.Application.Interfaces;
using MyLibrary.Domain.Models;
using MyLibrary.Inrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Services
{


    public class ShelfServices : IShelfServices
    {
        IMyLibraryDb _myLibraryDb;

        public ShelfServices(IMyLibraryDb myLibraryDb)
        {
            _myLibraryDb = myLibraryDb;
        }

        public List<Shelf> GetShelfs()
        {
            return _myLibraryDb.Shelfs.ToList();
        }


        public Shelf GetShelfById(int shelfId)
        {
            if (shelfId > 0)
            {
                try
                {
                    return _myLibraryDb.Shelfs.Single(b => b.Id == shelfId);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return new Shelf();
        }
    }
}
