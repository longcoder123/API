using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoadonBLL : IHoadonBLL
    {
        private IHoadonDAL _res;


        public Hoadon GetHoadonByID(int maHoaDon)
        {
            return _res.GetHoadonByID(maHoaDon);
        }


    }
}

