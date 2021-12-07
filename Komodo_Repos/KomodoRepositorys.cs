using Komodo_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public  class KomodoRepositorys
    {
        private  List<Devs> _listOfDevs = new List<Devs>();
        //c
        public void AddDevToList(Devs dev)
        {
            _listOfDevs.Add(dev);   

        }
        //r
        public List<Devs> GetListOfDevs()
        {
            return _listOfDevs;
        }
        // read gets user by string id
        public Devs GetDevByID(string input)
        {
            foreach (Devs dev in _listOfDevs)
            {
                if (dev.Dev_ID == input)
                {
                    return dev;
                }
            }
            return null;
        }

        //u
        public Devs UpdateExistingDev(string originalID, Devs newDev)
        {
            //find the dev
            Devs oldDev = GetDevByID(originalID);
            //update dev
            if(oldDev != null)
            {
                oldDev.Name = newDev.Dev_ID;
                oldDev.Dev_ID = newDev.Dev_ID;
                oldDev.HasAccessToPlural = newDev.HasAccessToPlural;
                oldDev.TypeOfDev = newDev.TypeOfDev;

                return newDev;
            }
            else { return null; }
        }
      

        //public  void UpdateExistingDev(string originalID, Devs newDev)
        //{
            //**********need to make get dev by id not by list number
           // Devs oldDev = GetDevByID(originalID);
         
        //        if (oldDev != null)
        //    {
        //        oldDev.Dev_ID = newDev.Dev_ID;
        //    }
        

        //d
        public bool RemoveDevFromList(string ID)
        {
            Devs dev = GetDevByID(ID);
            if (dev == null)
            {
                return false;
            }
            int initialCount = _listOfDevs.Count;
            _listOfDevs.Remove(dev);

            if (initialCount > _listOfDevs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //Extra 
        public Devs GetDevsByUserName(string ID)
        {
            foreach (Devs dev in _listOfDevs)
            {
                if (dev.Name == ID)
                {
                    return dev;
                }
            }
            return null;

        }

       

      
    }
}
