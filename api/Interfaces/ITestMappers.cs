using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Interfaces
{
    public interface ITestMappers
    {
        Test ToTestFromTestCreateRequestDto(TestCreateRequestDto request);
        List<TestResponseDto> ToTestResponseDtosFromTests(List<Test> tests);
        TestResponseDtoWithQuestion ToTestResponseDtoWithQuestionFromTest(Test test);
    }
}