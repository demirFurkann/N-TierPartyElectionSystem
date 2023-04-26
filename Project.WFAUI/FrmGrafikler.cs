using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Repositories.ConcRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Project.WFAUI
{
    public partial class FrmGrafikler : Form
    {

        SqlConnection baglanti = new SqlConnection();
        public FrmGrafikler()
        {
            InitializeComponent();
            _proRep = new ProvinceRepository();
            _partyRep = new PartyRepository();
            _voteRep = new VoteRepository();


        }
        ProvinceRepository _proRep;
        PartyRepository _partyRep;
        VoteRepository _voteRep;

        MyContext _db;


        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            // Iller combobox'ına illeri yükleme
            cmbIlceler.DataSource = _proRep.GetAll();
            cmbIlceler.DisplayMember = "ProvinceName";

            Series series = new Series("Partiler");
            chart1.Series.Add(series);


        }
        Province _selectedProvince;


        private void cmbIlceler_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbIlceler.SelectedIndex > -1)
            {
                _selectedProvince = cmbIlceler.SelectedItem as Province;
            }

            Series s = new Series("Partiler");

            int totalVote = _voteRep.Where(x => x.Party.ID == x.PartyID).Sum(x => x.NumberOfVotes);


            var partyVotes = _voteRep.GetAll().GroupBy(v => v.PartyID)
                       .Select(g => new { PartyID = g.Key, TotalVotes = g.Sum(x => x.NumberOfVotes) });

            // Grafik series'lerini ekle
            chart1.Series.Clear();
            foreach (var item in partyVotes)
            {
                chart1.Series.Add(item.PartyID.ToString() + " Parti");
                chart1.Series[item.PartyID.ToString() + " Parti"].Points.Add(item.TotalVotes);
            }



            // Progress Bar'ların başlangıç değerleri
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;

            // Toplam oy sayılarını hesapla
            double totalVotesA = partyVotes.Where(x => x.PartyID == 1).Sum(x => x.TotalVotes);
            double totalVotesB = partyVotes.Where(x => x.PartyID == 2).Sum(x => x.TotalVotes);
            double totalVotesC = partyVotes.Where(x => x.PartyID == 3).Sum(x => x.TotalVotes);

            // Her bir parti için progress bar değerlerini ayarla
            if (totalVotesA > 0)
            {
                progressBar1.Value = (int)((totalVotesA / totalVote) * 100);
            }
            if (totalVotesB > 0)
            {
                progressBar2.Value = (int)((totalVotesB / totalVote) * 100);
            }
            if (totalVotesC > 0)
            {
                progressBar3.Value = (int)((totalVotesC / totalVote) * 100);
            }

        }



    }
}
