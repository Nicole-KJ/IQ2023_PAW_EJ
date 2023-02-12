using DAL;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : IShipperDAL
    {
        #region Constructores

        private NorthWindContext context;

        public ShipperDALImpl()
        {
            context = new NorthWindContext();

        }

        public ShipperDALImpl(NorthWindContext northWindContext)
        {
            this.context = northWindContext;
        }

        #endregion

        #region Add

        public bool Add(Shipper shipper)
        {
            try
            {
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Add(shipper);
                    return unidad.Complete(); //para guardar en bd
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Get/Find

        public Shipper Get(int ShipperId)
        {
            try
            {
                Shipper shipper;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shipper = unidad.genericDAL.Get(ShipperId);
                }
                return shipper;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Shipper> Get()
        {
            try
            {
                IEnumerable<Shipper> shippers;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shippers = unidad.genericDAL.GetAll();
                }
                return shippers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Shipper> GetAll()
        {
            try
            {
                IEnumerable<Shipper> shippers;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shippers = unidad.genericDAL.GetAll();
                }
                return shippers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Remove

        public bool Remove(Shipper shipper)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Remove(shipper);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update

        public bool Update(Shipper shipper)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Update(shipper);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        #endregion
    }
}
