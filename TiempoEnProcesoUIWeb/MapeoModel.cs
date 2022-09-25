using TiempoEnProcesoDL;
using TiempoEnProcesoEN;
using TiempoEnProcesoUIWeb.Models;

namespace TiempoEnProcesoUIWeb
{
    public class MapeoModel : AutoMapper.Profile
    {
        public static void Mapeos()
        {
            //MapFromModelToEntity();
            //MapFromEntityToModel();

            //MapeoBL.MapFromEntityToEntityFramework();
            //MapeoBL.MapFromEntityFrameworkToEntity();
        }

        //private static void MapFromModelToEntity()
        //{
        //}

        //private static void MapFromEntityToModel()
        //{
        //    //AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.SalesTeamEN), typeof(Models.SalesTeamModel));
        //}

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => a.AddProfile<MapeoModel>());
        }

        protected override void Configure()
        {
            CreateMap<tbl_empleados, EmpleadoEN>();
            CreateMap<tbl_oficina, OficinaEN>();

            CreateMap<TP_lst_Clientes_Result, ClienteEN>()
                .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.Clave))
                .ForMember(dest => dest.razon_social, opt => opt.MapFrom(src => src.Nombre));

            CreateMap<ClienteEN, ClientesModel>();
        }
    }
}