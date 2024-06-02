using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Privilegije_korisnika.Entiteti;
using DatabaseAccess.DTOs;
using DatabaseAccess.Entiteti;
//using System.Windows.Forms;


namespace Privilegije_korisnika
{
    public class DTOManager
    {
        #region Korisnik
        public static List<KorisnikView> vratiSveKorisnike()
        {
            List<KorisnikView> korisnici = new List<KorisnikView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Korisnik> sviKorisnici = from o in s.Query<Korisnik>() select o;

                foreach(Korisnik k in sviKorisnici)
                {
                    korisnici.Add(new KorisnikView(k));
                }

                s.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ec.Message);
            }
            return korisnici;
        }
        public static void dodajKorisnika(KorisnikView nk)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa ip = s.Load<IP_Adresa>(nk.Adresa.Adresa);

                Korisnik k = new Korisnik
                {
                    JMBG = nk.JMBG,
                    Licno_ime = nk.Licno_ime,
                    Ime_roditelja = nk.Ime_roditelja,
                    Prezime = nk.Prezime,
                    Email_adresa = nk.Email_adresa,
                    Korisnicko_ime = nk.Korisnicko_ime,
                    Funkcija = nk.Funkcija,
                    Broj_kancelarije = nk.Broj_kancelarije,
                    Datum_rodjenja = nk.Datum_rodjenja,
                    Radno_mesto = nk.Radno_mesto,
                    Trenutna_sifra = nk.Trenutna_sifra,
                    DatumIVreme = nk.DatumIVreme,
                    PogresnaSifra = nk.PogresnaSifra,
                    Adresa=ip
                };

                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }
        public static KorisnikView azurirajKorisnika(KorisnikView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik kr = s.Load<Korisnik>(k.JMBG);
                kr.JMBG = k.JMBG;
                kr.Licno_ime = k.Licno_ime;
                kr.Ime_roditelja = k.Ime_roditelja;
                kr.Prezime = k.Prezime;
                kr.Email_adresa = k.Email_adresa;
                kr.Korisnicko_ime = k.Korisnicko_ime;
                kr.Funkcija = k.Funkcija;
                kr.Broj_kancelarije = k.Broj_kancelarije;
                kr.Datum_rodjenja = k.Datum_rodjenja;
                kr.Radno_mesto = k.Radno_mesto;
                kr.Trenutna_sifra = k.Trenutna_sifra;
                kr.DatumIVreme = k.DatumIVreme;
                kr.PogresnaSifra = k.PogresnaSifra;

                s.Update(kr);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return k;
        }
        public static KorisnikView vratiKorisnika(int id)
        {
            KorisnikView korV;

            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = s.Load<Korisnik>(id);
                korV = new KorisnikView(k);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return korV;
        }

        public static void obrisiKorisnika(int jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik o = s.Load<Korisnik>(jmbg);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GrupaKorisnika
        public static List<GrupaKorisnikaView> vratiSveGrupeKorisnike()
        {
            List<GrupaKorisnikaView> grupeKorisnika = new List<GrupaKorisnikaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GrupaKorisnika> sveGrupeKorisnika = from o in s.Query<GrupaKorisnika>() select o;

                foreach (GrupaKorisnika k in sveGrupeKorisnika)
                {
                    var grupa = new GrupaKorisnikaView(k);
                    grupa.IpAdrese = k.IpAdrese.Select(p => new IP_AdresaView(p)).ToList();
                    grupa.Korisnici = k.Korisnici.Select(p => new KorisnikView(p)).ToList();
                    grupeKorisnika.Add(grupa);
                }

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return grupeKorisnika;
        }

        public static void dodajGrupu(GrupaKorisnikaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GrupaKorisnika o = new GrupaKorisnika();

                o.JedinstvenoIme = k.JedinstvenoIme;
                o.KratakOpis = k.KratakOpis;
                o.PeriodPocetka = k.PeriodPocetka;
                o.PeriodZavrsetka = k.PeriodZavrsetka;
                o.DatumKreiranja = k.DatumKreiranja;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }

        public static void dodajKorisnikaUGrupu(int jmbg, string ime)
        {
            try
            {
                List<Sadrzi> pom = new List<Sadrzi>();
                ISession s = DataLayer.GetSession();

                Korisnik kor = s.Load<Korisnik>(jmbg);
                GrupaKorisnika gk = s.Get<GrupaKorisnika>(ime);
                IEnumerable<Sadrzi> provera = from o in s.Query<Sadrzi>() where o.Kor == kor && o.Grupa == gk select o;
                foreach (Sadrzi sad in provera)
                {
                    pom.Add(sad);
                }
                if (pom.Count==0) 
                {
                    Sadrzi sad = new Sadrzi();
                    sad.Kor = kor;
                    sad.Grupa = gk;


                    s.SaveOrUpdate(sad);
                    s.Flush();
                }
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }
        public static GrupaKorisnikaView vratiGrupuKorisnika(string jedime)
        {
            GrupaKorisnikaView grupaKorisnika;
            try
            {
                ISession s = DataLayer.GetSession();

                GrupaKorisnika k = s.Load<GrupaKorisnika>(jedime);

                grupaKorisnika = new GrupaKorisnikaView(k);

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return grupaKorisnika;
        }

        public static List<SadrziView> vratiKorisnikeGrupe(string jedime)
        {
                List<SadrziView> grupaKorisnika=new List<SadrziView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sadrzi> sad = from o in s.Query<Sadrzi>() where o.Grupa.JedinstvenoIme==jedime select o;

                foreach (Sadrzi pom in sad)
                {
                    grupaKorisnika.Add(new SadrziView(pom));
                }

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return grupaKorisnika;
        }
        public static GrupaKorisnikaView azurirajGrupuKorisnika(GrupaKorisnikaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GrupaKorisnika o = s.Load<GrupaKorisnika>(k.JedinstvenoIme);

                o.JedinstvenoIme = k.JedinstvenoIme;
                o.KratakOpis = k.KratakOpis;
                o.PeriodPocetka = k.PeriodPocetka;
                o.PeriodZavrsetka = k.PeriodZavrsetka;
                o.DatumKreiranja = k.DatumKreiranja;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }

            return k;
        }
        public static void obrisiGrupuKorisnika(string jedime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GrupaKorisnika o = s.Load<GrupaKorisnika>(jedime);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
        }
        #endregion

        #region IP_Adresa
        public static List<IP_AdresaView> vratiSveAdreseGrupe(string imeGrupe)
        {
            List<IP_AdresaView> adrese= new List<IP_AdresaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<IP_Adresa> sveAdrese = from o in s.Query<IP_Adresa>()
                                                   where o.ImaGrupuKorisnika.JedinstvenoIme==imeGrupe
                                                   select o;

                foreach (IP_Adresa k in sveAdrese)
                {
                    adrese.Add(new IP_AdresaView(k));
                }

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
            }
            return adrese;
        }

        public static IP_AdresaView vratiAdresu(int adresaVred)
        {
            IP_AdresaView adresa=new IP_AdresaView();
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa ip = s.Load<IP_Adresa>(adresaVred);

                adresa = new IP_AdresaView(ip);

                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
            }
            return adresa;
        }
        public static void dodajAdresu(IP_AdresaView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa o = new IP_Adresa();

                o.Adresa = k.Adresa;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }

        public static void dodeliAdresuGrupi(string grupa, int adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa o = s.Load<IP_Adresa>(adresa);
                GrupaKorisnika gk = s.Load<GrupaKorisnika>(grupa);
                o.ImaGrupuKorisnika = gk;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }


        public static void promeniAdresuKorisnika(int jmbg, int adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa adr = s.Load<IP_Adresa>(adresa);
                Korisnik k1 = s.Load<Korisnik>(jmbg);

                k1.Adresa = adr;

                s.SaveOrUpdate(k1);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiAdresu(int adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa r = s.Load<IP_Adresa>(adresa);

                s.Delete(r);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static IP_AdresaView azurirajAdresu(IP_AdresaView ip)
        {
            IP_AdresaView adresa = new IP_AdresaView();
            try
            {
                ISession s = DataLayer.GetSession();

                IP_Adresa k = s.Load<IP_Adresa>(ip.Adresa);
                GrupaKorisnika gk = s.Load<GrupaKorisnika>(ip.ImaGrupuKorisnika.JedinstvenoIme);
                k.ImaGrupuKorisnika = gk;
                Korisnik kor = s.Load<Korisnik>(ip.ImaKorisnika.JMBG);
                k.ImaKorisnika = kor;

                adresa = new IP_AdresaView(k);

                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
            return adresa;
        }
        #endregion

        #region BrojTelefona
        public static List<TelefonView> vratiSveTelefoneKorisnika(int jmbg)
        {
            List<TelefonView> brtel = new List<TelefonView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Telefon> sviTelefoni = from o in s.Query<Telefon>()
                                                   where o.Vlasnik.JMBG==jmbg
                                                   select o;

                foreach (Telefon k in sviTelefoni)
                {
                    brtel.Add(new TelefonView(k));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
            return brtel;
        }

        public static void dodajTelefon(int jmbg, TelefonView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Telefon o = new Telefon();
                Korisnik kor = s.Load<Korisnik>(jmbg);

                o.BrojTelefona = k.BrojTelefona;
                o.ID = k.ID;
                o.Vlasnik = kor;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
        }

        public static TelefonView azurirajTelefon(TelefonView t)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Telefon tel=s.Load<Telefon>(t.ID);
                Korisnik k = s.Load<Korisnik>(t.Vlasnik.JMBG);
                tel.Vlasnik = k;
                tel.BrojTelefona=t.BrojTelefona;
                tel.ID= t.ID;
                s.Update(tel);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return t;
        }

        public static void obrisiTelefon(int brt)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Telefon> t = from o in s.Query<Telefon>() where o.BrojTelefona == brt select o;
                //Telefon o = s.Load<Telefon>(brt);
                foreach (Telefon tel in t)
                {
                    s.Delete(tel);
                }

                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }
        #endregion

        #region Privilegije

        #region KoriscenjeKorisnickogInterfejsa
        public static void obrisiKKI(int id)
        {
            try
            {
                try
                {
                    ISession s = DataLayer.GetSession();

                    KoriscenjeKorisnickogInterfejsa kfm = s.Load<KoriscenjeKorisnickogInterfejsa>(id);

                    s.Delete(kfm);
                    s.Flush();

                    s.Close();
                }
                catch (Exception)
                {
                    //handle exceptions
                    throw;
                }
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static VidiElementView vratiKKI(int id)
        {
            VidiElementView kfmv = new VidiElementView();

            try
            {
                ISession s = DataLayer.GetSession();

                VidiElement kki = s.Load<VidiElement>(id);
                kfmv = new VidiElementView(kki);
                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return kfmv;
        }
        public static void IzmeniKKI(KoriscenjeKorisnickogInterfejsaView kkiv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KoriscenjeKorisnickogInterfejsa o = s.Load<KoriscenjeKorisnickogInterfejsa>
                    (kkiv.Id);

                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static int dodajKKI(VidiElementView kkiv)// bilo kkiview
        {
            int id;
            try
            {
                ISession s = DataLayer.GetSession();

                VidiElement o = new VidiElement(); //bilo kki
                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;
                id = (int)s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return id;
        }

        public static VidiElementView vratiKKIJ(int id)
        {
            VidiElementView kfmv = new VidiElementView();

            try
            {
                ISession s = DataLayer.GetSession();

                VidiElement kki = s.Load<VidiElement>(id);
                kfmv = new VidiElementView(kki);
                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return kfmv;
        }
        #endregion KoriscenjeKorisnickogInterfejsa

        #region KoriscenjeFunkcionalnihModula
        public static void obrisiKFM(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KoriscenjeFunkcionalnihModula kfm = s.Load<KoriscenjeFunkcionalnihModula>(id);

                s.Delete(kfm);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static KoriscenjeFunkcionalnihModulaView vratiKFM(int id)
        {
            KoriscenjeFunkcionalnihModulaView kfmv = new KoriscenjeFunkcionalnihModulaView();

            try
            {
                ISession s = DataLayer.GetSession();

                KoriscenjeFunkcionalnihModula kki = s.Get<KoriscenjeFunkcionalnihModula>(id);
                kfmv = new KoriscenjeFunkcionalnihModulaView(kki);
                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return kfmv;
        }
        public static void IzmeniKFM(KoriscenjeFunkcionalnihModulaView kkiv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KoriscenjeFunkcionalnihModula o = s.Load<KoriscenjeFunkcionalnihModula>
                    (kkiv.Id);

                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static void dodajKFM(KoriscenjeFunkcionalnihModulaView kkiv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                KoriscenjeFunkcionalnihModula o = new KoriscenjeFunkcionalnihModula();    
;

                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static List<DodeliView> vratiKFMGrupe(string grupa)
        {
            List<DodeliView> adrese = new List<DodeliView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Dodeli> dodela = from o in s.Query<Dodeli>() where o.DodeljujeGrupi.JedinstvenoIme == grupa select o;

                foreach (Dodeli a in dodela)
                {
                    KoriscenjeFunkcionalnihModula pri = s.Get<KoriscenjeFunkcionalnihModula>(a.DodeljujuSePrivilegija.Id);
                    a.DodeljujuSePrivilegija = pri;
                    if (pri != null)
                    {
                        adrese.Add(new DodeliView(a));
                    }
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return adrese;
        }
        #endregion KoriscenjeFunkcionalnihModula

        #region Privilegija
        public static void obrisiAdm(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administrativne kfm = s.Load<Administrativne>(id);

                s.Delete(kfm);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static AdministrativneView vratiAdm(int id)
        {
            AdministrativneView kfmv = new AdministrativneView();

            try
            {
                ISession s = DataLayer.GetSession();

                Administrativne kki = s.Get<Administrativne>(id);
                kfmv = new AdministrativneView(kki);
                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return kfmv;
        }

        public static List<DodeliView> vratiAdms(string grupa)
        {
            List<DodeliView> adrese = new List<DodeliView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Dodeli> dodela = from o in s.Query<Dodeli>() where o.DodeljujeGrupi.JedinstvenoIme == grupa select o;

                foreach (Dodeli a in dodela)
                {
                    Administrativne pri = s.Get<Administrativne>(a.DodeljujuSePrivilegija.Id);
                    a.DodeljujuSePrivilegija = pri;
                    if (pri != null)
                    {
                        adrese.Add(new DodeliView(a));
                    }
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return adrese;
        }

        public static void IzmeniAdm(AdministrativneView kkiv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administrativne o = s.Load<Administrativne>
                    (kkiv.Id);

                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static int dodajAdm(AdministrativneView kkiv)
        {
            int id;
            try
            {
                ISession s = DataLayer.GetSession();

                Administrativne o = new Administrativne();

                o.Ime = kkiv.Ime;
                o.Tip = kkiv.Tip;

                id=(int)s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return id;
        }
        #endregion Privilegija

        #endregion Privilegije

        #region StavkaMenija
        public static List<StavkaMenijaView> vratiSveStavkeMenija()
        {
            List<StavkaMenijaView> stavMen = new List<StavkaMenijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StavkaMenija> sveStavke = from o in s.Query<StavkaMenija>() select o;

                foreach (StavkaMenija sm in sveStavke)
                {
                    stavMen.Add(new StavkaMenijaView(sm));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
            return stavMen;
        }
        //public static void dodajStavkuMenija(int kkID, StavkaMenijaView smv)
        //{
        //    try
        //    {
        //        ISession s = DataLayer.GetSession();
        //        KoriscenjeKorisnickogInterfejsa kki = s.Get<KoriscenjeKorisnickogInterfejsa>(kkID);
        //        StavkaMenija rod = s.Load<StavkaMenija>(smv.Roditelj.Id);
        //        StavkaMenija k = new StavkaMenija
        //        {
        //            SM_FK=smv.SM_FK,
        //            Roditelj=rod,  
        //            TipKKI=smv.TipKKI,
        //            Tip=smv.Tip,
        //            Ime=smv.Ime,
        //        };
        //        kki.Stavka = k; // ?????????

        //        s.SaveOrUpdate(k);
        //        s.Flush();
        //        s.Close();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //        //MessageBox.Show(ec.Message);
        //    }
        //}
        //public static StavkaMenijaView azurirajStavkuMenija(StavkaMenijaView k)
        //{
        //    try
        //    {
        //        ISession s = DataLayer.GetSession();

        //        StavkaMenija kr = s.Load<StavkaMenija>(k.Id);
        //        StavkaMenija smr = s.Load<StavkaMenija>(k.Roditelj.Id);
        //        kr.Ime = k.Ime;
        //        kr.Id = k.Id;
        //        kr.SM_FK = k.SM_FK;
        //        kr.Tip = k.Tip;
        //        kr.TipKKI = k.TipKKI;
        //        kr.Roditelj = smr;

        //        s.Update(kr);
        //        s.Flush();
        //        s.Close();
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(ec.Message);
        //        throw;
        //    }
        //    return k;
        //}
        public static StavkaMenijaView vratiSM(int id)
        {
            StavkaMenijaView smV;

            try
            {
                ISession s = DataLayer.GetSession();

                StavkaMenija k = s.Load<StavkaMenija>(id);
                smV = new StavkaMenijaView(k);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return smV;
        }

        public static void obrisiStavkuMenija(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StavkaMenija o = s.Load<StavkaMenija>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion StavkaMenija

        #region Dodeli

        public static void dodajDodeliAdm(DodeliView dv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik k = s.Load<Korisnik>(dv.DodeljujeKorisnik.JMBG);
                GrupaKorisnika g = s.Load<GrupaKorisnika>(dv.DodeljujeGrupi.JedinstvenoIme);
                DateTime dt = DateTime.Today;
                Administrativne p = s.Load<Administrativne>(dv.DodeljujuSePrivilegija.Id);
                Dodeli d = new Dodeli
                {
                    DodeljujeKorisnik = k,
                    DodeljujeGrupi = g,
                    DodeljujuSePrivilegija = p,
                    Datum_Dodeljivanja = dt,
                };

                s.SaveOrUpdate(d);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }

        public static void dodajDodeliKFM(DodeliView dv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik k = s.Load<Korisnik>(dv.DodeljujeKorisnik.JMBG);
                GrupaKorisnika g = s.Load<GrupaKorisnika>(dv.DodeljujeGrupi.JedinstvenoIme);
                DateTime dt = DateTime.Today;
                KoriscenjeFunkcionalnihModula p = s.Load<KoriscenjeFunkcionalnihModula>(dv.DodeljujuSePrivilegija.Id);
                IEnumerable<Dodeli> provera = from o in s.Query<Dodeli>() where o.DodeljujeGrupi == g && o.DodeljujuSePrivilegija == p select o;
                if (provera.Count() == 0)
                {
                    Dodeli d = new Dodeli
                    {
                        DodeljujeKorisnik = k,
                        DodeljujeGrupi = g,
                        DodeljujuSePrivilegija = p,
                        Datum_Dodeljivanja = dt,
                    };

                    s.SaveOrUpdate(d);
                    s.Flush();
                }
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }

        #endregion Dodeli

        #region Profil

        public static List<ProfilView> vratiProfile(int jmbg)
        {
            List<ProfilView> profili = new List<ProfilView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Profil> sviP = from o in s.Query<Profil>()
                                                   where o.KorisnikJMBG.JMBG == jmbg
                                                   select o;

                foreach (Profil p in sviP)
                {
                    profili.Add(new ProfilView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
            return profili;
        }

        public static void dodajProfil(int jmbg, ProfilView pv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Profil o = new Profil();
                Korisnik kor = s.Load<Korisnik>(jmbg);

                o.Boja_pozadine = pv.Boja_pozadine;
                o.KorisnikJMBG = kor;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
        }

        public static ProfilView azurirajProfil(ProfilView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Profil pro = s.Load<Profil>(p.Redni_broj);
                Korisnik kor = s.Load<Korisnik>(p.KorisnikJMBG.JMBG);
                pro.Boja_pozadine = p.Boja_pozadine;
                pro.KorisnikJMBG = kor;
                s.Update(pro);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ec.Message);
                throw;
            }
            return p;
        }

        public static void obrisiProfil(int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Profil> t = from o in s.Query<Profil>() where o.Redni_broj == rbr select o;
                //Telefon o = s.Load<Telefon>(brt);
                foreach (Profil pro in t)
                {
                    s.Delete(pro);
                }

                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(ec.Message);
            }
        }

        #endregion Profil

    }
}
