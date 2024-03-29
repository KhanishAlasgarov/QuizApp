﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Special
{
    public interface IQuestionRepository:IRepository<Question>
    {
        public bool IsCorrect(Guid questionId, Guid answerId);
    }
}
