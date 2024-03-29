﻿using ProgrammingCodePro.Models;

namespace ProgrammingCodePro.Service.Interface
{
    public interface IMyApplication
    {
        Task<List<ApplicationDto>> GetDataApplication(int idUserDto);

        Task<bool> PostDataApplication(ApplicationDto myApplicationDto);

        Task<bool> PutDataApplication(ApplicationDto myApplicationDto, int idApplicationDto);

        Task<bool> LikeCourse(int idApplicationDto);

        Task<bool> ScoreCourse(int idApplicationDto);

        Task<List<ApplicationDto>> SearchingMyApplication(string seachDataDto, int idUserDto);
    }
}