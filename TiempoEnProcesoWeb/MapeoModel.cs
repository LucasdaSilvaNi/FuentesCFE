using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb
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
        }
    }
}