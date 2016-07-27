using AutoMapper;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class MapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Alumno, AlumnoDTO>();
            Mapper.CreateMap<Asignatura, AsignaturaDTO>();
            Mapper.CreateMap<Nota, NotaDTO>();
            Mapper.CreateMap<AlumnoDTO, Alumno>();
            Mapper.CreateMap<AsignaturaDTO, Asignatura>();
            Mapper.CreateMap<NotaDTO, Nota>();
        }
    }
}
