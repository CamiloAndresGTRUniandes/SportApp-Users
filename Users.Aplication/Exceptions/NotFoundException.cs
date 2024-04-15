

using System;

namespace Users.Aplication.Exceptions
{
    public class NotFoundException:ApplicationException
    {

        public NotFoundException(string name, object key):base($"Entity \"{name}\" key ({key}) no fue encontrado" )
        {

        }

    }
}
