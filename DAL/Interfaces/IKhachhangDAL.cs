using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKhachhangDAL
    {

        void InsertKhachhang(string tenKhachHang, bool gioiTinh, string diaChi, string sdt, string email);
        Khachhang GetByID(int id);
        void upDateKhachhang(int id, string tenkh, bool gioitinh, string diachi, string sdt, string email);
        void deleteKhachhang(int id);

        //List<Khachhang> searchKhachhang(int pageIndex, int pageSize, out long total, string tenKhach, string diaChi);
    }
}
