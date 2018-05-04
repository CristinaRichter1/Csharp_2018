using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using temaCsharp.Entities;

namespace temaCsharp.Models
{
    /*
     * Handles DB interaction for the app
     * 
     */
    class HardwareModel
    {
        #region Setup singleton
        private OleDbConnection connection;

        public static HardwareModel instance = null;

        private HardwareModel(OleDbConnection connection)
        {
            this.connection = connection;
        }

        public static HardwareModel getInstance(OleDbConnection connection)
        {
            if (HardwareModel.instance == null)
            {
                HardwareModel.instance = new HardwareModel(connection);
                return HardwareModel.instance;
            }
            else {
                return HardwareModel.instance;
            }
        }
        #endregion Setup singleton

        #region Big 4 for components
        public List<Component> listComponents()
        {
            throw new NotImplementedException();
            //return new List<Component>();
        }

        public int insertComponent()
        {
            throw new NotImplementedException();
        }

        public int editComponent(int ID, Component component)
        {
            throw new NotImplementedException();
        }

        public int deleteComponent(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion Big 4 for components

        #region Big 4 for computers
        public List<Computer> listComputers()
        {
            throw new NotImplementedException();
            //return new List<Computer>();
        }

        public int insertComputer()
        {
            throw new NotImplementedException();
        }

        public int editComputer(int ID, Computer computer)
        {
            throw new NotImplementedException();
        }

        public int deleteComputer(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion Big 4 for computers
    }
}
