using DTO;
using DAL;
using DAL.Interfaces;
using BLL.Interfaces;
using DTO;

namespace BLL
{
    public class KhachhangBLL : IKhachhangBLL
    {
        private IKhachhangDAL _khachhangDAL;

        public KhachhangBLL(IKhachhangDAL khachhang)
        {
            this._khachhangDAL = khachhang;
        }


        public void InsertKhachHang(string tenKhachHang, bool gioiTinh, string diaChi, string sdt, string email)
        {
            _khachhangDAL.InsertKhachhang(tenKhachHang, gioiTinh, diaChi, sdt, email);
        }

        public Khachhang getById(int id)
        {
            return _khachhangDAL.GetByID(id);
        }
        public void upDateKhachhang(int id, string tenkh, bool gioitinh, string diachi, string sdt, string email)
        {
            _khachhangDAL.upDateKhachhang(id, tenkh, gioitinh, diachi, sdt, email);
        }

        public void deleteKhachhang(int id)
        {
            _khachhangDAL.deleteKhachhang(id);
        }



        //public List<KhachhangModel> searchKhachhang(int pageIndex, int pageSize, out long total, string tenKhach, string diaChi)
        //{
        //   return _khachhangDAL.searchKhachhang(pageIndex, pageSize, out total, tenKhach, diaChi);
        //}


    }
}
