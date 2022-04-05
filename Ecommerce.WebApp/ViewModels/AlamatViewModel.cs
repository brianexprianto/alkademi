using Ecommerce.WebApp.Datas.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.ViewModels
{
    public partial class AlamatViewModel
    {
        public AlamatViewModel()
        {
            
        }

        public AlamatViewModel(int idAlamat, int idCustomer){
            IdAlamat = idAlamat;
            IdCustomer = idCustomer;
        }

        public int IdAlamat { get; set; }
        public int IdCustomer { get; set; }
        public string Kec { get; set; } = null!;
        public string Kel { get; set; } = null!;
        public string KabKota { get; set; } = null!;
        public string Prov { get; set; } = null!;
        public string DetailAlamat { get; set; } = null!;
        public string KodePos { get; set; } = null!;

        public Alamat ConvertToDbModel(){
            return new Alamat(){
                IdAlamat = this.IdAlamat,
                IdCustomer = this.IdCustomer,
                DetailAlamat = this.DetailAlamat,
                Kec = this.Kec,
                Kel = this.Kel,
                KabKota = this.KabKota,
                Prov = this.Prov,
                KodePos = KodePos,
            };
        }

    }
}
