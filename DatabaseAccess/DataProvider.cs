using DatabaseAccess.DTOs;
using NHibernate;
using DatabaseAccess;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region Modna Revija
        public static List<ModnaRevijaView> vratiSveRevije()
        {
            List<ModnaRevijaView> revije = new List<ModnaRevijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<ModnaRevija> sveRevije = from o in s.Query<ModnaRevija>() select o;

                foreach (ModnaRevija m in sveRevije)
                {
                    var revija = new ModnaRevijaView(m);
                    revija.VipNaReviji = m.VipNaReviji.Select(p=>new PojavljujeSeNaView(p)).ToList();
                    revija.OrganizovanaOdStrane = m.OrganizovanaOdStrane.Select(p => new OrganizujeView(p)).ToList();
                    revija.UcesniciRevije = m.UcesniciRevije.Select(p => new UcestvujeNaView(p)).ToList();

                    revije.Add(revija);
                }
                s.Close();
            }
            catch (Exception ec)
            {
                
            }
            return revije;
        }
        public static List<KreatorView> vratiKretoreRevije(int rbr)
        {
            List<KreatorView> kreatori = new List<KreatorView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Organizuje> sveRevije = from o in s.Query<Organizuje>()
                                                    where o.OrganizujeRevija.RbrRevije == rbr
                                                    select o;

                foreach (Organizuje or in sveRevije)
                {

                    kreatori.Add(new KreatorView(or.KreatorOrganizuje));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kreatori;
        }
        public static List<ModnaRevijaView> vratiSveRevijeSaVip(int id)
        {
            List<ModnaRevijaView> revije = new List<ModnaRevijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<PojavljujeSeNa> sveRevije = from o in s.Query<PojavljujeSeNa>()
                                                        where o.VipPojavljujeSeNa.Id == id
                                                        select o;

                foreach (PojavljujeSeNa p in sveRevije)
                {
                    var revija = new ModnaRevijaView(p.PojavljujuSeNaRevija);
                    //p.VipNaReviji.Select(p => new PojavljujeSeNaView(p)).ToList();
                    revija.OrganizovanaOdStrane = p.PojavljujuSeNaRevija.OrganizovanaOdStrane.Select(p => new OrganizujeView(p)).ToList();
                   // revija.UcesniciRevije = p.PojavljujuSeNaRevija.UcesniciRevije.Select(p => new UcestvujeNaView(p)).ToList();
                    revije.Add(revija);
                }
                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return revije;
        }
        public static void dodajReviju(ModnaRevijaView r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaRevija m = new DatabaseAccess.Entiteti.ModnaRevija();
                m.RbrRevije = r.RbrRevije;
                m.Naziv = r.Naziv;
                m.MestoOdrzavanja = r.MestoOdrzavanja;
                m.DatumVreme = r.DatumVremeOdrzavanja;
                m.PrvaZajRevija = r.PrvaZajednickaRevija;

                s.SaveOrUpdate(m);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiReviju(int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaRevija r = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(rbr);

                s.Delete(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static ModnaRevijaView vratiReviju(int rbr)
        {
            ModnaRevijaView revija = new ModnaRevijaView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaRevija o = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(rbr);
                revija = new ModnaRevijaView(o);
                revija.OrganizovanaOdStrane = o.OrganizovanaOdStrane.Select(p=> new OrganizujeView(p)).ToList();
                revija.UcesniciRevije = o.UcesniciRevije.Select(p => new UcestvujeNaView(p)).ToList();
                revija.VipNaReviji = o.VipNaReviji.Select(p => new PojavljujeSeNaView(p)).ToList();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return revija; 
        }
        public static ModnaRevijaView izmeniReviju(ModnaRevijaView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaRevija o = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(m.RbrRevije);
                o.RbrRevije = m.RbrRevije;
                o.Naziv = m.Naziv;
                o.MestoOdrzavanja = m.MestoOdrzavanja;
                o.DatumVreme = m.DatumVremeOdrzavanja;
                o.PrvaZajRevija = m.PrvaZajednickaRevija;

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return m;
        }
        #endregion
        #region ProfesionalniModel

        public static ProfesionalniModelView vratiManekena(int id)
        {
            ProfesionalniModelView pm = new ProfesionalniModelView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ProfesionalniModel o = s.Load<DatabaseAccess.Entiteti.ProfesionalniModel>(id);
                pm = new ProfesionalniModelView(o);
                pm.NaslovneStrane = o.NaslovneStrane.Select(p => new NaslovnaStranaView(p)).ToList();
                pm.UcestvujeNaReviji = o.UcestvujeNaReviji.Select(p =>new UcestvujeNaView(p)).ToList();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return pm;
        }
        public static void azurirajProfesionalnogModela(ProfesionalniModelView model)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ProfesionalniModel o = s.Load<DatabaseAccess.Entiteti.ProfesionalniModel>(model.Id);

                o.Mbr = model.Mbr;
                o.Ime = model.Ime;
                o.Prezime = model.Prezime;
                o.DatRodjenja = model.DatRodjenja;
                o.Pol = model.Pol;
                o.Visina = model.Visina;
                o.Tezina = model.Tezine;
                o.BojaKose = model.BojaKose;
                o.BojaOciju = model.BojaOciju;
                o.KonfekcijskiBroj = model.KonfBroj;
                o.Agencija = s.Load<DatabaseAccess.Entiteti.ModnaAgencija>(model.Agencija.PIB);

                //o.UcestvujeNaReviji.

                s.Update(o);
                s.Flush();


                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<ProfesionalniModelView> vratiSveManekeneRevije(int rbr)
        {
            List<ProfesionalniModelView> manekeni = new List<ProfesionalniModelView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.UcestvujeNa> sviManekeni = from o in s.Query<DatabaseAccess.Entiteti.UcestvujeNa>()
                                                                       where o.UcestvujeNaRevija.RbrRevije == rbr
                                                                       where o.SpecijalniGost == 'N'
                                                                       select o;

                foreach (DatabaseAccess.Entiteti.UcestvujeNa u in sviManekeni)
                {
                    {
                        
                        DatabaseAccess.Entiteti.ProfesionalniModel p = s.Load<DatabaseAccess.Entiteti.ProfesionalniModel>(u.OsobaUcestvujeNa.Id);
                        manekeni.Add(new ProfesionalniModelView(p));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return manekeni;
        }
        public static void obrisiManekena(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Osoba o = s.Load<DatabaseAccess.Entiteti.Osoba>(id);
                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajProfModela(ProfesionalniModelView model, int r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ProfesionalniModel o = new DatabaseAccess.Entiteti.ProfesionalniModel();
                DatabaseAccess.Entiteti.UcestvujeNa u = new DatabaseAccess.Entiteti.UcestvujeNa();
                DatabaseAccess.Entiteti.ModnaRevija revija = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(r);

                o.Mbr = model.Mbr;
                o.Ime = model.Ime;
                o.Prezime = model.Prezime;
                o.DatRodjenja = model.DatRodjenja;
                o.Pol = model.Pol;
                o.Visina = model.Visina;
                o.Tezina = model.Tezine;
                o.BojaKose = model.BojaKose;
                o.BojaOciju = model.BojaOciju;
                o.KonfekcijskiBroj = model.KonfBroj;
                o.Agencija = s.Load<DatabaseAccess.Entiteti.ModnaAgencija>(model.Agencija.PIB);

                //o.UcestvujeNaReviji.

                s.SaveOrUpdate(o);
                s.Flush();
                u.OsobaUcestvujeNa = o;
                u.UcestvujeNaRevija = revija;
                u.SpecijalniGost = 'N';
                s.SaveOrUpdate(u);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<ProfesionalniModelView> vratiSveManekene()
        {
            List<ProfesionalniModelView> manekeni = new List<ProfesionalniModelView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.ProfesionalniModel> sviManekeni = from o in s.Query<DatabaseAccess.Entiteti.ProfesionalniModel>()
                                                                              select o;

                foreach (DatabaseAccess.Entiteti.ProfesionalniModel p in sviManekeni)
                {
                    {
                        manekeni.Add(new ProfesionalniModelView(p));
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return manekeni;
        }
        public static void dodajProfModela(ProfesionalniModelView model)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ProfesionalniModel o = new DatabaseAccess.Entiteti.ProfesionalniModel();

                o.Mbr = model.Mbr;
                o.Ime = model.Ime;
                o.Prezime = model.Prezime;
                o.DatRodjenja = model.DatRodjenja;
                o.Pol = model.Pol;
                o.Visina = model.Visina;
                o.Tezina = model.Tezine;
                o.BojaKose = model.BojaKose;
                o.BojaOciju = model.BojaOciju;
                o.KonfekcijskiBroj = model.KonfBroj;
                o.Agencija = s.Load<DatabaseAccess.Entiteti.ModnaAgencija>(model.Agencija.PIB);

                //o.UcestvujeNaReviji.

                s.SaveOrUpdate(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region Vip
        public static void dodeliRevijuVipu(int rbr, int id,int idp)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DatabaseAccess.Entiteti.ModnaRevija o = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(rbr);
                DatabaseAccess.Entiteti.Vip v = s.Load<DatabaseAccess.Entiteti.Vip>(id);
                DatabaseAccess.Entiteti.PojavljujeSeNa p = new DatabaseAccess.Entiteti.PojavljujeSeNa();

                p.Id = idp;
                p.PojavljujuSeNaRevija = o;
                p.VipPojavljujeSeNa = v;

                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajVipModela(VipView v, int r)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DatabaseAccess.Entiteti.UcestvujeNa ucesnik = new DatabaseAccess.Entiteti.UcestvujeNa();
                DatabaseAccess.Entiteti.ModnaRevija revija = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(r);
                DatabaseAccess.Entiteti.Vip o = new DatabaseAccess.Entiteti.Vip();

                o.Mbr = v.Mbr;
                o.Ime = v.Ime;
                o.Prezime = v.Prezime;
                o.DatRodjenja = v.DatRodjenja;
                o.Pol = v.Pol;
                o.Zanimanje = v.Zanimanje;

                s.SaveOrUpdate(o);
                s.Flush();
                ucesnik.OsobaUcestvujeNa = o;
                ucesnik.UcestvujeNaRevija = revija;
                ucesnik.SpecijalniGost = 'Y';
                s.SaveOrUpdate(ucesnik);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static VipView vratiVip(int id)
        {
            VipView vb = new VipView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Vip o = s.Load<DatabaseAccess.Entiteti.Vip>(id);
                vb = new VipView(o);

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return vb;
        }
        public static VipView IzmeniVipNaReviji(VipView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Vip o = s.Load<DatabaseAccess.Entiteti.Vip>(v.Id);

                o.Mbr = v.Mbr;
                o.Ime = v.Ime;
                o.Prezime = v.Prezime;
                o.DatRodjenja = v.DatRodjenja;
                o.Pol = v.Pol;
                o.Zanimanje = v.Zanimanje;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return v;
        }
        public static void obrisiVip(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Osoba o = s.Load<DatabaseAccess.Entiteti.Osoba>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region Modna agencija
        public static ModnaAgencijaView vratiModnuAgenciju(int pib)
        {
            List<ModnaAgencijaView> agencije = new List<ModnaAgencijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.ModnaAgencija> svi = from o in s.Query<DatabaseAccess.Entiteti.ModnaAgencija>()
                                                                 where o.PIB == pib

                                                                 select o;

                foreach (DatabaseAccess.Entiteti.ModnaAgencija u in svi)
                {
                    {
                        if (u is Domaca)
                        {
                            var agencija = new DomacaView(u);
                            agencija.ProfesionalniModeli = u.ProfesionalniModeli.Select(p => new ProfesionalniModelView(p)).ToList();
                            agencije.Add(agencija);
                        }
                           
                        else
                        {
                            var agencija = new InternacionalnaView(u);
                            agencija.ProfesionalniModeli = u.ProfesionalniModeli.Select(p => new ProfesionalniModelView(p)).ToList();
                            agencije.Add(agencija);
                        }
                        
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return agencije.FirstOrDefault();
        }
        public static void obrisiAgenciju(int pib)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaAgencija ag = (from o in s.Query<DatabaseAccess.Entiteti.ModnaAgencija>()
                                                            where o.PIB==pib

                                                    select o).FirstOrDefault();

                s.Delete(ag);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajModnuAgenciju(ModnaAgencijaView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DatabaseAccess.Entiteti.ModnaAgencija ma;
                if (m.Tip == "DOMACA")
                {
                    ma = new DatabaseAccess.Entiteti.Domaca();
                }
                else
                {
                    ma = new DatabaseAccess.Entiteti.Internacionalna();
                }

                ma.PIB = m.PIB;
                ma.Naziv = m.Naziv;
                ma.Sediste = m.Sediste;
                ma.DatumOsnivanja = m.DatumOsnivanja;
                s.Save(ma);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajDomacu(DomacaView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DatabaseAccess.Entiteti.Domaca ma;
                
                    ma = new DatabaseAccess.Entiteti.Domaca();
               
                ma.PIB = m.PIB;
                ma.Naziv = m.Naziv;
                ma.Sediste = m.Sediste;
                ma.DatumOsnivanja = m.DatumOsnivanja;
                s.Save(ma);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }

        public static void dodajInternacinalnu(InternacionalnaView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DatabaseAccess.Entiteti.Internacionalna ma;

                ma = new DatabaseAccess.Entiteti.Internacionalna();

                ma.PIB = m.PIB;
                ma.Naziv = m.Naziv;
                ma.Sediste = m.Sediste;
                ma.DatumOsnivanja = m.DatumOsnivanja;
                s.Save(ma);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<ModnaAgencijaView> vratiSveAgencije()
        {
            List<ModnaAgencijaView> agencije = new List<ModnaAgencijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.ModnaAgencija> svi = from o in s.Query<DatabaseAccess.Entiteti.ModnaAgencija>()

                                                                 select o;

                foreach (DatabaseAccess.Entiteti.ModnaAgencija u in svi)
                {
                    
                    {
                        if (u is Domaca)
                        {
                            var agencija = new DomacaView(u);
                            agencija.ProfesionalniModeli = u.ProfesionalniModeli.Select(p => new ProfesionalniModelView(p)).ToList();
                            agencije.Add(agencija);
                        }
                           
                        else
                        {
                            var agencija = new InternacionalnaView(u);
                            agencija.ProfesionalniModeli = u.ProfesionalniModeli.Select(p => new ProfesionalniModelView(p)).ToList();
                            agencije.Add(agencija);
                        }
                           
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return agencije;
        }
        public static void izmeniModnuAgenciju(ModnaAgencijaView m)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModnaAgencija o = s.Load<DatabaseAccess.Entiteti.ModnaAgencija>(m.PIB);

                o.PIB = m.PIB;
                o.Naziv = m.Naziv;
                o.Sediste = m.Sediste;
                o.DatumOsnivanja = m.DatumOsnivanja;
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<VipView> vratiSveVipRevije(int rbr)
        {
            List<VipView> vips = new List<VipView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.UcestvujeNa> sviVips = from o in s.Query<DatabaseAccess.Entiteti.UcestvujeNa>()
                                                                   where o.UcestvujeNaRevija.RbrRevije == rbr
                                                                   where o.SpecijalniGost == 'Y'
                                                                   select o;

                foreach (DatabaseAccess.Entiteti.UcestvujeNa u in sviVips)
                {
                    {
                        DatabaseAccess.Entiteti.Vip v = s.Load<DatabaseAccess.Entiteti.Vip>(u.OsobaUcestvujeNa.Id);
                        vips.Add(new VipView(v));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return vips;
        }

        public static List<string> vratiAktivneZemlje(int pib)
        {
            List<string> zemlje = new List<string>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<DatabaseAccess.Entiteti.PoslujeU> sveZemlje = from o in s.Query<DatabaseAccess.Entiteti.PoslujeU>()
                                                                  where o.AgencijaPoslujeU.PIB == pib
                                                                  select o;
                foreach (DatabaseAccess.Entiteti.PoslujeU u in sveZemlje)
                {
                    zemlje.Add(u.NazivZemlje);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return zemlje;
        }
        #endregion
        #region Modni kreator
        public static void ukloniKreatoraSaRevije(int id, int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Organizuje spoj = (from o in s.Query<DatabaseAccess.Entiteti.Organizuje>()
                                                   where o.KreatorOrganizuje.Id == id
                                                   where o.OrganizujeRevija.RbrRevije == rbr
                                                   select o).FirstOrDefault();

                s.Delete(spoj);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajKreatoraReviji(KreatorView k, int rbr)

        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModniKreator kr = new DatabaseAccess.Entiteti.ModniKreator();
                DatabaseAccess.Entiteti.Organizuje o = new DatabaseAccess.Entiteti.Organizuje();
                DatabaseAccess.Entiteti.ModnaRevija r = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(rbr);

                kr.Mbr = k.Mbr;
                kr.Ime = k.Ime;
                kr.Prezime = k.Prezime;
                kr.DatRodjenja = k.DatRodjenja;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                o.KreatorOrganizuje = kr;
                o.OrganizujeRevija = r;
                s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<KreatorView> vratiSveKreatore()
        {
            List<KreatorView> kreatori = new List<KreatorView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.ModniKreator> sviKreatori = from o in s.Query<DatabaseAccess.Entiteti.ModniKreator>()
                                                                        select o;

                foreach (DatabaseAccess.Entiteti.ModniKreator r in sviKreatori)
                {
                    kreatori.Add(new KreatorView(r));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kreatori;
        }
        public static void dodajPostojecegKreatora(KreatorView kr,ModnaRevijaView r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Organizuje o = new Organizuje();
                o.KreatorOrganizuje = s.Load<DatabaseAccess.Entiteti.ModniKreator>(kr.Id);
                o.OrganizujeRevija = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(r.RbrRevije);

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static KreatorView vratiKreatora(int id)
        {
            KreatorView kb = new KreatorView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModniKreator o = s.Load<DatabaseAccess.Entiteti.ModniKreator>(id);
                kb = new KreatorView(o);

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return kb;
        }
        public static List<ModnaRevijaView> vratiSveRevijeKreatora(int id)
        {
            List<ModnaRevijaView> revije = new List<ModnaRevijaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.Organizuje> sveRevije = from o in s.Query<DatabaseAccess.Entiteti.Organizuje>()
                                                                    where o.KreatorOrganizuje.Id == id
                                                                    select o;

                foreach (DatabaseAccess.Entiteti.Organizuje p in sveRevije)
                {
                    revije.Add(new ModnaRevijaView(p.OrganizujeRevija));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return revije;
        }
        public static void dodajKreatora(KreatorView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModniKreator kr = new DatabaseAccess.Entiteti.ModniKreator();

                kr.Mbr = k.Mbr;
                kr.Ime = k.Ime;
                kr.Prezime = k.Prezime;
                kr.DatRodjenja = k.DatRodjenja;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void izmeniKreatora(KreatorView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModniKreator kr = s.Load<DatabaseAccess.Entiteti.ModniKreator>(k.Id);

                kr.Mbr = k.Mbr;
                kr.Ime = k.Ime;
                kr.Prezime = k.Prezime;
                kr.DatRodjenja = k.DatRodjenja;
                kr.Pol = k.Pol;
                kr.ZemljaPorekla = k.zemljaPorekla;
                kr.NazivModneKuce = k.nazivKuce;
                s.Save(kr);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void obrisiKreatora(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.ModniKreator o = s.Load<DatabaseAccess.Entiteti.ModniKreator>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region Posluje U
        public static List<PoslujeUView> vratiPoslujeU(int pib)
        {
            List<PoslujeUView> posluje = new List<PoslujeUView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.PoslujeU> svi = from o in s.Query<DatabaseAccess.Entiteti.PoslujeU>()
                                                            where o.AgencijaPoslujeU.PIB == pib
                                                            select o;

                foreach (DatabaseAccess.Entiteti.PoslujeU u in svi)
                {
                    {

                        posluje.Add(new PoslujeUView(u));

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return posluje;
        }
        public static PoslujeUView vratiPosluje(int id)
        {
            PoslujeUView posluje = new PoslujeUView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PoslujeU svi = (from o in s.Query<DatabaseAccess.Entiteti.PoslujeU>()
                                                where o.Id == id
                                                select o).FirstOrDefault();

                posluje = new PoslujeUView(svi);
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return posluje;
        }
        public static void obrisiZemlju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PoslujeU p = s.Load<DatabaseAccess.Entiteti.PoslujeU>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajZemlju(string naziv, int pib)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PoslujeU p = new DatabaseAccess.Entiteti.PoslujeU();

                DatabaseAccess.Entiteti.Internacionalna a = s.Load<DatabaseAccess.Entiteti.Internacionalna>(pib);

                p.AgencijaPoslujeU = a;
                p.NazivZemlje = naziv;

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void izmeniZemlju(PoslujeUView pos)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PoslujeU p = s.Load<DatabaseAccess.Entiteti.PoslujeU>(pos.Id);

                p.NazivZemlje = pos.NazivZemlje;
                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region Naslpovna strana
        public static List<String> vratiSveNaslovneStrane(int id)
        {
            List<String> str = new List<String>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<DatabaseAccess.Entiteti.NaslovnaStrana> svi = from o in s.Query<DatabaseAccess.Entiteti.NaslovnaStrana>()
                                                                  where o.ModelNaNaslovnojStrani.Id == id
                                                                  select o;

                foreach (DatabaseAccess.Entiteti.NaslovnaStrana u in svi)
                {
                    {

                        str.Add(u.NazivCasopisa);

                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }

            return str;
        }
        public static void obrisiStranicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.NaslovnaStrana p = s.Load<DatabaseAccess.Entiteti.NaslovnaStrana>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static void dodajNaslovnuStranu(ProfesionalniModelView m, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.NaslovnaStrana p = new DatabaseAccess.Entiteti.NaslovnaStrana();

                DatabaseAccess.Entiteti.ProfesionalniModel a = s.Load<DatabaseAccess.Entiteti.ProfesionalniModel>(m.Id);

                p.ModelNaNaslovnojStrani = a;
                p.NazivCasopisa = naziv;

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static NaslovnaStranaView vratiNaslovnuStranu(int id)
        {
            NaslovnaStranaView str = new NaslovnaStranaView();
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.NaslovnaStrana a = s.Load<DatabaseAccess.Entiteti.NaslovnaStrana>(id);

                str.Id = a.Id;
                str.Model = new ProfesionalniModelView( a.ModelNaNaslovnojStrani);
                str.NazivCasopisa = a.NazivCasopisa;


                s.Close();
            }
            catch (Exception ec)
            {
               // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return str;
        }
        public static void IzmeniNaslovnuStranu(NaslovnaStranaView n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.NaslovnaStrana p = s.Load<DatabaseAccess.Entiteti.NaslovnaStrana>(n.Id);

                p.NazivCasopisa = n.NazivCasopisa;
                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region PojavljujeSeNa
        public static void obrisiPojavljujeSeNa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PojavljujeSeNa o = s.Load<DatabaseAccess.Entiteti.PojavljujeSeNa>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static List<ModnaRevijaView> vratiSveRevijeGdeSeVipPojavljuje(VipView v)
        {
            List<ModnaRevijaView> revije = new List<ModnaRevijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
               // IEnumerable<ModnaRevija> sveRevije = from o in s.Query<ModnaRevija>() select o;
                IEnumerable<PojavljujeSeNa> sve = from o in s.Query<PojavljujeSeNa>() where o.VipPojavljujeSeNa.Id==v.Id select o;

                foreach (PojavljujeSeNa m in sve)
                {
                    var revija = new ModnaRevijaView();
                    revija.RbrRevije = m.PojavljujuSeNaRevija.RbrRevije;
                    revija.Naziv = m.PojavljujuSeNaRevija.Naziv;
                    revija.MestoOdrzavanja = m.PojavljujuSeNaRevija.MestoOdrzavanja;
                    revija.PrvaZajednickaRevija = m.PojavljujuSeNaRevija.PrvaZajRevija;
                    //revija.VipNaReviji = m.PojavljujuSeNaRevija.VipNaReviji.Select(p => new PojavljujeSeNaView(p)).ToList();
                    revija.OrganizovanaOdStrane = m.PojavljujuSeNaRevija.OrganizovanaOdStrane.Select(p => new OrganizujeView(p)).ToList();
                    //revija.UcesniciRevije = m.PojavljujuSeNaRevija.UcesniciRevije.Select(p => new UcestvujeNaView(p)).ToList();

                    revije.Add(revija);
                }
                s.Close();
            }
            catch (Exception ec)
            {

            }
            return revije;
        }
        public static int izmeniGdeSePojavljujeVip(PojavljujeSeNaView v)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.PojavljujeSeNa o = s.Load<DatabaseAccess.Entiteti.PojavljujeSeNa>(v.Id);

                o.PojavljujuSeNaRevija = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(v.PojavljujuSeNaRevija.RbrRevije);

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return 0;
        }
        #endregion
        #region UcestvujeNa
        public static List<UcestvujeNaView> vratiSveUcesnikeRevije(int rbr)
        {
            List<UcestvujeNaView> revije = new List<UcestvujeNaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<UcestvujeNa> sveRevije = from o in s.Query<UcestvujeNa>() where o.UcestvujeNaRevija.RbrRevije==rbr select o;

                foreach (UcestvujeNa m in sveRevije)
                {
                    var revija = new UcestvujeNaView(m);
                    //revija.OsobaUcestvujeNa = new OsobaView(m.OsobaUcestvujeNa);
                    //revija.UcestvujeNaRevija = new ModnaRevijaView(m.UcestvujeNaRevija);
                   

                    revije.Add(revija);
                }
                s.Close();
            }
            catch (Exception ec)
            {

            }
            return revije;
        }

        public static void obrisiUcesnikaRevije(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.UcestvujeNa r = s.Load<DatabaseAccess.Entiteti.UcestvujeNa>(id);

                s.Delete(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        public static int izmeniUcestvujeNaReviji(int u,int rbr)
        {
            
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.UcestvujeNa o = s.Load<DatabaseAccess.Entiteti.UcestvujeNa>(u);
                o.UcestvujeNaRevija =  new ModnaRevija();
                var r = vratiReviju(rbr);
                o.UcestvujeNaRevija.RbrRevije = r.RbrRevije;
                o.UcestvujeNaRevija.Naziv = r.Naziv;
                o.UcestvujeNaRevija.MestoOdrzavanja = r.MestoOdrzavanja;
                o.UcestvujeNaRevija.PrvaZajRevija = r.PrvaZajednickaRevija;

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return u ;
        }
        public static void dodajUcesnikaReviji(int id, int rbr)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.UcestvujeNa p = new DatabaseAccess.Entiteti.UcestvujeNa();

                DatabaseAccess.Entiteti.Osoba a = s.Load<DatabaseAccess.Entiteti.Osoba>(id);
                DatabaseAccess.Entiteti.ModnaRevija r = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(rbr);

                p.OsobaUcestvujeNa = a;
                p.UcestvujeNaRevija = r;
                if(a is Vip)
                p.SpecijalniGost ='Y';
                else
                    p.SpecijalniGost = 'N';

                s.Save(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(ec.Message);
            }
        }
        #endregion
        #region Organizuje
        public static int izmeniOrganizuje(OrganizujeView v)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                DatabaseAccess.Entiteti.Organizuje o = s.Load<DatabaseAccess.Entiteti.Organizuje>(v.id);

                o.OrganizujeRevija = s.Load<DatabaseAccess.Entiteti.ModnaRevija>(v.OrganizujeRevija.RbrRevije);

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                // System.Windows.Forms.MessageBox.Show(ec.Message);
            }
            return 0;
        }
        #endregion
    }
}
