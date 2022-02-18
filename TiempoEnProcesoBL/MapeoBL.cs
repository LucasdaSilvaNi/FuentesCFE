using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoBL
{
    public static class MapeoBL
    {
        

        public static void MapFromEntityToEntityFramework()
        {
            AutoMapper.MapperConfiguration ConfMapperEmp = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TiempoEnProcesoDL.tbl_empleados, TiempoEnProcesoEN.EmpleadoEN>());
            AutoMapper.MapperConfiguration ConfMapperPue = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TiempoEnProcesoDL.tbl_puestos, TiempoEnProcesoEN.PuestoEN>());



            /*AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.ChannelEN), typeof(FoxOnAir_DL.CHANNELS_LOOKUP_VW));
            AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.CurrencyEN), typeof(FoxOnAir_DL.CURRENCY_VW));
            AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.AdvertiserEN), typeof(FoxOnAir_DL.ADVERTISER));
            AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_EN.AgencyEN), typeof(FoxOnAir_DL.ADVERTISER));*/
        }

        public static void MapFromEntityFrameworkToEntity()
        {
            AutoMapper.MapperConfiguration ConfMapperEmp = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TiempoEnProcesoEN.EmpleadoEN, TiempoEnProcesoDL.tbl_empleados>());
            AutoMapper.MapperConfiguration ConfMapperPue = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<TiempoEnProcesoEN.PuestoEN, TiempoEnProcesoDL.tbl_puestos>());

            /*AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_DL.CHANNELS_LOOKUP_VW), typeof(FoxOnAir_EN.ChannelEN));
            AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_DL.CURRENCY_VW), typeof(FoxOnAir_EN.CurrencyEN));
            AutoMapper.Mapper.CreateMap(typeof(FoxOnAir_DL.ADVERTISER), typeof(FoxOnAir_EN.AdvertiserEN));*/
        }
    }
}
