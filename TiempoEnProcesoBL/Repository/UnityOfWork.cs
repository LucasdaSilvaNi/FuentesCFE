using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public class UnityOfWork
    {
        private TEPEntities tep { get; }

        private EmpleadosRepository empleadosRepo { get; set; }

        private ParametrosRepository parametrosRepo { get; set; }

        private OficinaRepository oficinaRepo { get; set; }

        private ConceptosRepository conceptosRepo { get; set; }

        private ReportesTiempoRepository reportesTiempoRepo { get; set; }

        private NoCargableRepository noCargableRepo { get; set; }

        public UnityOfWork()
        {
            tep = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
        }

        public EmpleadosRepository EmpleadosRepository
        {
            get
            {
                if (empleadosRepo == null)
                    empleadosRepo = new EmpleadosRepository(tep);

                return empleadosRepo;
            }
        }

        public ParametrosRepository ParametrosRepository
        {
            get
            {
                if (parametrosRepo == null)
                    parametrosRepo = new ParametrosRepository(tep);

                return parametrosRepo;
            }
        }

        public OficinaRepository OficinaRepository
        {
            get
            {
                if (oficinaRepo == null)
                    oficinaRepo = new OficinaRepository(tep);

                return oficinaRepo;
            }
        }

        public ConceptosRepository ConceptosRepository
        {
            get
            {
                if (conceptosRepo == null)
                    conceptosRepo = new ConceptosRepository(tep);

                return conceptosRepo;
            }
        }

        public ReportesTiempoRepository ReportesTiempoRepository
        {
            get
            {
                if (reportesTiempoRepo == null)
                    reportesTiempoRepo = new ReportesTiempoRepository(tep);

                return reportesTiempoRepo;
            }
        }

        public NoCargableRepository NoCargableRepository
        {
            get
            {
                if (noCargableRepo == null)
                    noCargableRepo = new NoCargableRepository(tep);

                return noCargableRepo;
            }
        }

    }
}