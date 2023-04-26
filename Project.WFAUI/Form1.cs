using Project.BLL.Repositories.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WFAUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _proRep = new ProvinceRepository();
            _partyRep = new PartyRepository();
            _voteRep = new VoteRepository();

        }
        ProvinceRepository _proRep;
        PartyRepository _partyRep;
        VoteRepository _voteRep;

        private void btnOy_Click(object sender, EventArgs e)
        {
            if (_selectedParty != null)
            {
                Vote v = new Vote();
                v.NumberOfVotes = Convert.ToInt32(txtOy.Text);
                v.Party = _selectedParty;

                _voteRep.Add(v);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIlce.DataSource = _proRep.GetAll();

            cmbIlce.DisplayMember = "ProvinceName";


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Party p = new Party();
            p.PartyName = txtIlce.Text;
            p.Province = _selectedProvince;
            _partyRep.Add(p);
        }
        Province _selectedProvince;
        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIlce.SelectedIndex > -1)
            {
                _selectedProvince = cmbIlce.SelectedItem as Province;
                lstListele.DataSource = _selectedProvince.Parties;
            }
        }

        Party _selectedParty;
        Vote _selectedVote;
        private void lstListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListele.SelectedIndex > -1)
            {
                _selectedParty = lstListele.SelectedItem as Party;
            }


        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();

            frg.ShowDialog();
        }
    }
}
