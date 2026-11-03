using System;

namespace DalilAcademy.Core.DTOs;

public record PageResulte<T>(List<T> items,int Page,int PageSize,int TotalCount)
{
    public int TotalPages=> (int)Math.Ceiling((double)TotalCount/PageSize);

}
