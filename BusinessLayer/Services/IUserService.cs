using DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        void InsertUser(UserSignUp userSignUp);
        void Save();
    }
}
