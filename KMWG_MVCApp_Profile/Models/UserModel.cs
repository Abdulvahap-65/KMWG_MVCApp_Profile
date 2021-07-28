using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace KMWG_MVCApp_Profile.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.Address = new List<string>();
        }
        public int Id { get; set; }
        [Display(Name="Adı Soyadı")]
        public string  Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Display(Name = "Doğum Tarihi")]
        public DateTime BDate { get; set; }
        [Display(Name = "Kilo")]
        public int Kilo { get; set; }
        [Display(Name = "Adresleri")]
        public List<string> Address { get; set; }
        [Display(Name = "Kullanıcı Grubu")]
        public UserGroupModel UserGroup { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Cinsiyeti")]
        public cinsiyet Gender { get; set; }
    }
    public class UserGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public enum cinsiyet
    {
        None=0,
        Erkek=1,
        Kadın=2,
    }
}