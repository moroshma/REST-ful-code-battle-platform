﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;

namespace DataAccessLayer.Interfaces
{
    // Интерфейс для работы с моделью Пользователя. Он вообще нужен? 
    
    public interface IUserRepository : IRepository<User>
    {
        
    }
}