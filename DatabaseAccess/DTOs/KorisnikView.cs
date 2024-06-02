using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class KorisnikView
    {
        public int JMBG { get; set; }

        public string Licno_ime { get; set; }
        public string Ime_roditelja { get; set; }
        public string Prezime { get; set; }
        public string Email_adresa { get; set; }
        public string Korisnicko_ime { get; set; }
        public string Funkcija { get; set; }
        public int Broj_kancelarije { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Radno_mesto { get; set; }
        public string Trenutna_sifra { get; set; }

        public DateTime DatumIVreme { get; set; }
        public string PogresnaSifra { get; set; }
        //--------------------------- Prikaz za adresu---------------------------
        //public int AdresaVrednost { get; set; }
        //--------------------------- #Prikaz za adresu#---------------------------
        public IP_AdresaView Adresa { get; set; }
        public IList<GrupaKorisnikaView> GrupeKorisnika { get; set; }

        public IList<ProfilView> Profili { get; set; }
        public IList<TelefonView> Telefoni { get; set; }


        //Korisnik
        public IList<Dodeli> DodeljujeK { get; set; }

        public KorisnikView()
        {
            GrupeKorisnika = new List<GrupaKorisnikaView>();
            Profili = new List<ProfilView>();
            Telefoni = new List<TelefonView>();
        }
        public KorisnikView(Korisnik dodeljujeKorisnik)
        {
            JMBG = dodeljujeKorisnik.JMBG;
            Licno_ime = dodeljujeKorisnik.Licno_ime;
            Ime_roditelja = dodeljujeKorisnik.Ime_roditelja;
            Prezime = dodeljujeKorisnik.Prezime;
            Email_adresa = dodeljujeKorisnik.Email_adresa;
            Korisnicko_ime = dodeljujeKorisnik.Korisnicko_ime;
            Funkcija = dodeljujeKorisnik.Funkcija;
            Broj_kancelarije = dodeljujeKorisnik.Broj_kancelarije;
            Datum_rodjenja = dodeljujeKorisnik.Datum_rodjenja;
            Radno_mesto = dodeljujeKorisnik.Radno_mesto;
            Trenutna_sifra = dodeljujeKorisnik.Trenutna_sifra;
            DatumIVreme = dodeljujeKorisnik.DatumIVreme;
            PogresnaSifra = dodeljujeKorisnik.PogresnaSifra;
            //AdresaVrednost = dodeljujeKorisnik.Adresa.Adresa;
            Adresa = new IP_AdresaView(dodeljujeKorisnik.Adresa);
        }
    }
}
