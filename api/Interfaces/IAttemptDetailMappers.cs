using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.AttemptDetail;
using api.Models;

namespace api.Interfaces
{
    public interface IAttemptDetailMappers
    {
        AttemptDetail ToAttemptDetailFromAttemptDetailRequestDto(AttemptDetailRequestDto request);
    }
}