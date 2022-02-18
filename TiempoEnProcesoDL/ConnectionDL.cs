using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoDL
{
    public partial class TEPEntities
    {
        public TEPEntities(string connectionString)
            : base(connectionString)
        {

        }
        public int SaveChanges(bool refreshOnConcurrencyException, System.Data.Entity.Core.Objects.RefreshMode refreshMode = System.Data.Entity.Core.Objects.RefreshMode.ClientWins)
        {
            try
            {
                return SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                foreach (System.Data.Entity.Infrastructure.DbEntityEntry entry in ex.Entries)
                {
                    if (refreshMode == System.Data.Entity.Core.Objects.RefreshMode.ClientWins)
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    else
                        entry.Reload();
                }
                return SaveChanges();
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .Take(10)
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");
                if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
                    !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
                {
                    try
                    {
                        foreach (var result in ex.Entries)
                        {
                            builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                        }
                    }
                    catch (Exception e)
                    {
                        builder.Append("Error parsing DbUpdateException: " + e);
                    }
                }
                else
                {
                    var sqlException = (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;
                    for (int i = 0; i < sqlException.Errors.Count; i++)
                    {
                        builder.AppendLine("    SQL Message: " + sqlException.Errors[i].Message);
                        builder.AppendLine("    SQL procedure: " + sqlException.Errors[i].Procedure);
                    }
                }

                string message = builder.ToString();
                throw new Exception(message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
