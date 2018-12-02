using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QL_CuocPhi.Models
{
    public class SimsController : Controller
    {
        private QL_CuocPhiDbContext db = new QL_CuocPhiDbContext();

        // GET: Sims
        public ActionResult Index(string searchKey)
        {
            var danhsachSim = (IEnumerable<Sim>)db.Sims.ToList();
            if (!String.IsNullOrEmpty(searchKey))
            {
                danhsachSim = danhsachSim.Where(x => x.SoSim == searchKey);
            }
            return View(danhsachSim);
        }

        // GET: Sims/ChiTiet/5
        public ActionResult ChiTiet(string id)
        {
            var cuocGois = db.CuocGois.Include(c => c.Sim);
            if (!String.IsNullOrEmpty(id))
            {
                cuocGois = cuocGois.Where(x => x.Sim.SoSim == id);
            }
            return View(cuocGois.ToList());
        }

        // GET: Sims/CuocPhi/5
        public ActionResult CuocPhi(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hd = db.HoaDonThanhToans.OrderByDescending(x=>x.TG_TaoHoaDon).FirstOrDefault(x => x.Sim.SoSim == id);
            ViewBag.phiSuDung = hd.ThanhTien - hd.CuocThueBao;
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
