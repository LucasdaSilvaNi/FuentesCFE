using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiempoEnProcesoBL;

namespace TiempoEnProcesoUIWeb
{
    public class MapeoModel
    {
        public static void Mapeos()
        {
            MapFromModelToEntity();
            MapFromEntityToModel();

            MapeoBL.MapFromEntityToEntityFramework();
            MapeoBL.MapFromEntityFrameworkToEntity();
        }

        private static void MapFromModelToEntity()
        {

        }

        private static void MapFromEntityToModel()
        {
            //AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.SalesTeamEN), typeof(Models.SalesTeamModel));
        }
    }
}